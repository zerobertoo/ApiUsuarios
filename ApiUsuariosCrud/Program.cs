using ApiUsuariosCrud.Data;
using Microsoft.EntityFrameworkCore;
using ApiUsuarios.Interfaces;
using ApiUsuarios.Repositories;
using ApiUsuarios.Services;
using ApiUsuarios.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=usuarios.db"));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

// Adicionando Repositório e Serviço
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();