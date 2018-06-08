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
            
            Cliente cliente1 = new Cliente();
            Endereco cliente = new Endereco();

            
            Console.WriteLine("Digite o codigo do cliente: ");
            cliente1.CodigoDoCliente = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do cliente: ");
            cliente1.Nome = Console.ReadLine();
            Console.WriteLine("Digite o idade do cliente: ");
            cliente1.Idade = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite estado civil do cliente: ");
            cliente1.EstadoCivil = Console.ReadLine();
            Console.WriteLine("Digite o genero do cliente: ");
            cliente1.Genero = Console.ReadLine();
            cliente1.InfoDoCliente();

            Console.WriteLine("\nDigite rua: ");
            cliente.Rua = Console.ReadLine();
            Console.WriteLine("Digite complemento: ");
            cliente.Complemento = Console.ReadLine();
            Console.WriteLine("Digite CEP: " );
            cliente.CEP = Console.ReadLine();
            Console.WriteLine("Digite bairro: ");
            cliente.Bairro = Console.ReadLine();
            Console.WriteLine("Digite cidade: ");
            cliente.Cidade = Console.ReadLine();
            cliente.InfDoEndereco();


        }
    }
}
