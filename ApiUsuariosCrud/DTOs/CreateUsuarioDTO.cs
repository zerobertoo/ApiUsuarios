using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.DTOs;

public class CreateUsuarioDTO
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "Telefone inválido")]
    public string? Telefone { get; set; }
}
