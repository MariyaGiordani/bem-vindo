using bem.vindo.Utils;
using bem.vindo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bem.vindo.Model;
using System.IO;
using Newtonsoft.Json;

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

        public Endereco CadastrarEndereco(Guid codigoCliente)
        {
            Endereco endereco = new Endereco();
            endereco.IdOfAddress();
            endereco.CodigoDoCliente = codigoCliente;
            Console.WriteLine("Codigo do cliente: " + codigoCliente);
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
            List<Endereco> jsonFileEndereco = new List<Endereco>();
            string fullFile = fileutilEndereco.CarregarFromFile();
            jsonFileEndereco = JsonConvert.DeserializeObject<List<Endereco>>(fullFile);
            if (jsonFileEndereco == null)
            {
                jsonFileEndereco = new List<Endereco>();
            }
            jsonFileEndereco.Add(endereco);
            String newStringCliente = JsonConvert.SerializeObject(jsonFileEndereco);
            fileutilEndereco.Update(newStringCliente, true);
            Console.Clear();
            return endereco;
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

        public void GetbyId(string addressid)
        {
            Guid id = Guid.Parse(addressid);
            List<Endereco> jsonFileAddress = new List<Endereco>();
            string fullFile = fileutilEndereco.CarregarFromFile();
            jsonFileAddress = JsonConvert.DeserializeObject<List<Endereco>>(fullFile);
            var filterAddress = jsonFileAddress.FirstOrDefault(c => c.IdAddress == id);
            filterAddress.InfoDoEndereco();
        }

        public List<Endereco> GetbyCode(string clientCode)
        {
            Guid code = Guid.Parse(clientCode);
            List<Endereco> jsonFileAddress = new List<Endereco>();
            string fullFile = fileutilEndereco.CarregarFromFile();
            jsonFileAddress = JsonConvert.DeserializeObject<List<Endereco>>(fullFile);
            jsonFileAddress = jsonFileAddress.Where(c => c.CodigoDoCliente == code).ToList();
            foreach (var item in jsonFileAddress)
            {
                item.InfoDoEndereco();
            }
            return jsonFileAddress;
        }
    }
}
