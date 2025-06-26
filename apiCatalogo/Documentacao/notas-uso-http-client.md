## Problemas da classe HttpClient

#### Na verdade não são problemas da classe HttpClient mas a forma como ela é usada

Embora essa classe seja **Disposable**, usá-la com a instrução **using** não é a melhor opção porque, mesmo quando você descarta o objeto **HttpClient**, o soquete subjacente não é liberado imediatamente e pode causar um problema sério chamado **esgotamento de soquetes**. [artigo](https://www.macoratti.net/19/01/netcore_httpclient2.htm)  
  
Outro problema com o HttpClient pode ocorrer quando ela for usada como um objeto *singleton* ou *estático*. Nesse caso, um HttpClient singleton ou estático não respeitará as alterações de DNS. [artigo](http://byterot.blogspot.com/2016/07/singleton-httpclient-dns.html)  
  
>**Solução:** Usar a interface *IHttpClientFactory* e as suas implementações disponíveis a partir do .NET Core 2.1
  
## HttpClientFactory

- Fornece um local central para nomear e configurar HttpClients lógicos.
- Codificar o conceito de middleware de saída por meio da *delegação de handlers* no HttpClient e da implementação de middleware baseado em **Polly**, aproveitando as políticas da **Polly** e garantir a resiliência. [artigo](https://www.pollydocs.org/index.html)
- Gerenciar o tempo de vida de **HttpClientMessageHandlers** para evitar o problema mencionado que pode ocorrer ao gerenciar o tempo de vida do HttpClient por conta própria.
- O **HttpClientFactory** gerencia o tempo de vida dos handlers para que tenhamos um pool deles que podem ser reutilizados, enquanto também os rotaciona para que o DNS não fique obsoleto.

## Como usar

- Uso básico
- Usar clientes nomeados
- Usar clientes tipados
- Usar clientes gerados

Instalar o pacote **Microsoft.Extensions.Http**

~~~
$ install-package Microsoft.Extensions.Http
~~~

ou

~~~
$ dotnet add package Microsoft.Extensions.Http --version 6.0.0
~~~

## HttpClientFactory : Uso básico

Registrar o serviço **IHttpClientFactory** usando o método de extensão **AddHttpClient**.

~~~
builder.Services.AddHttpClient();
~~~

Usar a instância do **IHttpClientFactory** injetando-a onde deseja usar.

~~~
public class MeuController : Controller
{
	private readonly IHttpClientFactory _clientFactory;
	
	public MeuController(IHttpClientFactory httpClientFactory)
	{
		_clientFactory = httpClientFactory;
	}
	
	...
}
~~~

Na action.

~~~
public async Task Basic()
{	
	var client = _clientFactory.CreateClient();

	...
}
~~~

## HttpClientFactory : Cliente nomeado

Registrar o **IHttpClientFactory** usando o método de extensão **AddHttpClient**.

~~~
builder.Services.AddHttpClient("Nome", httpClient => {
	httpClient.BaseAddress = new Uri("https://localhost:7211/")
	// outras configurações
});
~~~

Usar a instância do **IHttpClientFactory** injetando-a onde deseja usar.

~~~
public class MeuController : Controller
{
	private readonly IHttpClientFactory _clientFactory;
	
	public MeuController(IHttpClientFactory httpClientFactory)
	{
		_clientFactory = httpClientFactory;
	}
	
	...
}
~~~

Na action.

~~~
public async Task Basic()
{	
	var client = _clientFactory.CreateClient("Nome");

	...
}
~~~
