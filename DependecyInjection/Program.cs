using DependecyInjection.Interfaces;
using DependecyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddSingleton<IWelcomeService, WelcomeService>();

#endregion

var app = builder.Build();

//app.UseHttpsRedirection();

app.MapGet("/", (IWelcomeService welcomeService) => {
    return welcomeService.GetWelcomeMessage();
});

app.Run();
