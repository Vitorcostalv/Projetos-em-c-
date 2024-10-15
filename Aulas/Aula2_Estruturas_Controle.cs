using System;

class Program
{
    static void Main(string[] args)
    {
        int numero = 5;

        // Estrutura condicional
        if (numero % 2 == 0)
        {
            Console.WriteLine("O número é par.");
        }
        else
        {
            Console.WriteLine("O número é ímpar.");
        }

        // Estrutura de repetição
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Contagem: {i}");
        }
    }
}
