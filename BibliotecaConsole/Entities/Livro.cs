using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities;

internal class Livro
{
    public int Id { get; }
    public string Titulo { get; }
    public string Autor { get; }
    public int QuantidadeDisponivel { get; private set; }

    public Livro(int id, string titulo, string autor, int quantidadeDisponivel)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título inválido.");

        if (string.IsNullOrWhiteSpace(autor))
            throw new ArgumentException("Autor inválido.");

        if (quantidadeDisponivel < 0)
            throw new ArgumentException("Quantidade inválida.");

        Id = id;
        Titulo = titulo;
        Autor = autor;
        QuantidadeDisponivel = quantidadeDisponivel;
    }

    public void Emprestar()
    {
        if (QuantidadeDisponivel <= 0)
            throw new InvalidOperationException("Livro indisponível.");

        QuantidadeDisponivel--;
    }

    public void Devolver()
    {
        QuantidadeDisponivel++;
    }

    public override string ToString()
    {
        return $"{Id} - {Titulo} ({Autor}) - Estoque: {QuantidadeDisponivel}";
    }
}