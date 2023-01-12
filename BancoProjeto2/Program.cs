using BancoProjeto2.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        string? codigo;
        Cliente cliente = new Cliente();

        Console.WriteLine("Cadastre seu nome de usuário e senha:");
        Console.Write("Nome de Usuário: ");
        string user = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        codigo = cliente.CadastrarCliente(user, senha);
        Console.WriteLine(cliente.VerificarErro(codigo));
        Console.ReadKey();

        Console.Clear();

        Console.WriteLine("Faça seu Login com usuário e senha: ");
        Console.Write("Nome de Usuário: ");
        string checkUser = Console.ReadLine();
        Console.Write("Senha: ");
        string checkSenha = Console.ReadLine();
    }
}