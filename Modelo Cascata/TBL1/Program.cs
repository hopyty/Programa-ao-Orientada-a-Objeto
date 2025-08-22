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

    public double CalcularTotal()
    {
        double total = 0;
        foreach (var p in produtos)
        {
            total += p.Preco;
        }
        return total;
    }

    public void ExibirPagamento(string forma)
    {
        Console.WriteLine($"Forma de pagamento escolhida: {forma}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Produto p1 = new Produto { Nome = "Celular", Preco = 1200.00 };
        Produto p2 = new Produto { Nome = "Fone sem fio", Preco = 250.00 };
        Produto p3 = new Produto { Nome = "Notebook", Preco = 3500.00 };
        Produto p4 = new Produto { Nome = "monitor", Preco = 830.00 };
        Produto p5 = new Produto { Nome = "Pelicula Protetoura", Preco = 35.00 };


        Carrinho c = new Carrinho();
        c.AdicionarProduto(p1);
        c.AdicionarProduto(p2);
        c.AdicionarProduto(p3);
        c.AdicionarProduto(p4);
        c.AdicionarProduto(p5);

        c.ExibirProdutos();

        double total = c.CalcularTotal();
        Console.WriteLine($"\nTotal do carrinho: R$ {total:F2}");

        c.ExibirPagamento("Cartão de Credito");
    }
}