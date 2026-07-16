using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities;

public class Biblioteca : IBibliotecaService
{
    private readonly List<Livro> _livros = new();
    private readonly List<Cliente> _clientes = new();
    private readonly List<Emprestimo> _emprestimos = new();

    private int _proximoEmprestimoId = 1;
    private int _proximoClienteId = 1;
    private int _proximoLivroId = 1;


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

    private Cliente BuscarClientePorId(int clienteId)
    {
        Cliente cliente = _clientes.FirstOrDefault(c => c.Id == clienteId);

        if (cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");

        return cliente;
    }

    private Livro BuscarLivroPorId(int livroId)
    {
        Livro livro = _livros.FirstOrDefault(l => l.Id == livroId);

        if (livro == null)
            throw new InvalidOperationException("Livro não encontrado");

        return livro;
    }

    private Emprestimo BuscarEmprestimoPorId(int emprestimoId)
    {
        Emprestimo? emprestimo = _emprestimos.FirstOrDefault(e => e.Id == emprestimoId);

        if (emprestimo is null)
            throw new InvalidOperationException("Empréstimo não encontrado.");

        return emprestimo;
    }


    public IReadOnlyCollection<Livro> Livros => _livros;
    public IReadOnlyCollection<Cliente> Clientes => _clientes;
    public IReadOnlyCollection<Emprestimo> Emprestimos => _emprestimos;

    public void RealizarEmprestimo(int clienteId, int livroId)
    {
        Cliente cliente = BuscarClientePorId(clienteId);
        Livro livro = BuscarLivroPorId(livroId);

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
        Emprestimo emprestimo = BuscarEmprestimoPorId(emprestimoId);

        emprestimo.RegistrarDevolucao();
        emprestimo.Livro.Devolver();
    }
}


