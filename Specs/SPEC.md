# SPEC - AgendaApi

## 1. Objetivo

Desenvolver uma **API REST** chamada `AgendaApi` utilizando **ASP.NET Core Web API no .NET 10**, com Entity Framework Core e banco de dados **SQLite**, para gerenciar uma agenda de contatos com operações básicas de CRUD.

## 2. Entidade Principal - Contato

### Campos da Entidade:

| Campo              | Tipo              | Regras de Validação                          | Obrigatório |
|--------------------|-------------------|----------------------------------------------|-----------|
| `Id`               | `int`             | Chave Primária, Auto-incremento              | Sim       |
| `Nome`             | `string`          | Máximo 150 caracteres                        | Sim       |
| `Email`            | `string`          | Formato válido de e-mail, deve ser único     | Sim       |
| `Telefone`         | `string`          | Máximo 20 caracteres                         | Sim       |
| `Sexo`             | `enum`            | Masculino, Feminino, Outro                   | Sim       |
| `DataNascimento`   | `DateOnly`        | Data válida, não pode ser futura             | Não       |
| `Status`           | `enum`            | Ativo, Inativo (default: Ativo)              | Sim       |

## 3. Enums

- **Sexo**: `Masculino`, `Feminino`, `Outro`
- **Status**: `Ativo`, `Inativo`

## 4. Requisitos Técnicos

- Framework: **.NET 10**
- Template: **ASP.NET Core Web API**
- ORM: **Entity Framework Core**
- Banco de Dados: **SQLite**
- Mapeamento: **Exclusivamente Fluent API** (proibido usar Data Annotations na entidade)
- Documentação: **Swagger** habilitado em ambiente de desenvolvimento
- Controllers: Padrão ASP.NET Core
- Tratamento de Erros: Estruturado com `try/catch` nos endpoints
- Criação do banco: usar `EnsureCreated` ao iniciar a aplicação
- Migrations: não devem ser usadas
- Seed de dados: popular a tabela de contatos com 3 contatos fixos quando o banco estiver vazio

## 5. Endpoints (CRUD)

| Método | Endpoint                    | Descrição                     | Sucesso     | Principais Erros Esperados     |
|--------|-----------------------------|-------------------------------|-------------|--------------------------------|
| GET    | `/api/contatos`             | Listar todos os contatos      | 200         | 500                            |
| GET    | `/api/contatos/{id}`        | Buscar contato por ID         | 200         | 404, 500                       |
| POST   | `/api/contatos`             | Criar novo contato            | 201         | 400, 500                       |
| PUT    | `/api/contatos/{id}`        | Atualizar contato existente   | 204         | 400, 404, 500                  |
| DELETE | `/api/contatos/{id}`        | Remover contato               | 204         | 404, 500                       |

## 6. Regras de Negócio

- Não deve permitir e-mail duplicado.
- `DataNascimento` não pode ser uma data futura.
- Ao criar um contato, o `Status` deve ser `Ativo` por padrão.
- Remoção deve ser física (Delete do banco).
- Ao executar o projeto, o banco SQLite deve ser criado automaticamente com `EnsureCreated`.
- Se a tabela de contatos estiver vazia, devem ser inseridos 3 contatos iniciais fixos.

## 7. Seed Inicial

A aplicação deve incluir seed com 3 contatos fixos para carga inicial do banco. Os dados devem respeitar as regras da entidade:

| Nome             | Email                    | Telefone       | Sexo      | DataNascimento | Status  |
|------------------|--------------------------|----------------|-----------|----------------|---------|
| Ana Silva        | ana.silva@email.com      | 11999990001    | Feminino  | 1990-05-12     | Ativo   |
| Bruno Santos     | bruno.santos@email.com   | 21999990002    | Masculino | 1985-09-23     | Ativo   |
| Carla Oliveira   | carla.oliveira@email.com | 31999990003    | Feminino  | 1998-02-04     | Inativo |

## 8. Tratamento de Exceções

- `ArgumentException` → **400 Bad Request**
- `KeyNotFoundException` → **404 Not Found**
- `InvalidOperationException` → **409 Conflict** ou **400 Bad Request** (conforme o caso)
- Outras exceções não tratadas → **500 Internal Server Error**

---
