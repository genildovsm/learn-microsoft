using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var pathLogConfig = Path.Combine(Directory.GetCurrentDirectory(), "logging.json");

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(pathLogConfig, optional: false)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    //.WriteTo.Console(
    //    restrictedToMinimumLevel: LogEventLevel.Information, 
    //    outputTemplate: logTemplate)

    //.WriteTo.File(
    //    "Logs/logs.log",
    //    restrictedToMinimumLevel: LogEventLevel.Information,
    //    rollingInterval: RollingInterval.Day,
    //    outputTemplate: logTemplate)

    //.Enrich.FromLogContext() 

    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
