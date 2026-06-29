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

    public void AdicionarLivro(Livro livro)
    {
        _livros.Add(livro);
    }

    public void CadastrarCliente(Cliente cliente)
    {
        _clientes.Add(cliente);
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


