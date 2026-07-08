namespace BibliotecaMSTest;
using ConsoleApp1.Entities;

[TestClass]
public sealed class BibliotecaTests
{
    private readonly Biblioteca _biblioteca;

    public BibliotecaTests()
    {
        _biblioteca = new Biblioteca();
    }

    [TestMethod]
    public void RegistrarCliente_ComDadosValidos_DeveAdicionarCliente()
    {
        _biblioteca.RegistrarCliente("Maria", "123");

        Assert.AreEqual(1, _biblioteca.Clientes.Count());
    }

    [TestMethod]
    public void RegistrarCliente_ComCPFDuplicado_DeveLancarInvalidOperationException()
    {
        _biblioteca.RegistrarCliente("Maria", "123");

        Assert.Throws<InvalidOperationException>(() => _biblioteca.RegistrarCliente("João", "123"));
    }

    [TestMethod]
    public void RegistrarCliente_ComCPFInvialido_NaoDeveDeveAdicionarOutroCLiente()
    {
        _biblioteca.RegistrarCliente("Maria", "123");

        try
        {
            _biblioteca.RegistrarCliente("Maria", "123");
        }
        catch (InvalidOperationException)
        {
        }

        Assert.AreEqual(1, _biblioteca.Clientes.Count());
    }

    [TestMethod]
    public void RegistrarLivro_ComDadosValidos_DeveAdicionarLivro()
    {
        _biblioteca.RegistrarLivro("Livro A", "Autor A", 5);
        Assert.AreEqual(1, _biblioteca.Livros.Count());
    }

    [TestMethod]
    public void RegistrarLivro_ComTituloEAutorDuplicados_DeveLancarInvalidOperationException()
    {
        _biblioteca.RegistrarLivro("Livro A", "Autor A", 5);
        Assert.Throws<InvalidOperationException>(() => _biblioteca.RegistrarLivro("Livro A", "Autor A", 3));
    }

    [TestMethod]
    public void RegistrarLivro_ComTituloDuplicadoEAutorDiferente_DeveAdicionarLivro()
    {
        _biblioteca.RegistrarLivro("Livro A", "Autor A", 5);
        _biblioteca.RegistrarLivro("Livro A", "Autor B", 3);
        Assert.AreEqual(2, _biblioteca.Livros.Count());
    }

    [TestMethod]
    public void RegistrarLivro_ComQuantidadeNegativa_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _biblioteca.RegistrarLivro("Livro A", "Autor A", -1));
    }

    [TestMethod]
    public void RegistrarLivro_ComQuantidadeZero_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _biblioteca.RegistrarLivro("Livro A", "Autor A", 0));
    }

    [TestMethod]
    public void RegistrarLivro_ComTituloVazio_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _biblioteca.RegistrarLivro("", "Autor A", 5));
    }

    [TestMethod]
    public void RegistrarLivro_ComAutorVazio_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _biblioteca.RegistrarLivro("Livro A", "", 5));
    }

    [TestMethod]

    public void RealizarEmprestimo_ComClienteEQuantidadeDisponivel_DeveRegistrarEmprestimo()
    {
        _biblioteca.RegistrarCliente("Maria", "123");
        _biblioteca.RegistrarLivro("Livro A", "Autor A", 5);
        _biblioteca.RealizarEmprestimo(1, 1);
        Assert.AreEqual(1, _biblioteca.Emprestimos.Count());
        Assert.AreEqual(4, _biblioteca.Livros.First().QuantidadeDisponivel);
    }
}
