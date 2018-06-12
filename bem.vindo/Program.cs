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

            }
            catch (Exception ex)
            {
                Console.WriteLine("Codigo com erro!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);
            }
            try
            {
                Console.WriteLine("Digite o nome do cliente: ");
                cliente.Nome = Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Nome está com erro!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);
            }
            try
            {
                Console.WriteLine("Digite o idade do cliente: ");
                cliente.Idade = Convert.ToInt32(Console.ReadLine().ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Idade está com errado!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);

            }
            try
            {
                Console.WriteLine("Digite estado civil do cliente: ");
                cliente.EstadoCivil = Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Estado civil está com errado!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);
            }
            try
            {
                Console.WriteLine("Digite o genero do cliente: ");
                cliente.Genero = Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Genero está com errado!");
                Console.WriteLine("Mensagem de erro:" + ex.Message);
            }
            Console.Clear();



            for (int x = 1; x < 4; x++)
            {
                Endereco endereco = new Endereco();
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                try
                {
                    Console.WriteLine("Digite rua:");
                    endereco.Rua = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Rua está com errado!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                }
                try
                {
                    Console.WriteLine("Digite complemento:");
                    endereco.Complemento = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Complemento está com errado!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                }
                try
                {
                    Console.WriteLine("Digite CEP:");
                    endereco.CEP = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("CEP está com errado!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                }
                try
                {
                    Console.WriteLine("Digite bairro:");
                    endereco.Bairro = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Bairro está com errado!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                }
                try
                {
                    Console.WriteLine("Digite cidade:");
                    endereco.Cidade = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Cidade está com errado!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                }
                cliente.lista.Add(endereco);
                Console.Clear();

            }
            cliente.InfoDoCliente();

        }
    }
}
