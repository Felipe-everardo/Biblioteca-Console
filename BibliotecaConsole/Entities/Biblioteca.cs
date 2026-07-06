using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities;

internal class Biblioteca : IBibliotecaService
{
    private readonly List<Livro> _livros = new();
    private readonly List<Cliente> _clientes = new();
    private readonly List<Emprestimo> _emprestimos = new();

    private int _proximoEmprestimoId = 1;
    private int _proximoClienteId = 1;
    private int _proximoLivroId = 1;

    public void AdicionarLivro(Livro livro)
    {
        _livros.Add(livro);
    }

    public void CadastrarCliente(Cliente cliente)
    {
        _clientes.Add(cliente);
    }

    public void RegistrarCliente(string nome, string cpf)
    {
        bool cpfDuplicado = _clientes.Any(c => c.Cpf == cpf);

        if (cpfDuplicado)
            throw new InvalidOperationException("Cliente já cadastrado");

        Cliente cliente = new Cliente(_proximoClienteId++, nome, cpf);
        _clientes.Add(cliente);
    }

    public void RegistrarLivro(string titulo, string autor, int quantidade)
    {
        titulo = titulo.Trim();
        autor = autor.Trim();

        bool tituloDuplicado = _livros.Any(livro => 
        livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) &&
        livro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase));

        if (tituloDuplicado)
            throw new InvalidOperationException("Livro já cadastrado");

        Livro livro = new Livro(_proximoLivroId++, titulo, autor, quantidade);
        _livros.Add(livro);
    }

    public IReadOnlyCollection<Livro> Livros => _livros;
    public IReadOnlyCollection<Cliente> Clientes => _clientes;
    public IReadOnlyCollection<Emprestimo> Emprestimos => _emprestimos;

    public void RealizarEmprestimo(int clienteId, int livroId)
    {
        Cliente cliente = _clientes.First(c => c.Id == clienteId);

        Livro livro = _livros.First(l => l.Id == livroId);

        int emprestimosAtivos = _emprestimos.Count(e => e.Cliente.Id == clienteId && !e.FoiDevolvido());

        if (emprestimosAtivos >= 3)
            throw new InvalidOperationException(
                "Cliente atingiu o limite de empréstimos.");

        livro.Emprestar();

        Emprestimo emprestimo = new(_proximoEmprestimoId++, cliente, livro, 7);

        _emprestimos.Add(emprestimo);
    }

    public void RegistrarDevolucao(int emprestimoId)
    {
        Emprestimo emprestimo = _emprestimos.First(e => e.Id == emprestimoId);

        emprestimo.RegistrarDevolucao();
        emprestimo.Livro.Devolver();
    }
}


