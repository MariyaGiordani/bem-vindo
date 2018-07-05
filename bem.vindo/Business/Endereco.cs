using bem.vindo.Utils;
using bem.vindo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bem.vindo.Model;
using System.IO;

namespace bem.vindo.Business
{
    [Serializable]
    public class Endereco
    {
        public Guid IdAddress { get; set; }
        public Guid CodigoDoCliente { get; set; }
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
            endereco.IdOfAddress();
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
            Console.WriteLine("Id do endereço:" + this.IdAddress);
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("" + this.TipoLogradouro + " : " + this.NomeLogradouro);
            Console.WriteLine("Complemento:" + this.Complemento);
            Console.WriteLine("CEP:" + this.CEP);
            Console.WriteLine("Bairro:" + this.Bairro);
            Console.WriteLine("Cidade:" + this.Cidade);
            return endereco;
        }

        public String RetornarStringEndereco()
        {
            String separador = "|";
            String separadorFinal = "#";
            StringBuilder stringBuilder = new StringBuilder();
            //foreach (var endereco in listaEndereco)
            //{
            stringBuilder.AppendLine(" " + IdAddress.ToString() + separador);
            stringBuilder.AppendLine(" " + CodigoDoCliente.ToString() + separador);
            stringBuilder.AppendLine(" " + TipoLogradouro.ToString() + separador);
            stringBuilder.AppendLine(" " + NomeLogradouro + separador);
            stringBuilder.AppendLine(" " + Complemento + separador);
            stringBuilder.AppendLine(" " + CEP + separador);
            stringBuilder.AppendLine(" " + Bairro + separador);
            stringBuilder.AppendLine(" " + Cidade + separador);
            stringBuilder.Append(" " + separadorFinal);
            //}
            String descricao = stringBuilder.ToString();
            return descricao;
        }

        public Guid IdOfAddress()
        {
            bool test = true;
            while (test)
            {
                try
                {
                    Guid guid = Guid.NewGuid();

                    Console.WriteLine("Id do endereço: " + guid);
                    IdAddress = guid;
                    procuraNoTxt();
                        test = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro na digitação!");

                }
            }
            return Guid.NewGuid();

        }

        public void procuraNoTxt()
        {
            if (File.Exists(@"c:\temp\CADASTROENDERECO.TXT"))
            {
                String encontro = string.Empty;
                String procuraCodigoDoCliente = this.CodigoDoCliente.ToString();
                using (StreamReader sr = new StreamReader(@"c:\temp\CADASTROENDERECO.TXT"))
                {
                    String input = sr.ReadToEnd();
                    encontro = "Id do endereço: " + procuraCodigoDoCliente.ToString();
                    if (input.Contains(encontro))
                    {
                        Console.WriteLine("Exista o Id do endereço" + procuraCodigoDoCliente + " no arquivo TXT");
                        IdOfAddress();
                    }
                }
            }
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

        public List<Endereco> LoadFromFile(Guid clientCode)
        {
            var list = LoadFromFile();
            var returnAddress = list.Where(c => c.CodigoDoCliente == clientCode).ToList();
           
            return returnAddress;
        }

        public List<Endereco> LoadFromFile()
        {
            List<Endereco> listaEndereco = new List<Endereco>();

            FileUtil fileutilEndereco = new FileUtil(EnumTipoArquivo.Endereco);

            List<string> tempEndereco = fileutilEndereco.CarregarFromFile('#');

            foreach (var item in tempEndereco)
            {
                List<string> parametrosEndereco = fileutilEndereco.CarregarFromString('|', item);

                Endereco enderecoNovo = new Endereco();
                int count = parametrosEndereco.Count;
                if (count >= 8 )
                {
                    var idAddress = parametrosEndereco[0];
                    enderecoNovo.IdAddress = Guid.Parse(idAddress);

                    var codigoDoCliente = parametrosEndereco[1];
                    enderecoNovo.CodigoDoCliente = Guid.Parse(codigoDoCliente);

                    var tipoLogradouro = parametrosEndereco[2];
                    if (tipoLogradouro.Trim() == "Avenida")
                    {
                        enderecoNovo.TipoLogradouro = EnumTipoLogradouro.Avenida;
                    }
                    else if (tipoLogradouro.Trim() == "Rua")
                    {
                        enderecoNovo.TipoLogradouro = EnumTipoLogradouro.Rua;
                    }
                    else if (tipoLogradouro.Trim() == "Travessa")
                    {
                        enderecoNovo.TipoLogradouro = EnumTipoLogradouro.Travessa;
                    }

                    var nomeLogradouro = parametrosEndereco[3];
                    enderecoNovo.NomeLogradouro = nomeLogradouro;

                    var complemento = parametrosEndereco[4];
                    enderecoNovo.Complemento = complemento;

                    var cep = parametrosEndereco[5];
                    enderecoNovo.CEP = cep;

                    var bairro = parametrosEndereco[6];
                    enderecoNovo.Bairro = bairro;

                    var cidade = parametrosEndereco[7];
                    enderecoNovo.Cidade = cidade;
                }

                listaEndereco.Add(enderecoNovo);
            }
            return listaEndereco;
        }
    }
}
