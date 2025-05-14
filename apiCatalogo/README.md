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