using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Application.Services;
using Projeto_Alura.Infrastructure.Data;
using Projeto_Alura.Infrastructure.Injection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Projeto_Alura.Middlewres;
using Projeto_Alura.Infrastructure.Auth;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(w =>
{
    w.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto Alura API",
        Description = "API para gerenciamento de cursos e matrículas",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Welinton Gomes",
            Email = "batistawelinton54@gmail.com"
        }
    });
    w.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Insira o token de Acesso!.",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    });
    w.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    w.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// ✅ Registra JwtSettings corretamente
var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();
builder.Services.AddSingleton(jwtSettings);

// Segurança
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,       
        ValidAudience = jwtSettings.Audience,   
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.SecretKey)) 
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["access_token"];
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = "X-CSRF-TOKEN";
    options.HeaderName = "X-CSRF-TOKEN-HEADER";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("https://localhost:4200")
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

// Banco de dados
builder.Services.AddDbContext<AluraDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AluraConnection")));

// Injeção de dependências
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IUsersServices, UsersService>();
builder.Services.AddScoped<ICursosServices, CursosService>();
builder.Services.AddScoped<IMatriculasServices, MatriculasService>();
builder.Services.AddScoped<ITokenServices, TokenService>();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapDefaultEndpoints();
app.MapControllers();
app.Run();