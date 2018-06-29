using bem.vindo.Utils;
using bem.vindo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bem.vindo.Model;

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

        private FileUtil fileutilEndereco = new FileUtil(EnumTipoArquivo.Endereco);

        public Endereco CadastrarEndereco()
        {
            Endereco endereco = new Endereco();
            Console.WriteLine("Escolha tipo de logradouro:");
            endereco.Logradouro();
            Console.WriteLine("Digite nome da {0} :", TipoLogradouro);
            endereco.NomeDoLogradouro();
            Console.WriteLine("Digite complemento:");
            endereco.ComplementoEndereco();
            Console.WriteLine("Digite CEP:");
            endereco.CEPEdndereco();
            Console.WriteLine("Digite bairro:");
            endereco.BairroEndereco();
            Console.WriteLine("Digite cidade:");
            endereco.CidadeEndereco();            
            Console.Clear();
            return endereco;
        }

        public void GravarEndereco(Endereco endereco)
        {
            String newStringEndereco = endereco.RetornarStringEndereco();
            fileutilEndereco.Update(newStringEndereco);
        }

        public Endereco InfoDoEndereco()
        {
            Endereco endereco = new Endereco();
            Console.WriteLine("\n========= INFORMAÇÃO DO ENDEREÇO: ========");
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("" + TipoLogradouro + " : " + NomeLogradouro);
            Console.WriteLine("Complemento:" + Complemento);
            Console.WriteLine("CEP:" + CEP);
            Console.WriteLine("Bairro:" + Bairro);
            Console.WriteLine("Cidade:" + Cidade);
            return endereco;
        }

        public String RetornarStringEndereco()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //foreach (var endereco in listaEndereco)
            //{
            stringBuilder.Append("Codigo do Cliente: ");
            stringBuilder.AppendLine(CodigoDoCliente.ToString() + "|,|");
            stringBuilder.AppendLine("Endereço do cliente:  |,| ");
            stringBuilder.Append("Tipo de logradouro:");
            stringBuilder.AppendLine(TipoLogradouro.ToString() + "|,|");
            stringBuilder.Append("Nome do logradouro:");
            stringBuilder.AppendLine(NomeLogradouro + "|,|");
            stringBuilder.Append("Complemento:");
            stringBuilder.AppendLine(Complemento + "|,|");
            stringBuilder.Append("CEP:");
            stringBuilder.AppendLine(CEP + "|,|");
            stringBuilder.Append("Cidade:");
            stringBuilder.AppendLine(Cidade + "|,|");
            stringBuilder.Append("||");
            //}
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
