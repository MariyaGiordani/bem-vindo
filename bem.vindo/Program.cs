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
                cliente.TipoDeCliente();
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
                cliente.TipoGeneros();
                Console.Clear();



                for (int x = 1; x < 4; x++)
                {
                    Endereco endereco = new Endereco();
                    endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                    Console.WriteLine("Escolha tipo de logradouro:");
                    endereco.Logradouro();
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
