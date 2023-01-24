using System.Globalization;

using BancoProjeto2.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        string? codigo;
        Conta conta = new Conta();

        // Entada de usuário e senha para cadastro
        Console.WriteLine("Cadastre seu nome de usuário e senha:");
        Console.Write("Nome de Usuário: ");
        string user = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        // Metódo para adição de cadastro
        codigo = conta.CadastrarCliente(user, senha);
        Console.WriteLine(conta.VerificarErro(codigo));
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
        codigo = conta.VerificarLogin(checkUser, checkSenha);
        Console.WriteLine(conta.VerificarErro(codigo));
        if (codigo == "003") // 003 - Login com sucesso!!!
        {
            conta.Usuario = conta.Contas.Find(x => x.Usuario == checkUser).Usuario;
            conta.Saldo = conta.Contas.Find(x => x.Usuario == checkUser).Saldo;
        }
        Console.WriteLine("\nAperte qualquer tecla para continuar...");
        Console.ReadKey();

        Console.Clear();

        bool h = false;
        do
        {
            // Dados da Conta
            Console.WriteLine("==== Dados da Conta ====");
            Console.WriteLine($"Usuário: {conta.Usuario}");
            Console.WriteLine($"Saldo: R$ {conta.Saldo.ToString("F2")}");

            // Ações da conta
            Console.WriteLine();
            Console.WriteLine("Digite o número da sua próxima operação:");
            Console.WriteLine("1 - Fazer Depósito    2 - Fazer Saque");
            Console.WriteLine("3 - Finalizar");
            string x = Console.ReadLine();
            if (x != "1" && x != "2" && x != "3")
            {
                Console.Clear();
                Console.WriteLine("Por favor digite o número 1 ou 2 para escolher a operação\n");
            }
            else if (x == "1")
            {
                Console.Clear();
                Console.WriteLine("Digite a o valor para depósito:");
                Console.Write("R$ ");
                double dep = double.Parse(Console.ReadLine());
                conta.Saldo += dep;
                Console.WriteLine("Depósito realizado com sucesso!");
                Console.WriteLine("Aperte qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if (x == "2")
            {
                Console.Clear();
                Console.WriteLine("Digite a o valor para Saque:");
                Console.Write("R$ ");
                double sac = double.Parse(Console.ReadLine());
                if (conta.Saldo >= sac)
                {
                    conta.Saldo -= sac;
                    Console.WriteLine("Saque realizado com sucesso!");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para realizar o saque!");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                h = true;
            }
        }
        while (h == false);

        Console.Clear();
        Console.WriteLine("==== Dados da Conta ====");
        Console.WriteLine($"Usuário: {conta.Usuario}");
        Console.WriteLine($"Saldo: R$ {conta.Saldo.ToString("F2")}");

        Console.WriteLine("Aperte qualquer tecla para Finalizar sessão...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Obrigado por usar o nosso banco!!!");
    }
}