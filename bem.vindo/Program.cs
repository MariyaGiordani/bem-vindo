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
                    Console.WriteLine("| 2 - Listager cliente por ID                   |");
                    Console.WriteLine("| 3 - Listager endereco por ID                  |");
                    Console.WriteLine("| 4 - Carregar dados do arquivo                 |");
                    Console.WriteLine("| 5 - SQL Test                                  |");
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
                            var code = Console.ReadLine();
                            cadastro.ListagemClienteID(code);
                            break;
                        case 3:
                            var id = Console.ReadLine();
                            cadastro.ListagemEnderecoID(id);
                            break;
                        case 4:
                            cadastro.CarregarDadosTxt();
                            break;
                        case 5:
                            cadastro.SQLTest();
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
