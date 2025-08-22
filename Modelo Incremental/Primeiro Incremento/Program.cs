using System;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }

    public void Exibir()
    {
        Console.WriteLine($"{Nome} - R$ {Preco:F2}");
    }
}

class Carrinho
{
    private List<Produto> produtos = new List<Produto>();

    public void AdicionarProduto(Produto p)
    {
        produtos.Add(p);
    }

    public void ExibirProdutos()
    {
        Console.WriteLine("\nProdutos no carrinho:");
        foreach (var p in produtos)
        {
            p.Exibir();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Produto p1 = new Produto { Nome = "Mouse", Preco = 80.00 };
        Produto p2 = new Produto { Nome = "Teclado", Preco = 150.00 };

        Carrinho c = new Carrinho();
        c.AdicionarProduto(p1);
        c.AdicionarProduto(p2);

        c.ExibirProdutos();
    }
}

