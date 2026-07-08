using ConsoleApp1.Entities;

public class Emprestimo
{
    public int Id { get; }
    public Cliente Cliente { get; }
    public Livro Livro { get; }

    public DateTime DataEmprestimo { get; }
    public DateTime DataPrevistaDevolucao { get; }

    public DateTime? DataDevolucao { get; private set; }

    public Emprestimo(
        int id,
        Cliente cliente,
        Livro livro,
        int diasParaDevolucao)
    {
        Id = id;
        Cliente = cliente;
        Livro = livro;

        DataEmprestimo = DateTime.Now;
        DataPrevistaDevolucao = DataEmprestimo.AddDays(diasParaDevolucao);
    }

    public void RegistrarDevolucao()
    {
        if (DataDevolucao != null)
            throw new InvalidOperationException("Empréstimo já devolvido.");

        DataDevolucao = DateTime.Now;
    }

    public bool FoiDevolvido()
    {
        return DataDevolucao != null;
    }

    public bool EstaAtrasado()
    {
        return !FoiDevolvido() &&
               DateTime.Now > DataPrevistaDevolucao;
    }
}