using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PersonService>();


var app = builder.Build();

app.MapGet("/", (PersonService personService) => {
    return personService.GetPersonName();
});

app.Run();
