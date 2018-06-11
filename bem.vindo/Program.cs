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
            Console.WriteLine("Bem Vindo!");
            
            Cliente cliente = new Cliente();
            try
            {
                Console.WriteLine("Digite o codigo do cliente: ");
                cliente.CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());
                Console.WriteLine("Digite o nome do cliente: ");
                cliente.Nome = Console.ReadLine();
                Console.WriteLine("Digite o idade do cliente: ");
                cliente.Idade = Convert.ToInt32(Console.ReadLine().ToString());
                Console.WriteLine("Digite estado civil do cliente: ");
                cliente.EstadoCivil = Console.ReadLine();
                Console.WriteLine("Digite o genero do cliente: ");
                cliente.Genero = Console.ReadLine();
                Console.Clear();

            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }



            for (int x = 1; x < 4; x++)
            {
                Endereco endereco = new Endereco();
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                Console.WriteLine("Digite rua:");
                endereco.Rua = Console.ReadLine();
                Console.WriteLine("Digite complemento:");
                endereco.Complemento = Console.ReadLine();
                Console.WriteLine("Digite CEP:");
                endereco.CEP = Console.ReadLine();
                Console.WriteLine("Digite bairro:");
                endereco.Bairro = Console.ReadLine();
                Console.WriteLine("Digite cidade:");
                endereco.Cidade = Console.ReadLine();
                cliente.lista.Add(endereco);
                Console.Clear();

            }
            cliente.InfoDoCliente();

        }
    }
}
