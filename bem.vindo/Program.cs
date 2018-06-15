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


            Console.WriteLine("Escolha tipo de cliente: ");
            cliente.TipoDeCliente();
            //Console.WriteLine("Digite o codigo do cliente: ");
            cliente.CodigoCliente(listaCliente);
            Console.WriteLine("Digite o nome do cliente: ");
            cliente.NomeCliente();
            cliente.IdadeCliente();
            Console.WriteLine("Digite estado civil do cliente: ");
            cliente.EstadoCivilCliente();
            Console.WriteLine("Digite o genero do cliente: ");
            cliente.TipoGeneros();
            Console.Clear();

            for (int x = 1; x < 4; x++)
            {
                Endereco endereco = new Endereco();
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                Console.WriteLine("Escolha tipo de logradouro:");
                endereco.Logradouro();
                Console.WriteLine("Digite complemento:");
                endereco.ComplementoEndereco();
                Console.WriteLine("Digite CEP:");
                endereco.CEPEdndereco();
                Console.WriteLine("Digite bairro:");
                endereco.BairroEndereco();
                Console.WriteLine("Digite cidade:");
                endereco.CidadeEndereco();
                cliente.listaEndereco.Add(endereco);
                Console.Clear();

            }
            cliente.InfoDoCliente();
            Console.Clear();
            return cliente;
        }
    }
}
