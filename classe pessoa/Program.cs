//using Newtonsoft.Json;
using System;
using System.IO;


using System;
using System.Text.Json;

class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
}

class Program
{
    static void Main()
    {
        Livro livro1 = new Livro
        {
            Titulo = "Clean Code",
            Autor = "Robert C. Martin",
            Ano = 2008
        };

        // Serializar para JSON
        string json = JsonSerializer.Serialize(livro1, new JsonSerializerOptions { WriteIndented = true });

        Console.WriteLine("Objeto em JSON:");
        Console.WriteLine(json);
    }
}