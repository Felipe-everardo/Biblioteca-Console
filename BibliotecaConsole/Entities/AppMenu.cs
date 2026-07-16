using ConsoleApp1.Entities;

namespace ConsoleApp1;

public class AppMenu
{
    private readonly IBibliotecaService _biblioteca;

    public AppMenu(IBibliotecaService biblioteca)
    {
        _biblioteca = biblioteca;
    }

    public void Iniciar()
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();

            Console.WriteLine("===== BIBLIOTECA DIGITAL =====");
            Console.WriteLine("1 - Listar livros");
            Console.WriteLine("2 - Listar clientes");
            Console.WriteLine("3 - Listar empréstimos");
            Console.WriteLine("4 - Realizar empréstimo");
            Console.WriteLine("5 - Registrar devolução");
            Console.WriteLine("6 - Cadastrar Cliente");
            Console.WriteLine("7 - Cadastrar Livro");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida.");
                Pausar();
                continue;
            }

            try
            {
                switch (opcao)
                {
                    case 1:
                        ListarLivros();
                        break;

                    case 2:
                        ListarClientes();
                        break;

                    case 3:
                        ListarEmprestimos();
                        break;

                    case 4:
                        RegistrarEmprestimo();
                        break;

                    case 5:
                        RegistrarDevolucao();
                        break;

                    case 6:
                        DadosParaCadastroCliente();
                        break;

                    case 7:
                        DadosParaCadastroLivro();
                        break;
                    case 0:
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Pausar();
        }
    }

    public void ListarLivros()
    {
        Console.WriteLine("===== LIVROS =====");

        foreach (var livro in _biblioteca.Livros)
        {
            Console.WriteLine(livro);
        }
    }

    public void ListarClientes()
    {
        Console.WriteLine("===== CLIENTES =====");

        foreach (var cliente in _biblioteca.Clientes)
        {
            Console.WriteLine($"ID: {cliente.Id}, Cliente: {cliente.Nome}");
        }
    }

    public void ListarEmprestimos()
    {
        Console.WriteLine("===== EMPRÉSTIMOS =====");

        foreach (var emprestimo in _biblioteca.Emprestimos)
        {
            string status =
                emprestimo.FoiDevolvido()
                    ? "Devolvido"
                    : "Ativo";

            Console.WriteLine(
                $"Id: {emprestimo.Id} | " +
                $"Cliente: {emprestimo.Cliente.Nome} | " +
                $"Livro: {emprestimo.Livro.Titulo} | " +
                $"Status: {status}");
        }
    }

    public void RegistrarEmprestimo()
    {
        Console.Write("Id do cliente: ");

        if (!int.TryParse(Console.ReadLine(), out int clienteId))
        {
            throw new ArgumentException("Id do cliente inválido.");
        }

        Console.Write("Id do livro: ");
        if (!int.TryParse(Console.ReadLine(), out int livroId))
        {
            throw new ArgumentException("Id do livro inválido.");
        }

        _biblioteca.RealizarEmprestimo(clienteId, livroId);

        Console.WriteLine("Empréstimo realizado com sucesso.");
    }

    public void RegistrarDevolucao()
    {
        Console.Write("Id do empréstimo: ");
        if (!int.TryParse(Console.ReadLine(), out int emprestimoId))
        {
            throw new ArgumentException("Id do empréstimo inválido.");
        }

        _biblioteca.RegistrarDevolucao(
            emprestimoId);

        Console.WriteLine("Livro devolvido com sucesso.");
    }

    public void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla...");
        Console.ReadKey();
    }

    public void DadosParaCadastroCliente()
    {
        Console.WriteLine("===== CLIENTE =====");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf))
        {
            Console.WriteLine("Nome e CPF são obrigatórios");
            return;
        }

        _biblioteca.RegistrarCliente(nome.Trim(), cpf.Trim());
        Console.WriteLine("Cliente cadastrado com sucesso.");
    }

    public void DadosParaCadastroLivro()
    {
        Console.WriteLine("===== LIVRO =====");
        Console.Write("Nome: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        Console.Write("Quantidade: ");

        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("A quantidade deve ser um número maior que zero.");
            return;
        }
            
        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
        {
            Console.WriteLine("Titulo e autor são obrigatórios");
            return;
        }

        _biblioteca.RegistrarLivro(titulo.Trim(), autor.Trim(), quantidade);
        Console.WriteLine("Livro cadastrado com sucesso...");
    }
}
