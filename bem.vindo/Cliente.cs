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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoDoCliente"></param>
        /// <param name="nome"></param>
        /// <param name="idade"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="genero"></param>
        public void InfoDoCliente()
        {
            Console.WriteLine("\n=========== INFORMAÇÃO DO CLIENTE =========");
            Console.WriteLine("Codigo do cliente: " + this.CodigoDoCliente);
            Console.WriteLine("Nome do cliente: " + this.Nome);
            Console.WriteLine("Idade do cliente: " + this.Idade);
            Console.WriteLine("Estado civil do cliente: " + this.EstadoCivil);
            Console.WriteLine("Genero do cliente: " + this.Genero);
        }
    }
}
