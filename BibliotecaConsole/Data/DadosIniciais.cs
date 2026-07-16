using ConsoleApp1;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca_console.Data;


internal class DadosIniciais
{
    public void PopularDadosIniciais(IBibliotecaService biblioteca)
    {
        biblioteca.RegistrarCliente("João Silva", "12345678900");
        biblioteca.RegistrarCliente("Maria Souza", "98765432100");
        biblioteca.RegistrarLivro("O Senhor dos Anéis", "J.R.R. Tolkien", 5);
        biblioteca.RegistrarLivro("1984", "George Orwell", 3);
    }
}
