using ConsoleApp1.Entities;

namespace ConsoleApp1;

public interface IBibliotecaService
{
    IReadOnlyCollection<Livro> Livros { get; }
    IReadOnlyCollection<Cliente> Clientes { get; }
    IReadOnlyCollection<Emprestimo> Emprestimos { get; }

    void RealizarEmprestimo(int clienteId, int livroId);
    void RegistrarDevolucao(int emprestimoId);
    void RegistrarCliente(string nome, string cpf);
    void RegistrarLivro(string titulo, string autor, int quantidade);
}