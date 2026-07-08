using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities;

public class Cliente
{
    public int Id { get; }
    public string Nome { get; }
    public string Cpf { get; }

    public Cliente(int id, string nome, string cpf)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido.");

        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF inválido.");

        Id = id;
        Nome = nome;
        Cpf = cpf;
    }

    public override string ToString()
    {
        return $"{Id} - {Nome}";
    }
}
