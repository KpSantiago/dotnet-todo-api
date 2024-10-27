# Todo-List API

### Descrição

API de uma todo list simples para testar minhas hablidades em `.NET`, `ASP.NET` e `Entity Framework`

#### Tecnolgias

- C#
- .NET 6
- ASP.NET
- Entity Framework
- SQL Server
- Swagger

#### Conceitos

- SOLID principles
- Clean Architecture

## Rotas

#### Lists

| Method   | Path               | Descrição                          | Parameters |
| -------- | ------------------ | ---------------------------------- | ---------- |
| `POST`   | /lists             | Cria uma nova lista de tarefas     | #          |
| `GET`    | /lists             | Resgata todas as listas de tarefas | #          |
| `PATCH`  | /lists/{id}/update | Edita uma determinada tarefa       | id: string |
| `GET`    | /lists/{id}        | Resgata uma única lista            | id: string |
| `DELETE` | /lists/{id}/delete | Remove uma determinada lista       | id: string |

#### Tasks

| Method   | Path               | Descrição                         | Parameters |
| -------- | ------------------ | --------------------------------- | ---------- |
| `POST`   | /tasks             | Cria uma nova task de tarefas     | #          |
| `GET`    | /tasks             | Resgata todas as tasks de tarefas | #          |
| `PATCH`  | /tasks/{id}/update | Edita uma determinada tarefa      | id: string |
| `DELETE` | /tasks/{id}/delete | Remove uma determinada tarefa     | id: string |
