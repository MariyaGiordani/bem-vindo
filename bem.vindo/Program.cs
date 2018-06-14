using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bem.vindo
{
    class Program
    {
        public static List<Cliente> listaCliente = new List<Cliente>();
        static void Main(string[] args)
        {


            while (1 == 1)
            {
                listaCliente.Add(Cadastro());
                Console.WriteLine("Gostaria de adicionar um novo cliente? \n S-Sim \n N-Não");
                string resposta = Console.ReadLine().ToUpper();
                if (resposta == "N")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
                Console.WriteLine("\nLista dos nomes do clientes já cadastrado:");
                foreach (var cliente in listaCliente)
                {
                    Console.WriteLine("Nome do cliente: " + cliente.Nome);
                }
            }
        }

        public static Cliente Cadastro()
        {
            Console.WriteLine("======= Bem Vindo! ========");

            Cliente cliente = new Cliente();

            try
            {
                Console.WriteLine("Escole tipo de cliente: ");
                bool opcao = true;
                while (opcao)
                {
                    Console.WriteLine("{0} - F / {1} - J", TipoCliente.Fisical.ToString(), TipoCliente.Juridica.ToString());
                    string respostaGenero = Console.ReadLine().ToUpper();
                    switch (respostaGenero)
                    {
                        case "F":
                            cliente.TipoCliente = TipoCliente.Fisical;
                            opcao = false;
                            break;
                        case "J":
                            cliente.TipoCliente = TipoCliente.Juridica;
                            opcao = false;
                            break;
                        default:
                            Console.WriteLine("Resposta inválida!");
                            break;
                    }
                }

                Console.WriteLine("Digite o codigo do cliente: ");
                cliente.CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());

                do
                {
                    if (listaCliente.FindIndex(x => x.CodigoDoCliente == cliente.CodigoDoCliente) != -1)
                    {
                        Console.WriteLine("Codigo de cliente já existe!");
                        Console.WriteLine("Digite de novo!");
                        Console.WriteLine("Digite o codigo do cliente: ");
                        cliente.CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());
                    }
                } while (listaCliente.FindIndex(x => x.CodigoDoCliente == cliente.CodigoDoCliente) != -1);
                Console.WriteLine("Digite o nome do cliente: ");
                cliente.Nome = Console.ReadLine();
                Console.WriteLine("Digite o idade do cliente: ");
                cliente.Idade = Convert.ToInt32(Console.ReadLine().ToString());
                Console.WriteLine("Digite estado civil do cliente: ");
                cliente.EstadoCivil = Console.ReadLine();

                Console.WriteLine("Digite o genero do cliente: ");
                // exibir opções
                bool control = true;
                while (control)
                {
                    Console.WriteLine("{0} - M / {1} - F / {2} - N", Genero.Masculino.ToString(), Genero.Feminino.ToString(), Genero.NA.ToString());
                    string respostaGenero = Console.ReadLine().ToUpper();
                    switch (respostaGenero)
                    {
                        case "M":
                            cliente.Genero = Genero.Masculino;
                            control = false;
                            break;
                        case "F":
                            cliente.Genero = Genero.Feminino;
                            control = false;
                            break;
                        case "N":
                            cliente.Genero = Genero.NA;
                            control = false;
                            break;
                        default:
                            Console.WriteLine("Resposta inválida!");
                            break;
                    }
                }

                Console.Clear();



                for (int x = 1; x < 4; x++)
                {
                    Endereco endereco = new Endereco();
                    endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                    Console.WriteLine("Escolha tipo de logradouro:");
                    bool tipo = true;
                    while (tipo)
                    {
                        Console.WriteLine("{0} - A / {1} - R / {2} - T", TipoLogradouro.Avenida.ToString(), TipoLogradouro.Rua.ToString(), TipoLogradouro.Travessa.ToString());
                        string respostaGenero = Console.ReadLine().ToUpper();
                        switch (respostaGenero)
                        {
                            case "A":
                                endereco.TipoLogradouro = TipoLogradouro.Avenida;
                                tipo = false;
                                break;
                            case "R":
                                endereco.TipoLogradouro = TipoLogradouro.Rua;
                                tipo = false;
                                break;
                            case "T":
                                endereco.TipoLogradouro = TipoLogradouro.Travessa;
                                tipo = false;
                                break;
                            default:
                                Console.WriteLine("Resposta inválida!");
                                break;
                        }
                    }
                    Console.WriteLine("Escolha tipo de logradouro:");
                    endereco.NomeLogradouro = Console.ReadLine();
                    Console.WriteLine("Digite complemento:");
                    endereco.Complemento = Console.ReadLine();
                    Console.WriteLine("Digite CEP:");
                    endereco.CEP = Console.ReadLine();
                    Console.WriteLine("Digite bairro:");
                    endereco.Bairro = Console.ReadLine();
                    Console.WriteLine("Digite cidade:");
                    endereco.Cidade = Console.ReadLine();
                    cliente.listaEndereco.Add(endereco);
                    Console.Clear();

                }
                cliente.InfoDoCliente();
                Console.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na digitação!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);
                Console.ReadKey();
            }
            return cliente;
        }
    }
}
