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


        public void NomeDoLogradouro()
        {
            this.NomeLogradouro = Console.ReadLine();
            while (string.IsNullOrEmpty(this.NomeLogradouro))
            {
                if (string.IsNullOrEmpty(this.NomeLogradouro))
                {
                    Console.WriteLine("Nome do logradouro é obrigatório.");
                }
                Console.WriteLine("Digite o nome do logradouro: ");
                this.NomeLogradouro = Console.ReadLine();
            }

        }

        public void ComplementoEndereco()
        {
            this.Complemento = Console.ReadLine();
            while (string.IsNullOrEmpty(this.Complemento))
            {
                if (string.IsNullOrEmpty(this.Complemento))
                {
                    Console.WriteLine("Complemento é obrigatório.");
                }
                Console.WriteLine("Digite complemento: ");
                this.Complemento = Console.ReadLine();
            }

        }

        public void CEPEdndereco()
        {
            this.CEP = Console.ReadLine();
            while (string.IsNullOrEmpty(this.CEP))
            {
                if (string.IsNullOrEmpty(this.CEP))
                {
                    Console.WriteLine("CEP é obrigatório.");
                }
                Console.WriteLine("Digite CEP: ");
                this.CEP = Console.ReadLine();
            }

        }
        public void BairroEndereco()
        {
            this.Bairro = Console.ReadLine();
            while (string.IsNullOrEmpty(this.Bairro))
            {
                if (string.IsNullOrEmpty(this.Bairro))
                {
                    Console.WriteLine("Bairro é obrigatório.");
                }
                Console.WriteLine("Digite bairro: ");
                this.Bairro = Console.ReadLine();
            }

        }
        public void CidadeEndereco()
        {
            this.Cidade = Console.ReadLine();
            while (string.IsNullOrEmpty(this.Cidade))
            {
                if (string.IsNullOrEmpty(this.Cidade))
                {
                    Console.WriteLine("Cidade é obrigatório.");
                }
                Console.WriteLine("Digite o nome do logradouro: ");
                this.Cidade = Console.ReadLine();
            }

        }
        public void Logradouro()
        {
            bool tipo = true;
            while (tipo)
            {
                Console.WriteLine("{0} / {1}  / {2} ", TipoLogradouro.Avenida.ToString(), TipoLogradouro.Rua.ToString(), TipoLogradouro.Travessa.ToString());
                string respostaLogradoura = Console.ReadLine().ToUpper();
                switch (respostaLogradoura)
                {
                    case "AVENIDA":
                        TipoLogradouro = TipoLogradouro.Avenida;
                        tipo = false;
                        break;
                    case "RUA":
                        TipoLogradouro = TipoLogradouro.Rua;
                        tipo = false;
                        break;
                    case "TREVASSA":
                        TipoLogradouro = TipoLogradouro.Travessa;
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
