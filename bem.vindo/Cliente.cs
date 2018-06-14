﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class Cliente
    {
        public TipoCliente TipoCliente { get; set; }
        public int CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String EstadoCivil { get; set; }
        public Genero Genero { get; set; }

        public List<Endereco> listaEndereco = new List<Endereco>();

        public void TipoGeneros()
        {
            bool control = true;
            while (control)
            {
                Console.WriteLine("{0} - M / {1} - F / {2} - N", Genero.Masculino.ToString(), Genero.Feminino.ToString(), Genero.NA.ToString());
                string respostaGenero = Console.ReadLine().ToUpper();
                switch (respostaGenero)
                {
                    case "M":
                        Genero = Genero.Masculino;
                        control = false;
                        break;
                    case "F":
                        Genero = Genero.Feminino;
                        control = false;
                        break;
                    case "N":
                        Genero = Genero.NA;
                        control = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        break;
                }
            }
        }

        public void TipoDeCliente()
        {
            bool opcao = true;
            while (opcao)
            {
                Console.WriteLine("{0} - F / {1} - J", TipoCliente.Fisical.ToString(), TipoCliente.Juridica.ToString());
                string respostaGenero = Console.ReadLine().ToUpper();
                switch (respostaGenero)
                {
                    case "F":
                        TipoCliente = TipoCliente.Fisical;
                        opcao = false;
                        break;
                    case "J":
                        TipoCliente = TipoCliente.Juridica;
                        opcao = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        break;
                }
            }
        }

        public void InfoDoCliente()
        {
            int numEndereco = 0;
            Console.WriteLine("========= INFORMAÇÃO DO CLIENTE: ========");
            Console.WriteLine("Tipo de cliente:" + this.TipoCliente);
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("Nome do cliente:" + this.Nome);
            Console.WriteLine("Idade do cliente:" + this.Idade);
            Console.WriteLine("Estado civil do cliente:" + this.EstadoCivil);
            Console.WriteLine("Genero do cliente:" + this.Genero.ToString());

            foreach (Endereco dadosEndereco in listaEndereco)
            {
                numEndereco++;
                Console.WriteLine("\n========= INFORMAÇÃO DO ENDEREÇO:" + numEndereco + " ========");
                Console.WriteLine("Codigo do cliente:" + dadosEndereco.CodigoDoCliente);
                Console.WriteLine("" + dadosEndereco.TipoLogradouro + ": " + dadosEndereco.NomeLogradouro);
                Console.WriteLine("Complemento:" + dadosEndereco.Complemento);
                Console.WriteLine("CEP:" + dadosEndereco.CEP);
                Console.WriteLine("Bairro:" + dadosEndereco.Bairro);
                Console.WriteLine("Cidade:" + dadosEndereco.Cidade);
            }
            Console.ReadLine();
        }



    }
}
