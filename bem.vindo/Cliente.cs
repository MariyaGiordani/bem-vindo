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
        public Cliente(int codigoDoCliente, String nome, int idade, String estadoCivil, String genero)
        {
            CodigoDoCliente = codigoDoCliente;
            Nome = nome;
            Idade = idade;
            EstadoCivil = estadoCivil;
            Genero = genero;
        }
    }
}
