## Etapas do projeto

Criar a pasta do projeto

~~~
dotnet new web -o MeuTodo -f net5.0
~~~

Instalar os pacotes para uso do Sqlite e Migrations respectivamente

~~~
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
~~~

### Testando a api

~~~bash
$ curl -s https://localhost:5001/Home | jq -C
{
  "controller": "Home",
  "action": "Index"
}
~~~

Cadastrando uma tarefa

~~~bash
$ curl -sX POST https://localhost:5001/Todo -H "Content-Type: application/json" -d '{"Title":"Primeira tarefa", "Done": true}'
~~~
