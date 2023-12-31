using MassTransit;
using FluentValidation;
using MediatR;
using System.Reflection;
using Produtor.Dominio.Command.CreateUsuario;
using Produtor.Repositorio.Repositorio;
using Produtor.Repositorio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.B

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>().Reverse();
builder.Services.AddScoped<IRequestHandler<CreateUsuarioCommand, string>, CreateUsuarioHandler>();
builder.Services.AddTransient<IValidator<CreateUsuarioCommand>, CreateUsuarioValidator>();

//config do RabbitMQ
var configuration = builder.Configuration;

var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
builder.Services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(conexao);
    });
});

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