using BancoProjeto2.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        string? codigo;
        Cliente cliente = new Cliente();

        // Entada de usuário e senha para cadastro
        Console.WriteLine("Cadastre seu nome de usuário e senha:");
        Console.Write("Nome de Usuário: ");
        string user = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        // Metódo para adição de cadastro
        codigo = cliente.CadastrarCliente(user, senha);
        Console.WriteLine(cliente.VerificarErro(codigo));
        Console.WriteLine("\nAperte qualquer tecla para continuar...");
        Console.ReadKey();

        Console.Clear();

        // Entrada de usuário e senha para login
        Console.WriteLine("Faça seu Login com usuário e senha: ");
        Console.Write("Nome de Usuário: ");
        string checkUser = Console.ReadLine();
        Console.Write("Senha: ");
        string checkSenha = Console.ReadLine();

        // Metódo para verificar existencia de usuario e senha para login
        codigo = cliente.VerificarLogin(checkUser, checkSenha);
        Console.WriteLine(cliente.VerificarErro(codigo));
        Console.WriteLine("\nAperte qualquer tecla para continuar...");
        Console.ReadKey();


    }
}