using ApiUsuarios.Models;
using ApiUsuariosCrud.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(AppDbContext context,
        ILogger<UsuariosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Retorna todos os usuários
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        _logger.LogInformation("GET: Recuperando todos os usuários");
        var usuarios = await _context.Usuarios.ToListAsync();
        return Ok(usuarios);
    }

    /// <summary>
    /// Retorna apenas usuários ativos
    /// </summary>
    [HttpGet("ativos")]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosAtivos()
    {
        _logger.LogInformation("GET: Recuperando usuários ativos");
        var usuarios = await _context.Usuarios
            .Where(u => u.Ativo)
            .ToListAsync();
        return Ok(usuarios);
    }

    /// <summary>
    /// Retorna um usuário específico pelo ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("GET: Usuário {Id} não encontrado", id);
            return NotFound(new { mensagem = "Usuário não encontrado" });
        }

        return Ok(usuario);
    }

    /// <summary>
    /// Cria um novo usuário
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(
        [FromBody] CreateUsuarioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Verificar se email já existe
        if (await _context.Usuarios.AnyAsync(u => u.Email == request.Email))
        {
            _logger.LogWarning("POST: Email {Email} já cadastrado", request.Email);
            return BadRequest(new { mensagem = "Email já cadastrado" });
        }

        var usuario = new Usuario
        {
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone,
            DataCadastro = DateTime.UtcNow,
            Ativo = true
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        _logger.LogInformation("POST: Novo usuário criado com ID {Id}", usuario.Id);
        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
    }

    /// <summary>
    /// Atualiza um usuário existente
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id,
        [FromBody] UpdateUsuarioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("PUT: Usuário {Id} não encontrado", id);
            return NotFound(new { mensagem = "Usuário não encontrado" });
        }

        // Verificar se novo email já existe (de outro usuário)
        if (request.Email != usuario.Email &&
            await _context.Usuarios.AnyAsync(u => u.Email == request.Email))
        {
            _logger.LogWarning("PUT: Email {Email} já cadastrado", request.Email);
            return BadRequest(new { mensagem = "Email já cadastrado" });
        }

        usuario.Nome = request.Nome ?? usuario.Nome;
        usuario.Email = request.Email ?? usuario.Email;
        usuario.Telefone = request.Telefone ?? usuario.Telefone;
        usuario.Ativo = request.Ativo ?? usuario.Ativo;
        usuario.DataAtualizacao = DateTime.UtcNow;

        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        _logger.LogInformation("PUT: Usuário {Id} atualizado", id);
        return Ok(usuario);
    }

    /// <summary>
    /// Deleta um usuário
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("DELETE: Usuário {Id} não encontrado", id);
            return NotFound(new { mensagem = "Usuário não encontrado" });
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        _logger.LogInformation("DELETE: Usuário {Id} removido", id);
        return Ok(new { mensagem = "Usuário removido com sucesso" });
    }
}

public class CreateUsuarioRequest
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefone { get; set; }
}

public class UpdateUsuarioRequest
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public bool? Ativo { get; set; }
}