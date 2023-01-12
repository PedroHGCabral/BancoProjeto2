

namespace BancoProjeto2.Entities
{
    internal class Cliente
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public List<Cliente> Contas { get; set; }

        public Cliente()
        {
            Contas = new List<Cliente>();
        }

        public Cliente(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public string CadastrarCliente(string usuario, string senha)
        {
            // verificação de segurança
            if (usuario.Length < 4 || senha.Length < 4)
            {
                return "002"; /// 002 - Nome de usuário e senha precisam ter 4 caracteres ou mais
            }

            // Verificação de disponibilidade de nome de usuário
            if (Contas.Exists(x => x.Usuario == usuario) == true)
            {
                return "001"; /// 001 - Usuário já existente
            }
            // Adição de usuário e senha a lista Conta
            else
            {
                Usuario = usuario;
                Senha = senha;
                Contas.Add(new Cliente(Usuario, Senha));
                return "000"; /// 000 - Cadastrado com sucessos
            }
        }

        public string VerificarLogin(string usuario, string senha)
        {
            if (Contas.Exists(x => x.Usuario == usuario) == true)
            {
                int pos = Contas.FindIndex(x => x.Usuario == usuario);
                if (Contas.ElementAt(pos).Senha == senha)
                {
                    return "003"; // 003 - Login com sucesso!
                }
                else
                {
                    return "004"; // 004 - Usuário ou senha inválido!
                }
            }
            else
            {
                return "005"; // 005 - Usuário inexistente
            }
        }

        public string VerificarErro(string codigo)
        {
            if (codigo == "000")
            {
                return "Cadastrado com sucesso!!!";
            }
            else if (codigo == "001")
            {
                return "Usuário já existente";
            }
            else if (codigo == "002")
            {
                return "Nome de usuário e senha precisam ter 4 caracteres ou mais";
            }
            else if (codigo == "003")
            {
                return "Login com sucesso!!!";
            }
            else if (codigo == "004")
            {
                return "Usuário ou senha Inválido!";
            }
            else if (codigo == "005")
            {
                return "Usuário inexistente";
            }
            else
            {
                return "Erro Desconhecido";
            }
        }
    }
}
