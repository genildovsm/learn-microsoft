using System.Reflection;
using System.Text.Json.Serialization;
using apiCatalogo.Context;
using apiCatalogo.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Tratamento da referência cíclica na serialização de objetos

builder.Services.AddControllers()
    .AddJsonOptions(
        o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

#endregion

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
