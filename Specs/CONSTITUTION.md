## 1. Princípios Gerais

- **Clareza acima de tudo**: Todo código, documentação e decisão deve ser clara e de fácil entendimento.
- **Consistência**: Manter padrões uniformes em todo o projeto.
- **Manutenibilidade**: Escrever código pensando que outra pessoa (ou um agente) terá que mantê-lo no futuro.
- **Qualidade > Velocidade**: Preferir soluções corretas e limpas do que rápidas e sujas.
- **Documentação é parte do código**: Nunca deixar código sem a devida documentação.

---

## 2. Regras Técnicas Obrigatórias

### 2.1. Arquitetura e Estrutura
- Seguir rigorosamente a separação de responsabilidades (`Domain`, `Application`, `Infrastructure`, `API`).
- Usar pastas conforme definido no `TASKS.md`.
- Nomes de classes, enums, controllers e pastas de código do projeto devem estar em **PascalCase**, respeitando arquivos padrão do .NET como `Program.cs`, `appsettings.json` e `.csproj`.
- O controller principal de contatos deve se chamar `ContatosController`.

### 2.2. Entity Framework
- **Proibido** usar Data Annotations na entidade `Contato`.
- Todo mapeamento deve ser feito exclusivamente via **Fluent API** no método `OnModelCreating`.
- Usar SQLite como banco de dados.
- Usar `EnsureCreated` para criar o banco automaticamente ao executar a aplicação.
- Não usar migrations.
- Popular o banco com seed inicial de 3 contatos fixos quando a tabela de contatos estiver vazia.

### 2.3. Tratamento de Erros
- **Não usar** middleware global de exceções.
- Todos os endpoints devem ter blocos `try/catch` explícitos.
- Mapear exceções conforme definido no `SPEC.md`:
  - `ArgumentException` → 400 Bad Request
  - `KeyNotFoundException` → 404 Not Found
  - `InvalidOperationException` → 400 ou 409
  - Exceções não tratadas → 500 Internal Server Error

### 2.4. API
- Usar convenções REST padrão.
- Habilitar Swagger apenas em ambiente de Development.
- Retornar os códigos HTTP corretos em cada operação.

---

## 3. Padrões de Código

- Seguir o estilo de código do .NET (nomenclatura em PascalCase/CamelCase).
- Métodos assíncronos devem usar o sufixo `Async`.
- Utilizar `record` ou classes simples quando apropriado.
- Evitar código duplicado (DRY).
- Manter métodos curtos e com responsabilidade única.

---

## 4. Documentação

- Todo arquivo de documentação deve seguir o padrão estabelecido:
  - `AGENTS.md` → Definições gerais do projeto e escopo inicial
  - `CONSTITUTION.md` → Regras gerais (este arquivo)
  - `SPEC.md` → Especificação detalhada
  - `PLAN.md` → Plano de implementação
  - `TASKS.md` → Checklist executável
- Manter todos os arquivos atualizados quando houver mudanças relevantes.

---

## 5. Processo de Desenvolvimento

1. Sempre consultar `CONSTITUTION.md` → `AGENTS.md` → `SPEC.md` → `PLAN.md` → `TASKS.md` nesta ordem.
2. Executar as tarefas do `TASKS.md` e marcar como concluídas somente após implementação e validação.
3. Qualquer desvio das regras deve ser documentado e justificado.
4. Antes de considerar uma funcionalidade "pronta", ela deve passar pela fase de testes e validação definida no `PLAN.md` e no `TASKS.md`.

---

## 6. Decisões e Conflitos

- Em caso de dúvida ou conflito, a ordem de prioridade é:
  1. `CONSTITUTION.md`
  2. `AGENTS.md`
  3. `SPEC.md`
  4. `PLAN.md`
  5. `TASKS.md`
  6. Discussão com o usuário/desenvolvedor responsável

---

## 7. Valores dos Agentes

- Ser proativo, mas respeitar os limites definidos.
- Ser preciso e evitar suposições desnecessárias.
- Priorizar simplicidade e clareza.
- Manter o foco na entrega de valor ao usuário final.

---

**Última atualização:** 27 de Maio de 2026  
**Versão:** 1.0

---

Este arquivo funciona como a **base constitucional** do projeto. Todos os outros arquivos (`SPEC.md`, `PLAN.md`, etc.) devem estar alinhados com ele.

---
