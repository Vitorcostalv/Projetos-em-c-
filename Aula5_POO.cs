using System;

class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public void MostrarInformacoes()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = "Vitor";
        pessoa.Idade = 25;
        pessoa.MostrarInformacoes();
    }
}
