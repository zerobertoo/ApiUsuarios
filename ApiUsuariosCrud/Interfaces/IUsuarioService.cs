using ApiUsuarios.DTOs;

namespace ApiUsuarios.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync();
    Task<IEnumerable<UsuarioDTO>> GetActiveUsuariosAsync();
    Task<UsuarioDTO?> GetUsuarioByIdAsync(int id);
    Task<(UsuarioDTO? dto, string? error)> CreateUsuarioAsync(CreateUsuarioDTO createDto);
    Task<(UsuarioDTO? dto, string? error)> UpdateUsuarioAsync(int id, UpdateUsuarioDTO updateDto);
    Task<(bool success, string? error)> DeleteUsuarioAsync(int id);
}
