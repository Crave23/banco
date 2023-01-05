using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace bytebank
{

    public class Program
    {

        static void MostrarOpcoes()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum():F2}");

        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            Console.Write("Digite a senha: ");
            string senhaParaApresentar = Console.ReadLine();
            int indexSenhaParaApresentar = senhas.FindIndex(senha => senha == senhaParaApresentar);

            if (indexParaApresentar == -1 || indexSenhaParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada ou senha incorreta.");
                Console.WriteLine("Para retornar ao menu digite 0");

            }

            else 
            { 
                Console.WriteLine("--------------------");
                Console.Write("Para continuar aperte 1: ");
            }

            int opcao = int.Parse(Console.ReadLine());

            if (opcao != 0)
            {


                Console.WriteLine("--------------------");

                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);

                Console.WriteLine("--------------------");
                Console.WriteLine("7 - Depositar");
                Console.WriteLine("8 - Sacar");
                Console.WriteLine("9 - Tranferir");
                Console.WriteLine("0 - Retornar");
                Console.Write("Digite nova opção desejada: ");
                int novaopcao = int.Parse(Console.ReadLine());





                if (novaopcao == 7)
                {
                    Console.WriteLine("Qual valor a ser Depositado?");
                    Console.Write($"R$: ");
                    double valor = double.Parse(Console.ReadLine());

                }
                if (novaopcao == 8)
                {
                    Console.WriteLine("Qual valor a ser Sacado?");
                    Console.Write($"R$: ");
                    double valor = double.Parse(Console.ReadLine());

                }
                if (novaopcao == 9)
                {
                    Console.WriteLine("Qual valor a ser Transferido?");
                    Console.Write($"R$: ");
                    double valor = double.Parse(Console.ReadLine());

                    Console.WriteLine("-----------------");
                }


            }
        }


        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                MostrarOpcoes();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        ManipularConta(cpfs, titulares, senhas, saldos);
                        break;



                }

                Console.WriteLine("--------------------");

            } while (option != 0);



        }

    }

}