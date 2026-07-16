using biblioteca_console.Data;
using ConsoleApp1.Entities;
namespace ConsoleApp1;

public class Program
{
    static void Main(string[] args)
    {
        IBibliotecaService minhaBiblioteca = new Biblioteca();

        AppMenu menuDaAplicacao = new AppMenu(minhaBiblioteca);

        DadosIniciais dadosIniciais = new DadosIniciais();

        dadosIniciais.PopularDadosIniciais(minhaBiblioteca);

        menuDaAplicacao.Iniciar();
    }
}
  
