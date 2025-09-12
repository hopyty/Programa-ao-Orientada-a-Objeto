// ---------------------------------------------------------------
// Criado por: Igor Lima
// Exercícios Avaliativos – Faculdade ESAMC
//
// Exceção personalizada: EstoqueInsuficienteException
// Objetivo: Lançada quando alguém tentar retirar mais produtos
//           do que a quantidade disponível em estoque.
// Demonstração: Classe Produto controla as retiradas.
// ---------------------------------------------------------------
﻿using System;

public class EstoqueInsuficienteException : Exception
{
    public EstoqueInsuficienteException()
        : base("Não há quantidade suficiente no estoque para realizar a operação.") { }

    public EstoqueInsuficienteException(string mensagem)
        : base(mensagem) { }
}

public class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; private set; }

    public Produto(string nome, int quantidadeInicial)
    {
        Nome = nome;
        Quantidade = quantidadeInicial;
    }

    public void Retirar(int quantidade)
    {
        if (quantidade > Quantidade)
        {
            throw new EstoqueInsuficienteException(
                $"Estoque insuficiente! Disponível: {Quantidade}, solicitado: {quantidade}."
            );
        }

        Quantidade -= quantidade;
        Console.WriteLine($"✅ Retirados {quantidade} unidades de {Nome}. Estoque restante: {Quantidade}.");
    }
}

class Program
{
    static void Main()
    {
        Produto p = new Produto("Caderno", 10);

        try
        {
            Console.WriteLine($"Estoque inicial de {p.Nome}: {p.Quantidade}");

            Console.Write("\nDigite a quantidade para retirar: ");
            int qtd = int.Parse(Console.ReadLine());

            p.Retirar(qtd);
        }
        catch (EstoqueInsuficienteException ex)
        {
            Console.WriteLine("\n❌ Erro: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("\n❌ Erro: Digite apenas números inteiros.");
        }
    }
}

