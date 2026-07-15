# BibliotecaApp

Projeto de estudo em C# para praticar modelagem orientada a objetos, separação de responsabilidades, princípios de SOLID e testes automatizados com MSTest.

A aplicação simula uma biblioteca digital em modo console, com cadastro de clientes, cadastro de livros, controle de estoque, empréstimos e devoluções. A proposta não é ser um sistema completo de produção, mas um laboratório prático para evoluir código de forma incremental, entendendo melhor onde cada responsabilidade deve ficar.

## Objetivos de estudo

- Praticar C# com classes, propriedades, métodos, construtores e coleções.
- Separar regras de negócio da entrada e saída do console.
- Aplicar conceitos de orientação a objetos em um domínio simples.
- Usar interface para reduzir acoplamento entre menu e serviço da biblioteca.
- Criar testes automatizados para validar regras importantes.
- Evoluir o projeto aos poucos, com foco em legibilidade e manutenção.

## Funcionalidades

- Cadastro de clientes.
- Cadastro de livros com controle de quantidade disponível.
- Listagem de clientes, livros e empréstimos.
- Registro de empréstimos.
- Registro de devoluções.
- Bloqueio de livro indisponível.
- Validação de cliente duplicado por CPF.
- Validação de livro duplicado usando título e autor.
- Limite de empréstimos ativos por cliente.

## Estrutura do projeto

```text
BibliotecaApp
├── BibliotecaConsole
│   ├── Program.cs
│   └── Entities
│       ├── AppMenu.cs
│       ├── Biblioteca.cs
│       ├── IBiblioteca.cs
│       ├── Cliente.cs
│       ├── Livro.cs
│       └── Emprestimo.cs
└── BibliotecaMSTest
    └── BibliotecaTests.cs
```

## Como o projeto foi pensado

O projeto separa a interação com o usuário das regras centrais da biblioteca.

`AppMenu` cuida do fluxo do console: exibir opções, ler dados digitados e mostrar mensagens.

`Biblioteca` concentra as regras de negócio: cadastrar clientes, cadastrar livros, impedir duplicidades, realizar empréstimos, controlar devoluções e manter as coleções internas.

As entidades `Cliente`, `Livro` e `Emprestimo` representam os conceitos principais do domínio. Elas também protegem parte do próprio estado, como impedir livro sem título, autor vazio ou quantidade inválida.

A interface `IBibliotecaService` permite que o menu dependa de um contrato, não diretamente da implementação concreta. Isso é um primeiro passo para praticar inversão de dependência e facilitar futuras trocas ou testes.

## Conceitos praticados

### Orientação a objetos

O domínio foi dividido em classes com responsabilidades próprias:

- `Cliente`: representa quem pode pegar livros emprestados.
- `Livro`: representa o item do acervo e controla sua quantidade disponível.
- `Emprestimo`: representa a relação entre cliente, livro, data de empréstimo e devolução.
- `Biblioteca`: coordena as regras entre clientes, livros e empréstimos.

### SOLID

O projeto já abre espaço para discutir alguns princípios:

- **S - Single Responsibility Principle**: o menu lida com console; a biblioteca lida com regra de negócio; as entidades representam dados e comportamentos do domínio.
- **D - Dependency Inversion Principle**: `AppMenu` depende de `IBibliotecaService`, não diretamente da classe `Biblioteca`.

Ainda existem oportunidades de evolução, principalmente para deixar validações e tratamentos de entrada do console mais robustos.

### Testes automatizados

O projeto possui testes com MSTest cobrindo regras como:

- cadastro de cliente válido;
- bloqueio de CPF duplicado;
- cadastro de livro válido;
- bloqueio de livro duplicado por título e autor;
- permissão de mesmo título com autor diferente;
- validação de quantidade inválida;
- validação de título ou autor vazio;
- realização de empréstimo com baixa no estoque.

## Como executar

Na raiz do projeto:

```bash
dotnet run --project BibliotecaConsole
```

## Como rodar os testes

Na raiz do projeto:

```bash
dotnet test
```

Resultado atual:

```text
Total: 11 testes
Aprovados: 11
Falhas: 0
```

## Tecnologias

- C#
- .NET
- MSTest
- Aplicação Console

## Pontos fortes do projeto

- Domínio simples, bom para estudar sem se perder em infraestrutura.
- Regras importantes já estão fora do menu de console.
- Testes focados na classe `Biblioteca`, onde estão as decisões principais.
- Uso de interface para começar a praticar desacoplamento.
- Código fácil de evoluir para novos exercícios, como persistência, repositórios ou API.

## Status

Projeto em evolução, criado com foco em estudo e prática. A ideia principal é melhorar o desenho do código aos poucos, sempre usando testes para dar segurança nas mudanças.
