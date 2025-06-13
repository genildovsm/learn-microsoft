- Incluir as referências ao **EntityFrameworkCore** e ao provedor **Pomelo** para o Mysql.

~~~
dotnet add package Pomelo.EntityFrameworkCore.Mysql
dotnet add package Microsoft.EntityFramewrok.Design
~~~

- Verificar se a ferramenta **EF Core Tools** está instalada no sistema.

~~~
dotnet ef
~~~

- Incluir a ferramenta EF Core Tools (Microsoft.EntityFrameworkCore.Tools) ou atualizá-la.

~~~
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
~~~

### Comandos para aplicar migrations usando EF Core Tools

~~~
# Cria o sript de migração
dotnet ef migrations [nome]

# Remove o script de migração desfazendo as alterações da migração anterior
dotnet ef migrations remove [nome]

# Gera o banco de dados e as tabelas com base no script
dotnet ef database update
~~~

### Alternativa para aplicar migrations usando Package Manager Console

~~~
# Cria o script de migração
add-migration [nome]

# Remove o script de migração desfazendo as alterações da migração anterior
remove-migration [nome]

# Gera o banco de dados e as tabelas com base no script
database-update
~~~

+ [Data Annotations para sobreescrever as convenções do EF Core](Documentacao/convencoes-do-entity-framework-core.md)

## Roteiro de testes com xUnit - Testes de unidade

- Incluir o projeto de testes de unidade **ApiCatalogo.Tests** no projeto **APICatalogo** usando o template **xUnit Test Project**.
- Incluir no projeto de testes o pacote nuget **FluentAssertions**.
- Incluir uma referência ao projeto **APICatalogo** no projeto de testes.
- Criar no projeto de testes a classe **ProdutosUnitTestController** e configurar o ambiente para testar os endpoints do controlador **ProdutosController** da **APICatalogo.**
- Criar as classes para testar os endpoints Get, Post, Put e Delete que implementam a interface **IClassFixture<ProdutosUnitTestController>**.
