using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuariosCrud.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed inicial com datas FIXAS (não dinâmicas)
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nome = "José Silva",
                Email = "jose@example.com",
                DataCadastro = new DateTime(2024, 1, 15, 10, 30, 0), // Data fixa
                Ativo = true
            },
            new Usuario
            {
                Id = 2,
                Nome = "Maria Santos",
                Email = "maria@example.com",
                DataCadastro = new DateTime(2024, 2, 20, 14, 45, 0), // Data fixa
                Ativo = true
            }
        );
    }
}