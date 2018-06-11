using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class Cliente
    {
        public int CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String EstadoCivil { get; set; }
        public String Genero { get; set; }
        int numEndereco = 0;

        public List<Endereco> lista = new List<Endereco>();

        public void InfoDoCliente()
        {
            Console.WriteLine("========= INFORMAÇÃO DO CLIENTE ========");
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("Nome do cliente:" + this.Nome);
            Console.WriteLine("Idade do cliente:" + this.Idade);
            Console.WriteLine("Estado civil do cliente:" + this.EstadoCivil);
            Console.WriteLine("Genero do cliente:" + this.Genero);
            foreach (Endereco dados in lista)
            {
                numEndereco++;
                Console.WriteLine("\n========= INFORMAÇÃO DO ENDEREÇO:" + numEndereco + " ========");
                Console.WriteLine("Rua:" + dados.Rua);
                Console.WriteLine("Complemento:" + dados.Complemento);
                Console.WriteLine("CEP:" + dados.CEP);
                Console.WriteLine("Bairro:" + dados.Bairro);
                Console.WriteLine("Cidade:" + dados.Cidade);
            }
            Console.ReadLine();
        }

    }
}
