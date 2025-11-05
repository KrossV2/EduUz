using System;
using EduUz.Application.DiContainer;
using EduUz.Application.Settings;
using EduUz.Infrastructure.Database;
using EduUz.Infrastructure.DiContainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Di
builder.Services.AddRepositories()
    .AddDatabase(configurations);


// Jwt
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EuUz",
        Version = "v1",
        Description = "EduUz",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "nasriddinovadildora45@gmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Your License Name",
            Url = new Uri("https://example.com/license") 
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {your token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2", 
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() 
                    }
            });
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    // Render/Docker uchun eng yaxshi yechim: barcha KnownProxies va Networks tozalash.
    // Shunda ilova har qanday kelgan X-Forwarded-Proto sarlavhasiga ishonadi (Render uchun muhim).
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

var app = builder.Build();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EduUzDbContext>();
    Console.WriteLine(context.Database.GetDbConnection().ConnectionString);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
