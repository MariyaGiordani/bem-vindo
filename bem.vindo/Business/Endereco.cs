using bem.vindo.Utils;
using bem.vindo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bem.vindo.Business
{
    [Serializable]
    public class Endereco
    {
        public int CodigoDoCliente { get; set; }
        public EnumTipoLogradouro TipoLogradouro { get; set; }
        public String NomeLogradouro { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }

        public Endereco CadastrarEndereco()
        {
            Endereco endereco = new Endereco();
            Console.WriteLine("Escolha tipo de logradouro:");
            Logradouro();
            Console.WriteLine("Digite nome da {0} :", this.TipoLogradouro);
            NomeDoLogradouro();
            Console.WriteLine("Digite complemento:");
            ComplementoEndereco();
            Console.WriteLine("Digite CEP:");
            CEPEdndereco();
            Console.WriteLine("Digite bairro:");
            BairroEndereco();
            Console.WriteLine("Digite cidade:");
            CidadeEndereco();
            Console.Clear();
            return endereco;
        }
         public void InfoEndereco()
        {
            int numEndereco = 0;
            foreach (Endereco dadosEndereco in listaEndereco)
            {
                numEndereco++;
                Console.WriteLine("\n========= INFORMAÇÃO DO ENDEREÇO:" + numEndereco + " ========");
                Console.WriteLine("Codigo do cliente:" + dadosEndereco.CodigoDoCliente);
                Console.WriteLine("" + dadosEndereco.TipoLogradouro + " : " + dadosEndereco.NomeLogradouro);
                Console.WriteLine("Complemento:" + dadosEndereco.Complemento);
                Console.WriteLine("CEP:" + dadosEndereco.CEP);
                Console.WriteLine("Bairro:" + dadosEndereco.Bairro);
                Console.WriteLine("Cidade:" + dadosEndereco.Cidade);
            }
            Console.ReadLine();
        }

        public String RetornarStringEndereco()
        {

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var endereco in listaEndereco)
            {
                stringBuilder.AppendLine("Endereço do cliente:");
                stringBuilder.Append("Tipo de logradouro:");
                stringBuilder.AppendLine(endereco.TipoLogradouro.ToString());
                stringBuilder.Append("Nome do logradouro:");
                stringBuilder.AppendLine(endereco.NomeLogradouro);
                stringBuilder.Append("Complemento:");
                stringBuilder.AppendLine(endereco.Complemento);
                stringBuilder.Append("CEP:");
                stringBuilder.AppendLine(endereco.CEP);
                stringBuilder.Append("Bairro:");
                stringBuilder.AppendLine(endereco.Bairro);
                stringBuilder.Append("Cidade:");
                stringBuilder.AppendLine(endereco.Cidade);
                stringBuilder.AppendLine();
            }

            String descricao = stringBuilder.ToString();
            return descricao;
        }

        public void NomeDoLogradouro()
        {
            this.NomeLogradouro = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(this.NomeLogradouro))
            {
                if (string.IsNullOrWhiteSpace(this.NomeLogradouro))
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
            while (string.IsNullOrWhiteSpace(this.Complemento))
            {
                if (string.IsNullOrWhiteSpace(this.Complemento))
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
            while (string.IsNullOrWhiteSpace(this.CEP))
            {
                if (string.IsNullOrWhiteSpace(this.CEP))
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
            while (string.IsNullOrWhiteSpace(this.Bairro))
            {
                if (string.IsNullOrWhiteSpace(this.Bairro))
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
            while (string.IsNullOrWhiteSpace(this.Cidade))
            {
                if (string.IsNullOrWhiteSpace(this.Cidade))
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
                Console.WriteLine("{0} / {1}  / {2} ", EnumTipoLogradouro.Avenida.ToString(), EnumTipoLogradouro.Rua.ToString(), EnumTipoLogradouro.Travessa.ToString());
                string respostaLogradoura = Console.ReadLine().ToUpper();
                switch (respostaLogradoura)
                {
                    case "AVENIDA":
                        TipoLogradouro = EnumTipoLogradouro.Avenida;
                        tipo = false;
                        break;
                    case "RUA":
                        TipoLogradouro = EnumTipoLogradouro.Rua;
                        tipo = false;
                        break;
                    case "TRAVESSA":
                        TipoLogradouro = EnumTipoLogradouro.Travessa;
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
