using ConsoleApp1.Entities;
namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        IBibliotecaService minhaBiblioteca = new Biblioteca();

        AppMenu menuDaAplicacao = new AppMenu(minhaBiblioteca);

        menuDaAplicacao.PopularDadosIniciais();

        menuDaAplicacao.Iniciar();
    }
}

