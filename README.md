# 📒 Agenda API - ASP.NET Core Web API

Este projeto demonstra a criação de uma **API REST** usando **ASP.NET Core (.NET 10)** com **Entity Framework Core 10** e banco de dados **SQLite** para gerenciamento de contatos de uma agenda.

A aplicação implementa um CRUD completo utilizando Controllers, Fluent API e tratamento global de exceções com `IExceptionHandler` e `ProblemDetails` seguindo a **RFC 7807**.

---

## 🚀 Visão Geral

A aplicação permite:

- ✅ Cadastrar contatos  
- ✅ Consultar contatos  
- ✅ Atualizar contatos  
- ✅ Remover contatos  
- ✅ Persistir dados com SQLite  
- ✅ Exibir endpoints via Swagger  
- ✅ Padronizar respostas de erro usando `ProblemDetails`  
- ✅ Centralizar o tratamento global de exceções  

---

## 🏗️ Arquitetura

O projeto segue uma estrutura simples organizada em camadas:

```text
Agenda
└── AgendaApi
    ├── Controllers
    │   └── ContatosController
    ├── Data
    │   └── AgendaDbContext
    ├── Entities
    │   └── Contato
    ├── Application
    │   ├── IContatoService
    │   └── ContatoService
    ├── Exceptions
    │   └── AgendaExceptionHandler
    ├── Program.cs
    └── appsettings.json

## 🧩 Entidade Contato

A agenda utiliza a seguinte entidade:

```csharp
public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Sexo { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Status { get; set; }
}

## 💾 Banco de Dados

A aplicação utiliza **SQLite** com o banco:

```text
Agenda.db

O banco e a tabela Contatos são criados automaticamente utilizando:
csharp

context.Database.EnsureCreated();

O projeto também utiliza Seed Data com registros iniciais através do método:
csharp

HasData()

## 🌐 Endpoints da API

| Método   | Endpoint               | Descrição                 |
|----------|------------------------|---------------------------|
| GET      | `/api/contatos`        | Obter todos os contatos   |
| GET      | `/api/contatos/{id}`   | Obter contato por Id      |
| POST     | `/api/contatos`        | Criar novo contato        |
| PUT      | `/api/contatos/{id}`   | Atualizar contato         |
| DELETE   | `/api/contatos/{id}`   | Remover contato           |

## ⚠️ Tratamento Global de Exceções

A aplicação utiliza o recurso moderno de tratamento global de exceções do ASP.NET Core através da interface:

```csharp
IExceptionHandler

A implementação centraliza todo o tratamento de erros na classe:
csharp

AgendaExceptionHandler

Isso elimina a necessidade de blocos try/catch espalhados pelos endpoints.

### 🧠 Exceções mapeadas

| Exceção                  | HTTP Status               |
|--------------------------|---------------------------|
| `ArgumentException`      | 400 Bad Request           |
| `KeyNotFoundException`   | 404 Not Found             |
| `InvalidOperationException` | 409 Conflict          |
| `Exception`              | 500 Internal Server Error |

## 📦 ProblemDetails — RFC 7807

As respostas de erro da API utilizam o padrão **RFC 7807** através do recurso `ProblemDetails`.

### Exemplo de resposta:

```json
{
  "type": "about:blank",
  "title": "Recurso não encontrado",
  "status": 404,
  "detail": "Contato não encontrado.",
  "instance": "/api/contatos/10"
}

### 🧠 Exceções mapeadas

| Exceção                  | HTTP Status               |
|--------------------------|---------------------------|
| `ArgumentException`      | 400 Bad Request           |
| `KeyNotFoundException`   | 404 Not Found             |
| `InvalidOperationException` | 409 Conflict          |
| `Exception`              | 500 Internal Server Error |

## 📦 ProblemDetails — RFC 7807

As respostas de erro da API utilizam o padrão **RFC 7807** através do recurso `ProblemDetails`.

### Exemplo de resposta:

```json
{
  "type": "about:blank",
  "title": "Recurso não encontrado",
  "status": 404,
  "detail": "Contato não encontrado.",
  "instance": "/api/contatos/10"
}

## ⚙️ Configuração do tratamento global

Registro dos serviços:

```csharp
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<AgendaExceptionHandler>();

## ⚙️ Configuração do tratamento global

Registro dos serviços:

```csharp
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<AgendaExceptionHandler>();

# Swagger

Os endpoints são exibidos automaticamente através do Swagger no ambiente de desenvolvimento.

Ao executar a aplicação, o navegador é iniciado automaticamente exibindo a interface Swagger.

## ▶️ Executando a aplicação

### Restaurar os pacotes

```bash
dotnet restore

 Executar a aplicação:

```bash
dotnet run

## 🛠️ Tecnologias utilizadas

- ASP.NET Core (.NET 10)
- Entity Framework Core 10
- SQLite
- Swagger / OpenAPI
- Controllers API
- Fluent API
- ProblemDetails
- IExceptionHandler

## 🤖 Desenvolvimento com Codex + Spec-Driven Development

Este projeto foi gerado utilizando:

- **Codex**
- Abordagem **Spec-Driven Development (SDD)**

A aplicação foi criada a partir de especificações previamente definidas em um arquivo:

```text
SPEC.md
