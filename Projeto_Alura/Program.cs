using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Infrastructure.Data;
using Projeto_Alura.Infrastructure.Injection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();



//conexao com banco de dados postgresql
builder.Services.AddDbContext<AluraDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AluraConnection")));

//Injecao de dependencias
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 
app.UseHttpsRedirection();

app.Run();


