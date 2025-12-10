using ApiUsuarios.Models;

namespace ApiUsuarios.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<IEnumerable<Usuario>> GetActivesAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario> AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(Usuario usuario);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByEmailExcludingIdAsync(string email, int id);
}
