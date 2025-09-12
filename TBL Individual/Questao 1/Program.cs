// ---------------------------------------------------------------
// Criado por: Igor Lima
// Exercícios Avaliativos – Faculdade ESAMC
//
// Exceção personalizada: IdadeInvalidaException
// Objetivo: Lançada quando alguém tentar cadastrar uma pessoa
//           com idade menor que 0 ou maior que 120.
// Demonstração: Classe Pessoa valida a idade no cadastro.
// ---------------------------------------------------------------
﻿using System;

public class IdadeInvalidaException : Exception
{
    public IdadeInvalidaException()
        : base("A idade informada é inválida. Deve estar entre 0 e 120 anos.") { }

    public IdadeInvalidaException(string mensagem)
        : base(mensagem) { }
}

public class Pessoa
{
    public string Nome { get; set; }
    private int idade;

    public int Idade
    {
        get { return idade; }
        set
        {
            if (value < 0 || value > 120)
                throw new IdadeInvalidaException($"Idade inválida: {value}. Deve estar entre 0 e 120.");
            idade = value;
        }
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Pessoa p = new Pessoa(nome, idade);

            Console.WriteLine($"\n{p.Nome} cadastrado(a) com {p.Idade} anos.");
        }
        catch (IdadeInvalidaException ex)
        {
            Console.WriteLine("\nErro: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: A idade deve ser um número inteiro.");
        }
    }
}

