using Microsoft.AspNetCore.Rewrite;

// Orientações sobre certificados autoassinados
/*
Remover os certificados existentes com o comando: 
# dotnet dev-certs https --clean
Confiar no certificado com o comando: 
# dotnet dev-certs https --trust
*/

var builder = WebApplication.CreateBuilder(args);

#region Serviços

// Adicionando serviços os container
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Redireciona requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Adiciona um componente de middleware que previne ataques 
// de falsificação de solicitação entre sites (CSRF)
app.UseAntiforgery();

#region Middlewares
/*

// Middleware não-terminal
app.Use(async (context, next) => {
    await context.Response.WriteAsync("* Executando o primeiro middleware\n");

    // Chama o próximo middleware
    await next.Invoke();

    await context.Response.WriteAsync("* Segunda mensagem do primeiro middleware\n");

});

*/

app.Use(async (context, next) => {
    /*
        Esta sequência foi escolhida para que o próximo middleware seja executado (app.UseRewriter),
        possibilitando a captura suas informações de resposta "inclusive o redirecionamento" contidas no contexto HTTP,
        exibindo-as no console da aplicação
    */
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");    
});

#endregion

#region Redirecionamento

// Adiciona um componente de middleware de regravador de URL que redireciona solicitações 
// de /history para /about. O método AddRedirect() usa dois parâmetros: um padrão de expressão regular 
// para corresponder ao caminho da solicitação e o caminho de substituição para o qual redirecionar.
app.UseRewriter(new RewriteOptions().AddRedirect("histor[A-Za-z]","about"));

#endregion

// Usado para mapear endpoints
app.MapGet("/", () => "Bem-vindo à Contoso!");
app.MapGet("/about", () => "Contoso was founded in 2000.");
app.MapGet("/history", () => "Endpoint que exibe o history");

// Executa o aplicativo
app.Run();
