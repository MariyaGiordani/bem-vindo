using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bem.vindo.Models;
using bem.vindo_Util;
using GeneralDAO;
using Newtonsoft.Json;

namespace bem.vindo_Busines
{
    [Serializable]
    public class EnderecoBusiness
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

        public EnderecoBusiness CadastrarEndereco(Guid codigoCliente)
        {
            EnderecoBusiness enderecoBusiness = new EnderecoBusiness();
            enderecoBusiness.IdOfAddress();
            enderecoBusiness.CodigoDoCliente = codigoCliente;
            Console.WriteLine("Codigo do cliente: " + codigoCliente);
            Console.WriteLine("Escolha tipo de logradouro:");
            enderecoBusiness.Logradouro();
            Console.WriteLine("Digite nome da {0} :", TipoLogradouro);
            enderecoBusiness.NomeDoLogradouro();
            Console.WriteLine("Digite complemento:");
            enderecoBusiness.ComplementoEndereco();
            Console.WriteLine("Digite CEP:");
            enderecoBusiness.CEPEdndereco();
            Console.WriteLine("Digite bairro:");
            enderecoBusiness.BairroEndereco();
            Console.WriteLine("Digite cidade:");
            enderecoBusiness.CidadeEndereco();
            Console.WriteLine("\n");

            Endereco address = new Endereco();
            address.CodigoDoCliente = enderecoBusiness.CodigoDoCliente;
            address.IdAddress = enderecoBusiness.IdAddress;
            address.TipoLogradouro = enderecoBusiness.TipoLogradouro;
            address.NomeLogradouro = enderecoBusiness.NomeLogradouro;
            address.Complemento = enderecoBusiness.Complemento;
            address.CEP = enderecoBusiness.CEP;
            address.Bairro = enderecoBusiness.Bairro;
            address.Cidade = enderecoBusiness.Cidade;
            Insert(address);

            return enderecoBusiness;
        }

        public void Insert(Endereco address)
        {
            ProjectConnection pc = new ProjectConnection();
            EnderecoRepository er = new EnderecoRepository(pc);
            er.Update(address);
        }

        public EnderecoBusiness InfoDoEndereco()
        {
            EnderecoBusiness endereco = new EnderecoBusiness();
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
                    List<EnderecoBusiness> jsonFileEndereco = new List<EnderecoBusiness>();
                    string fullFile = fileutilEndereco.CarregarFromFile();
                    jsonFileEndereco = JsonConvert.DeserializeObject<List<EnderecoBusiness>>(fullFile);
                    if (jsonFileEndereco.Any(c => c.IdAddress.ToString() == IdAddress.ToString()))
                    {
                        Console.WriteLine("Codigo de cliente já existe!");
                    }
                    else
                    {
                        test = false;
                    }
                    test = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro na digitação!");

                }
            }
            return Guid.NewGuid();

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
            ProjectConnection pc = new ProjectConnection();
            EnderecoRepository er = new EnderecoRepository(pc);
            var address = er.GetById(addressid);
            var addressBusiness = loadAddressBusiness(address); 
        }

        public List<EnderecoBusiness> GetbyCode(string clientCode)
        {
            Guid code = Guid.Parse(clientCode);
            List<EnderecoBusiness> jsonFileAddress = new List<EnderecoBusiness>();
            string fullFile = fileutilEndereco.CarregarFromFile();
            jsonFileAddress = JsonConvert.DeserializeObject<List<EnderecoBusiness>>(fullFile);
            jsonFileAddress = jsonFileAddress.Where(c => c.CodigoDoCliente == code).ToList();
            foreach (var item in jsonFileAddress)
            {
                item.InfoDoEndereco();
            }
            return jsonFileAddress;
        }

        public List<EnderecoBusiness> ListAddressFromDB(Guid clientCode)
        {
            ProjectConnection pc = new ProjectConnection();
            EnderecoRepository enderecoRepository = new EnderecoRepository(pc);
            ClientBusiness clientBusiness = new ClientBusiness();
            List<Endereco> dbAddresses = enderecoRepository.GetAll(clientCode);
            List<EnderecoBusiness> addressesBusiness = new List<EnderecoBusiness>();
            dbAddresses.ForEach(
                (dbAddress) =>
                {
                    EnderecoBusiness addressBusiness = loadAddressBusiness(dbAddress);
                    addressesBusiness.Add(addressBusiness);
                });
            return addressesBusiness;
        }

        private EnderecoBusiness loadAddressBusiness(Endereco dbAddress)
        {
            EnderecoBusiness addressBusiness = new EnderecoBusiness();
            addressBusiness.CodigoDoCliente = dbAddress.CodigoDoCliente;
            addressBusiness.IdAddress = dbAddress.IdAddress;
            addressBusiness.TipoLogradouro = dbAddress.TipoLogradouro;
            addressBusiness.NomeLogradouro = dbAddress.NomeLogradouro;
            addressBusiness.Complemento = dbAddress.Complemento;
            addressBusiness.CEP = dbAddress.CEP;
            addressBusiness.Bairro = dbAddress.CEP;
            addressBusiness.Cidade = dbAddress.Cidade;
            addressBusiness.InfoDoEndereco();
            return addressBusiness;
        }

    }
}
