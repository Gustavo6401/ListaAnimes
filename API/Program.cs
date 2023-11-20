using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Services;
using Infraestrutura.Context;
using Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Servicos;
using AutoMapper;
using Dominio.DTOs.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Comentei essas linhas para n�o quebrar o DDD e o princ�pio de SOLID.
/*var sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AnimeContext>(options =>
    options.UseSqlServer(sqlServerConnection, 
        b => b.MigrationsAssembly("API")));*/

builder.Services.AddSingleton(new AnimeContext());
builder.Services.AddSingleton(MappingProfile.Initialize());
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IAnimeServices, AnimeServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
