using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bem.vindo
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroGeral cadastro = new CadastroGeral();
            bool controle = true;   
            while (controle)
            {
                try
                {
                    int opcao;
                    Console.WriteLine(" ============ CADASTRO DO CLIENTE ==============");
                    Console.WriteLine("| 1 - Cadastrar novo cliente                    |");
                    Console.WriteLine("| 2 - Exibir lista com nomes de todos clientes  |");
                    Console.WriteLine("| 0 - Sair                                      |");
                    Console.WriteLine(" ===============================================\n");
                    Console.WriteLine("Digite a opção que gostaria?");
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                           cadastro.CadastroCliente();
                            break;
                        case 2:
                            cadastro.ExibirClientes();
                            break;
                        default:
                            cadastro.sairPrograma();
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception)
                {

                    Console.WriteLine("\nErro na digitação!");
                }
            }
        }
    }
}
