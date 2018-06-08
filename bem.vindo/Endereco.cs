using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class Endereco
    {
        public String Rua { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }

        public void InfDoEndereco()
        {
            Console.WriteLine("\n=========== INFORMAÇÃO DO ENDEREÇO =========");
            Console.WriteLine("Rua: " + this.Rua);
            Console.WriteLine("Complemento: " + this.Complemento);
            Console.WriteLine("CEP: " + this.CEP);
            Console.WriteLine("Bairro: " + this.Bairro);
            Console.WriteLine("Cidade: " + this.Cidade);
            Console.ReadLine();
        }
    }
}
