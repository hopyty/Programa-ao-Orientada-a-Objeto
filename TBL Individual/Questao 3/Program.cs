using System;
public class UsuarioNaoAutenticadoException : Exception
{
    public UsuarioNaoAutenticadoException()
        : base("Usuário não autenticado. É necessário fazer login para acessar este recurso.") { }

    public UsuarioNaoAutenticadoException(string mensagem)
        : base(mensagem) { }
}

public class Sistema
{
    private bool autenticado = false;

    public void Login(string usuario, string senha)
    {
        if (usuario == "admin" && senha == "123")
        {
            autenticado = true;
            Console.WriteLine("\n✅ Login realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("\n❌ Usuário ou senha incorretos.");
        }
    }

    public void AcessarRecurso()
    {
        if (!autenticado)
        {
            throw new UsuarioNaoAutenticadoException();
        }

        Console.WriteLine("\n🔓 Recurso acessado com sucesso!");
    }
}

class Program
{
    static void Main()
    {
        Sistema sistema = new Sistema();

        try
        {
            Console.Write("Digite o usuário: ");
            string usuario = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            sistema.Login(usuario, senha);

            sistema.AcessarRecurso();
        }
        catch (UsuarioNaoAutenticadoException ex)
        {
            Console.WriteLine("\nErro: " + ex.Message);
        }
    }
}
