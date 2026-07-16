# Biblioteca Console

Sistema de biblioteca em modo console desenvolvido em C#/.NET para praticar orientacao a objetos, separacao de responsabilidades e testes automatizados com MSTest.

A aplicacao permite cadastrar clientes e livros, realizar emprestimos, registrar devolucoes, controlar estoque e validar regras como CPF duplicado, livro indisponivel e limite de emprestimos ativos por cliente.

## Tecnologias

- C#
- .NET 10
- MSTest
- Console App

## Funcionalidades

- Cadastro de clientes
- Cadastro de livros
- Listagem de clientes, livros e emprestimos
- Registro de emprestimos
- Registro de devolucoes
- Controle de estoque
- Validacao de duplicidade de CPF
- Validacao de duplicidade de livro por titulo e autor
- Limite de emprestimos ativos por cliente
- Tratamento para cliente, livro ou emprestimo inexistente

## Conceitos praticados

- Orientacao a objetos
- Encapsulamento
- Separacao de responsabilidades
- Single Responsibility Principle
- Dependency Inversion com interface
- Testes automatizados
- Refatoracao orientada por testes

## Estrutura

```text
BibliotecaApp
|-- BibliotecaConsole
|   |-- Data
|   |-- Entities
|   |-- Program.cs
|
|-- BibliotecaMSTest
|   |-- BibliotecaTests.cs
```

## Como executar

```bash
dotnet run --project BibliotecaConsole
```

## Como rodar os testes

```bash
dotnet test
```

Resultado atual:

```text
14 testes aprovados
0 falhas
```

## Status

Projeto em desenvolvimento como estudo pratico de C# back-end. Proximas evolucoes planejadas: ampliar cobertura de testes, adicionar persistencia em JSON, separar camadas e futuramente expor as regras por uma API ASP.NET Core.
