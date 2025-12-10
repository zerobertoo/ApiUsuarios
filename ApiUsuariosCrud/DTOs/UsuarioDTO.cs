namespace ApiUsuarios.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = null!;
    public string? Telefone { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
