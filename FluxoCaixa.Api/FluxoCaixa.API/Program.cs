using FluxoCaixa.API.EndPoints.LogEndPoint;
using FluxoCaixa.API.EndPoints.Movimentos;
using FluxoCaixa.API.EndPoints.Security;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Application.Services;
using FluxoCaixa.Data.Context;
using FluxoCaixa.Data.Repositories;
using FluxoCaixa.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using Pomelo.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Minimal API Fluxo de Caixa  - JWT Authentication with Swagger",
    Description = "Implementing JWT Authentication in Minimal API"
  
};




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});


///Dependency injection 
builder.Services.AddScoped<IMovimentosService, MovimentoService>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<ILogsService, LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IMovimentoRepository, MovimentoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql("Server=localhost;DataBase=FluxoCaixa;Uid=root;Pwd=@mmec262105", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
});


builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMovimentoEndPoint();
app.MapLogEndpoints();
app.MapSecurityEndPoint(builder);


app.Run();

