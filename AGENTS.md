# AgendaApi

## Objetivo

Criar uma API ASP.NET Core Web API no .NET 10 chamada `AgendaApi`, usando Entity Framework Core com banco SQLite, para realizar CRUD basico de uma agenda de enderecos.

## Entidade Principal

A agenda sera representada pela entidade `Contato`, contendo:

- `Id`
- `Nome`
- `Email`
- `Telefone`
- `Sexo`
- `DataNascimento`
- `Status`

O campo `Status` deve representar os estados `Ativo` e `Inativo`.

## Requisitos Tecnicos

- Usar ASP.NET Core Web API no .NET 10.
- Usar Controllers.
- Usar Entity Framework Core.
- Usar SQLite como banco de dados.
- Exibir os endpoints na interface do Swagger no ambiente de desenvolvimento.
- Nao usar Data Annotations.
- Fazer todo o mapeamento da entidade com Fluent API em `OnModelCreating`.
- Usar `EnsureCreated` para criar o banco ao executar o projeto.
- Nao usar Migrations.
- Popular a tabela de contatos com seed inicial de 3 contatos fixos quando o banco estiver vazio.
- Implementar tratamento de erros com blocos `try/catch` nos endpoints.

## Mapeamento de Excecoes

As excecoes tratadas devem ser convertidas para respostas HTTP adequadas:

- `InvalidOperationException`
- `ArgumentException`
- `KeyNotFoundException`
- Erro interno de servidor para excecoes nao tratadas.

## Escopo Inicial

Implementar CRUD basico para `Contato`:

- Criar contato.
- Listar contatos.
- Buscar contato por `Id`.
- Atualizar contato.
- Remover contato.
