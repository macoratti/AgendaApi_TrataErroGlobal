# PLAN - AgendaApi

## Visão Geral

Plano detalhado de implementação da API de Agenda seguindo as especificações definidas no arquivo `SPEC.md`.

## Fases de Implementação

### Fase 1: Configuração do Projeto

1. Criar o projeto `AgendaApi` usando o template ASP.NET Core Web API no .NET 10.
2. Adicionar os pacotes NuGet necessários:
   - Microsoft.EntityFrameworkCore.Sqlite
   - Swashbuckle.AspNetCore (se necessário)
3. Configurar a connection string do SQLite no `appsettings.json`.
4. Registrar DbContext, Controllers e Swagger no `Program.cs`.
5. Criar a estrutura de pastas `Domain`, `Application`, `Infrastructure` e `API`.

### Fase 2: Camada de Domínio e Infraestrutura

1. Criar a entidade `Contato` (sem Data Annotations).
2. Criar os Enums `Sexo` e `Status`.
3. Criar o `AgendaDbContext` com `DbSet<Contato>`.
4. Implementar **todo o mapeamento** da entidade `Contato` usando **Fluent API** dentro do método `OnModelCreating`.
5. Implementar inicialização do banco com `EnsureCreated` ao executar a aplicação.
6. Implementar seed de dados com 3 contatos fixos quando a tabela estiver vazia.
7. Não usar migrations para criação ou atualização do banco.

### Fase 3: Camada de Apresentação (API)

1. Criar o `ContatosController`.
2. Implementar os 5 endpoints CRUD conforme especificado no SPEC.md.
3. Adicionar tratamento de exceções (`try/catch`) em cada endpoint:
   - `ArgumentException` → 400
   - `KeyNotFoundException` → 404
   - `InvalidOperationException` → resposta adequada
   - Exceções genéricas → 500

### Fase 4: Testes e Validação

1. Executar a aplicação.
2. Validar todos os endpoints através da interface do **Swagger**.
3. Testar cenários de erro (e-mail duplicado, ID inexistente, etc.).

## Decisões Técnicas

- Utilizar **Fluent API** exclusivamente para mapeamento.
- Utilizar `EnsureCreated` para criação automática do banco.
- Não utilizar migrations.
- Popular o banco com 3 contatos fixos na inicialização quando não houver contatos cadastrados.
- Manter o código limpo e organizado em pastas (`Domain`, `Application`, `Infrastructure`, `API`).
- Priorizar clareza e manutenibilidade.
- Tratamento de exceções centralizado nos controllers (conforme requisito).

## Próximos Passos

Usar o arquivo `TASKS.md` como checklist granular para execução da implementação.
