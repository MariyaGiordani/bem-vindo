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
            Endereco endereco = new Endereco();

            
            Console.WriteLine("Digite o codigo do cliente: ");
            cliente.CodigoDoCliente = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Digite o idade do cliente: ");
            cliente.Idade = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite estado civil do cliente: ");
            cliente.EstadoCivil = Console.ReadLine();
            Console.WriteLine("Digite o genero do cliente: ");
            cliente.Genero = Console.ReadLine();
            cliente.InfoDoCliente();

            Console.WriteLine("\nDigite rua: ");
            endereco.Rua = Console.ReadLine();
            Console.WriteLine("Digite complemento: ");
            endereco.Complemento = Console.ReadLine();
            Console.WriteLine("Digite CEP: " );
            endereco.CEP = Console.ReadLine();
            Console.WriteLine("Digite bairro: ");
            endereco.Bairro = Console.ReadLine();
            Console.WriteLine("Digite cidade: ");
            endereco.Cidade = Console.ReadLine();
            endereco.InfDoEndereco();


        }
    }
}
