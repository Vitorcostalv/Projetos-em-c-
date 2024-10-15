using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string caminho = "exemplo.txt";
            File.WriteAllText(caminho, "Olá, C#!");
            string conteudo = File.ReadAllText(caminho);
            Console.WriteLine("Conteúdo do arquivo: " + conteudo);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Operação finalizada.");
        }
    }
}
