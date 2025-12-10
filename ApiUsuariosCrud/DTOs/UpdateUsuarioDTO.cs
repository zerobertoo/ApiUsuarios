using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.DTOs;

public class UpdateUsuarioDTO
{
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
    public string? Nome { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Telefone inválido")]
    public string? Telefone { get; set; }

    public bool? Ativo { get; set; }
}
