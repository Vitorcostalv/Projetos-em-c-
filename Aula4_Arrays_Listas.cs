using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Array
        int[] numeros = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Primeiro número: " + numeros[0]);

        // Lista
        List<string> nomes = new List<string> { "Ana", "Carlos", "João" };
        nomes.Add("Maria");
        nomes.Remove("Carlos");

        foreach (var nome in nomes)
        {
            Console.WriteLine(nome);
        }
    }
}
