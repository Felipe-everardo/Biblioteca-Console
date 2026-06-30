using ConsoleApp1.Entities;

namespace ConsoleApp1;

internal class AppMenu
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
                        RealizarEmprestimo();
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
    public void PopularDadosIniciais()
    {
        _biblioteca.AdicionarLivro(
            new Livro(1, "1984", "George Orwell", 5));

        _biblioteca.AdicionarLivro(
            new Livro(2, "Dom Quixote", "Miguel de Cervantes", 3));

        _biblioteca.AdicionarLivro(
            new Livro(3, "Clean Code", "Robert C. Martin", 2));

        _biblioteca.CadastrarCliente(
            new Cliente(1, "Felipe", "11111111111"));

        _biblioteca.CadastrarCliente(
            new Cliente(2, "Maria", "22222222222"));
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
            Console.WriteLine(cliente);
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

    public void RealizarEmprestimo()
    {
        Console.Write("Id do cliente: ");
        int clienteId = int.Parse(Console.ReadLine());

        Console.Write("Id do livro: ");
        int livroId = int.Parse(Console.ReadLine());

        _biblioteca.RealizarEmprestimo(
            clienteId,
            livroId);

        Console.WriteLine("Empréstimo realizado com sucesso.");
    }

    public void RegistrarDevolucao()
    {
        Console.Write("Id do empréstimo: ");
        int emprestimoId = int.Parse(Console.ReadLine());

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

        _biblioteca.RegistrarCliente(nome, cpf);
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
            Console.WriteLine("A quantidade deve ser número maior que zero.");
            return;
        }
            
        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
        {
            Console.WriteLine("Titulo e autor são obrigatórios");
            return;
        }

        _biblioteca.RegistrarLivro(titulo, autor, quantidade);
        Console.WriteLine("Livro cadastrado com sucesso...");
    }
}
