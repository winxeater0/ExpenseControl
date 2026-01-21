# Expense Control

## Visão Geral

Este projeto implementa um sistema de controle de gastos residenciais,
desenvolvido como parte de um teste técnico para vaga de desenvolvedor.

O foco principal está na aderência às regras de negócio, clareza de
código, boas práticas de arquitetura e testabilidade.

A aplicação é dividida em dois projetos principais:

-   Back-end: Web API em .NET 8
-   Front-end: React com TypeScript (em desenvolvimento)

## Arquitetura

O back-end foi desenvolvido seguindo os princípios de DDD (Domain-Driven
Design), utilizando uma abordagem de arquitetura em camadas (sliced
architecture).

### Estrutura de projetos

ExpenseControl.Api\
ExpenseControl.Application\
ExpenseControl.Domain\
ExpenseControl.Infrastructure\
ExpenseControl.Application.Tests

### Responsabilidades por camada

Api: Exposição dos endpoints REST\
Application: Casos de uso, handlers, validações e relatórios\
Domain: Entidades, enums e regras de negócio\
Infrastructure: Persistência de dados (EF Core / SQL Server)\
Tests: Testes unitários (xUnit + Moq)

## Tecnologias Utilizadas

### Back-end

-   .NET 8
-   C#
-   Entity Framework Core
-   SQL Server
-   FluentValidation
-   xUnit
-   Moq
-   FluentAssertions

### Front-end

-   React
-   TypeScript

## Padrões e Decisões Arquiteturais

A API segue padrões REST, utilizando corretamente os verbos HTTP.

Os repositórios são definidos por interfaces, evitando dependências
diretas entre a Application Layer e a Infrastructure.

As validações são realizadas com FluentValidation, mantendo regras de
formato na Application Layer e regras de negócio no domínio.

### Regras de Negócio

-   Pessoas menores de 18 anos só podem registrar despesas
-   Categorias possuem finalidade: Receita, Despesa ou Ambas
-   Transações só aceitam categorias compatíveis com seu tipo
-   Ao excluir uma pessoa, todas as suas transações são removidas
-   O campo Amount de uma transação é sempre positivo

## Relatórios

Foram implementados relatórios de totais por pessoa e por categoria,
exibindo:

-   Total de receitas
-   Total de despesas
-   Saldo (Receita -- Despesa)

## Testes

Os testes utilizam xUnit com Moq e FluentAssertions.

A estratégia adotada prioriza: - Testes na Application Layer -
Repositórios mockados - Sem dependência de banco de dados

## Como Executar

Pré-requisitos: - .NET 8 SDK - SQL Server

Passos: 1. Configurar a connection string no appsettings.json 2.
Executar as migrations 3. Executar a API

## Autor

Matheus Gabriel
