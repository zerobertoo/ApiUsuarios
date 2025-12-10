using ApiUsuarios.DTOs;
using ApiUsuarios.Interfaces;
using ApiUsuarios.Models;
using AutoMapper;

namespace ApiUsuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(IUsuarioRepository repository, IMapper mapper, ILogger<UsuarioService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
    {
        _logger.LogInformation("Recuperando todos os usuários");
        var usuarios = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<IEnumerable<UsuarioDTO>> GetActiveUsuariosAsync()
    {
        _logger.LogInformation("Recuperando usuários ativos");
        var usuarios = await _repository.GetActivesAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO?> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("Usuário {Id} não encontrado", id);
            return null;
        }
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<(UsuarioDTO? dto, string? error)> CreateUsuarioAsync(CreateUsuarioDTO createDto)
    {
        _logger.LogInformation("Tentativa de criação de novo usuário com email: {Email}", createDto.Email);

        if (await _repository.ExistsByEmailAsync(createDto.Email))
        {
            _logger.LogWarning("Email {Email} já cadastrado", createDto.Email);
            return (null, "Email já cadastrado");
        }

        var usuario = _mapper.Map<Usuario>(createDto);
        usuario.DataCadastro = DateTime.UtcNow;
        usuario.Ativo = true;

        var novoUsuario = await _repository.AddAsync(usuario);

        _logger.LogInformation("Novo usuário criado com ID {Id}", novoUsuario.Id);
        return (_mapper.Map<UsuarioDTO>(novoUsuario), null);
    }

    public async Task<(UsuarioDTO? dto, string? error)> UpdateUsuarioAsync(int id, UpdateUsuarioDTO updateDto)
    {
        var usuario = await _repository.GetByIdAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("Usuário {Id} não encontrado para atualização", id);
            return (null, "Usuário não encontrado");
        }

        if (updateDto.Email != null && updateDto.Email != usuario.Email)
        {
            if (await _repository.ExistsByEmailExcludingIdAsync(updateDto.Email, id))
            {
                _logger.LogWarning("Email {Email} já cadastrado por outro usuário", updateDto.Email);
                return (null, "Email já cadastrado por outro usuário");
            }
        }

        _mapper.Map(updateDto, usuario);
        usuario.DataAtualizacao = DateTime.UtcNow;

        await _repository.UpdateAsync(usuario);

        _logger.LogInformation("Usuário {Id} atualizado", id);
        return (_mapper.Map<UsuarioDTO>(usuario), null);
    }

    public async Task<(bool success, string? error)> DeleteUsuarioAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);
        if (usuario == null)
        {
            _logger.LogWarning("Usuário {Id} não encontrado para remoção", id);
            return (false, "Usuário não encontrado");
        }

        await _repository.DeleteAsync(usuario);

        _logger.LogInformation("Usuário {Id} removido", id);
        return (true, null);
    }
}
