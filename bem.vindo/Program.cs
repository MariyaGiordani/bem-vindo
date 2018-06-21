using System;
using bem.vindo.Model;
using bem.vindo.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bem.vindo.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroGeral cadastro = new CadastroGeral();
            bool pertence = true;   
            while (pertence)
            {
                try
                {
                    int opcao;
                    Console.WriteLine(" ============ CADASTRO DO CLIENTE ==============");
                    Console.WriteLine("| 1 - Cadastrar novo cliente                    |");
                    Console.WriteLine("| 2 - Exibir lista com nomes de todos clientes  |");
                    Console.WriteLine("| 3 - Listagem do Clientes                      |");
                    Console.WriteLine("| 0 - Sair                                      |");
                    Console.WriteLine(" ===============================================\n");
                    Console.WriteLine("Digite a opção que gostaria?");
                    opcao = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    switch (opcao)
                    {
                        case 1:
                           cadastro.CadastroCliente();
                            break;
                        case 2:
                            cadastro.ExibirClientes();
                            break;
                        case 3:
                            cadastro.ListagemClientesTxt();
                            break;
                        default:
                            Console.WriteLine("Você está saindo do programa. Muito obrigada :-)");
                            pertence = false;
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nErro na digitação!");
                    Console.WriteLine("\nMensagem: " + ex.Message);
                }
            }
        }
    }
}
