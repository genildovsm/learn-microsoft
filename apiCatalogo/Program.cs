using System.Reflection;
using System.Text.Json.Serialization;
using apiCatalogo.Context;
using apiCatalogo.Extensions;
using apiCatalogo.Filters;
using apiCatalogo.Logging;
using apiCatalogo.Middlewares;
using apiCatalogo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o =>
{
    // Filtro global para exceções não tratadas
    o.Filters.Add(typeof(ApiExceptionFilter));
})
// Tratamento da referência cíclica na serialização de objetos
.AddJsonOptions(o => 
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    #region Configuração de Documentação do Swagger

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "apiCatalogo",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Genildo Martins",
            Email = "genildovsm@gmail.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
    
    #endregion
});

string mySqlConnection = builder.Configuration["DefaultConnection"]!;

builder.Services.AddDbContext<ApiCatalogoDbContext>(options =>
{
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

#region Registro dos repositórios como serviço

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

#endregion

builder.Services.AddScoped<ApiLoggingFilter>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfig
{
    LogLevel = LogLevel.Information
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Middleware customizado
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
