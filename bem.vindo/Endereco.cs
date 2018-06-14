using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class Endereco
    {
        public int CodigoDoCliente { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public String NomeLogradouro { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }

        public void Logradouro()
        {
            bool tipo = true;
            while (tipo)
            {
                Console.WriteLine("{0} - A / {1} - R / {2} - T", TipoLogradouro.Avenida.ToString(), TipoLogradouro.Rua.ToString(), TipoLogradouro.Travessa.ToString());
                string respostaGenero = Console.ReadLine().ToUpper();
                switch (respostaGenero)
                {
                    case "A":
                        this.TipoLogradouro = TipoLogradouro.Avenida;
                        tipo = false;
                        break;
                    case "R":
                        this.TipoLogradouro = TipoLogradouro.Rua;
                        tipo = false;
                        break;
                    case "T":
                        this.TipoLogradouro = TipoLogradouro.Travessa;
                        tipo = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        break;
                }
            }
        }

    }
}
