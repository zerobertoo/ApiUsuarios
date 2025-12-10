using ApiUsuarios.DTOs;
using ApiUsuarios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(IUsuarioService usuarioService, ILogger<UsuariosController> logger)
    {
        _usuarioService = usuarioService;
        _logger = logger;
    }

    /// <summary>
    /// Retorna todos os usuários
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
    {
        _logger.LogInformation("GET: Recuperando todos os usuários");
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    /// <summary>
    /// Retorna apenas usuários ativos
    /// </summary>
    [HttpGet("ativos")]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuariosAtivos()
    {
        _logger.LogInformation("GET: Recuperando usuários ativos");
        var usuarios = await _usuarioService.GetActiveUsuariosAsync();
        return Ok(usuarios);
    }

    /// <summary>
    /// Retorna um usuário específico pelo ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound(new { mensagem = "Usuário não encontrado" });
        }

        return Ok(usuario);
    }

    /// <summary>
    /// Cria um novo usuário
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> PostUsuario([FromBody] CreateUsuarioDTO createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (usuarioDto, error) = await _usuarioService.CreateUsuarioAsync(createDto);

        if (error != null)
        {
            return BadRequest(new { mensagem = error });
        }

        return CreatedAtAction(nameof(GetUsuario), new { id = usuarioDto!.Id }, usuarioDto);
    }

    /// <summary>
    /// Atualiza um usuário existente
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, [FromBody] UpdateUsuarioDTO updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (usuarioDto, error) = await _usuarioService.UpdateUsuarioAsync(id, updateDto);

        if (error == "Usuário não encontrado")
        {
            return NotFound(new { mensagem = error });
        }
        else if (error != null)
        {
            return BadRequest(new { mensagem = error });
        }

        return Ok(usuarioDto);
    }

    /// <summary>
    /// Deleta um usuário
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var (success, error) = await _usuarioService.DeleteUsuarioAsync(id);

        if (!success)
        {
            return NotFound(new { mensagem = error });
        }

        return Ok(new { mensagem = "Usuário removido com sucesso" });
    }
}
