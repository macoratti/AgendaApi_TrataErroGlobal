# TASKS - AgendaApi

Checklist de execucao para implementar a API conforme `SPEC.md`, `PLAN.md` e `AGENTS.md`.

## 1. Preparacao do Projeto

- [x] Criar o projeto `AgendaApi` com ASP.NET Core Web API no .NET 10.
- [x] Confirmar que o projeto usa Controllers.
- [x] Remover arquivos de exemplo do template, se existirem.
- [x] Configurar execucao em ambiente de desenvolvimento.
- [x] Criar a pasta `Domain`.
- [x] Criar a pasta `Application`.
- [x] Criar a pasta `Infrastructure`.
- [x] Criar a pasta `API`.

## 2. Pacotes e Configuracao

- [x] Adicionar pacote `Microsoft.EntityFrameworkCore.Sqlite`.
- [x] Confirmar pacote/configuracao do Swagger.
- [x] Criar connection string SQLite em `appsettings.json`.
- [x] Registrar `AgendaDbContext` no container de DI.
- [x] Registrar Controllers no `Program.cs`.
- [x] Habilitar Swagger apenas em ambiente de desenvolvimento.
- [x] Configurar inicializacao do banco com `EnsureCreated` ao executar a aplicacao.
- [x] Garantir que migrations nao sejam usadas no projeto.

## 3. Dominio

- [x] Criar entidade `Contato` sem Data Annotations.
- [x] Criar enum `Sexo` com `Masculino`, `Feminino` e `Outro`.
- [x] Criar enum `Status` com `Ativo` e `Inativo`.
- [x] Definir propriedades de `Contato`: `Id`, `Nome`, `Email`, `Telefone`, `Sexo`, `DataNascimento` e `Status`.
- [x] Garantir que `DataNascimento` permita valor nulo.

## 4. Banco de Dados e EF Core

- [x] Criar `AgendaDbContext`.
- [x] Adicionar `DbSet<Contato>`.
- [x] Mapear `Contato` em `OnModelCreating` usando Fluent API.
- [x] Configurar `Id` como chave primaria e auto-incremento.
- [x] Configurar `Nome` como obrigatorio com tamanho maximo 150.
- [x] Configurar `Email` como obrigatorio com tamanho adequado e indice unico.
- [x] Configurar `Telefone` como obrigatorio com tamanho maximo 20.
- [x] Configurar conversao dos enums para armazenamento no SQLite.
- [x] Configurar `Status` com valor padrao `Ativo`.
- [x] Implementar seed com 3 contatos fixos.
- [x] Popular a tabela de contatos com o seed inicial somente quando estiver vazia.
- [x] Garantir que o banco SQLite e a tabela contatos sejam criados com `EnsureCreated`.

## 5. Regras de Negocio

- [x] Validar que `Nome`, `Email` e `Telefone` foram informados.
- [x] Validar formato basico de e-mail sem Data Annotations.
- [x] Validar que `DataNascimento` nao seja futura.
- [x] Validar e-mail duplicado antes de criar contato.
- [x] Validar e-mail duplicado antes de atualizar contato.
- [x] Usar remocao fisica no endpoint de delete.
- [x] Garantir que os 3 contatos fixos do seed respeitem e-mails unicos.

## 6. API, Controller e Endpoints

- [x] Criar `ContatosController` na pasta `API`.
- [x] Implementar `GET /api/contatos` retornando todos os contatos.
- [x] Implementar `GET /api/contatos/{id}` retornando contato por id.
- [x] Implementar `POST /api/contatos` criando contato e retornando `201 Created`.
- [x] Implementar `PUT /api/contatos/{id}` atualizando contato e retornando `204 No Content`.
- [x] Implementar `DELETE /api/contatos/{id}` removendo contato e retornando `204 No Content`.

## 7. Tratamento de Erros

- [x] Adicionar blocos `try/catch` nos endpoints.
- [x] Mapear `ArgumentException` para `400 Bad Request`.
- [x] Mapear `KeyNotFoundException` para `404 Not Found`.
- [x] Mapear `InvalidOperationException` para `409 Conflict` ou `400 Bad Request`, conforme o caso.
- [x] Mapear excecoes nao tratadas para `500 Internal Server Error`.
- [x] Retornar mensagens de erro claras e consistentes.

## 8. Validacao Manual

- [x] Executar `dotnet build`.
- [x] Executar a API localmente.
- [x] Abrir Swagger em ambiente de desenvolvimento.
- [x] Validar que o banco SQLite foi criado automaticamente sem migrations.
- [x] Validar que a listagem inicial retorna os 3 contatos fixos do seed.
- [x] Validar listagem de contatos.
- [x] Validar criacao de contato.
- [x] Validar busca por id existente.
- [x] Validar busca por id inexistente.
- [x] Validar atualizacao de contato.
- [x] Validar remocao de contato.
- [x] Validar erro de e-mail duplicado.
- [x] Validar erro de data de nascimento futura.

## 9. Criterios de Aceite

- [x] API chamada `AgendaApi` criada e executando.
- [x] CRUD de `Contato` funcionando.
- [x] SQLite configurado e persistindo dados.
- [x] Banco criado automaticamente com `EnsureCreated`.
- [x] Migrations nao utilizadas.
- [x] Seed inicial com 3 contatos fixos funcionando.
- [x] Fluent API usado como unico mecanismo de mapeamento.
- [x] Nenhuma Data Annotation usada na entidade.
- [x] Swagger exibindo endpoints em desenvolvimento.
- [x] Tratamento de excecoes conforme especificado.
