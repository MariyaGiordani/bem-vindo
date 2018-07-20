using bem.vindo.Models;
using bem.vindo_Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GeneralDAO;

namespace bem.vindo_Busines
{
    public class ClientBusiness
    {
        public EnumTipoCliente TipoCliente { get; set; }
        public Guid CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }

        public List<EnderecoBusiness> listaEndereco = new List<EnderecoBusiness>();
        private FileUtil fileutilCliente = new FileUtil(EnumTipoArquivo.Cliente);
        private FileUtil fileUtilClienteEndereco = new FileUtil(EnumTipoArquivo.ClienteEndereco);
        public ClientBusiness CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("\n======= Bem Vindo! ========");

            ClientBusiness clienteBusiness = new ClientBusiness();

            Console.WriteLine("Escolha tipo de cliente: ");
            clienteBusiness.TipoDeCliente();
            clienteBusiness.CodigoCliente();
            Console.WriteLine("Digite o nome do cliente: ");
            clienteBusiness.NomeCliente();
            clienteBusiness.IdadeCliente();
            Console.WriteLine("Digite estado civil do cliente: ");
            clienteBusiness.EstadoCivilCliente();
            Console.WriteLine("Digite o genero do cliente: ");
            clienteBusiness.TipoGeneros();
            Console.WriteLine("\n");


            Cliente client = new Cliente();
            client.TipoCliente = clienteBusiness.TipoCliente;
            client.CodigoDoCliente = clienteBusiness.CodigoDoCliente;
            client.Nome = clienteBusiness.Nome;
            client.Idade = clienteBusiness.Idade;
            client.EstadoCivil = clienteBusiness.EstadoCivil;
            client.Genero = clienteBusiness.Genero;
            Insert(client);

            EnderecoBusiness address = new EnderecoBusiness();
            for (int x = 1; x < 4; x++)
            {
                address = address.CadastrarEndereco(clienteBusiness.CodigoDoCliente);

                clienteBusiness.listaEndereco.Add(address);
            }

            return clienteBusiness;
        }

        public void Insert(Cliente client)
        {
            ProjectConnection pc = new ProjectConnection();
            ClienteRepository cr = new ClienteRepository(pc);
            cr.Update(client);
        }

        public void SaveClienteEndereco(List<ClientBusiness> listaCliente)
        {

            string fullFile = fileUtilClienteEndereco.CarregarFromFile();
            var clienteEnderecotemp = JsonConvert.SerializeObject(listaCliente);
            fileUtilClienteEndereco.Update(clienteEnderecotemp.ToString());
        }

        public void NomeCliente()
        {
            this.Nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(this.Nome))
            {
                if (string.IsNullOrWhiteSpace(this.Nome))
                {
                    Console.WriteLine("Nome é obrigatório.");
                }
                Console.WriteLine("Digite o nome do cliente: ");
                this.Nome = Console.ReadLine();
            }

        }

        public void IdadeCliente()
        {
            bool test = true;
            while (test)
            {
                try
                {
                    Console.WriteLine("Digite o idade do cliente: ");
                    this.Idade = Convert.ToInt32(Console.ReadLine().ToString());
                    test = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro na digitação!");

                }
            }

        }


        public void EstadoCivilCliente()
        {
            bool control = true;
            while (control)
            {
                Console.WriteLine("{0}  / {1}  / {2} / {3} ", EnumEstadoCivil.Solteiro.ToString(), EnumEstadoCivil.Casado.ToString(), EnumEstadoCivil.Viuvo.ToString(), EnumEstadoCivil.Divorciado.ToString());
                string respostaEstadoCivil = Console.ReadLine().ToUpper();
                switch (respostaEstadoCivil)
                {
                    case "SOLTEIRO":
                        EstadoCivil = EnumEstadoCivil.Solteiro;
                        control = false;
                        break;
                    case "CASADO":
                        EstadoCivil = EnumEstadoCivil.Casado;
                        control = false;
                        break;
                    case "VIUVO":
                        EstadoCivil = EnumEstadoCivil.Viuvo;
                        control = false;
                        break;
                    case "DIVORCIADO":
                        EstadoCivil = EnumEstadoCivil.Divorciado;
                        control = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        Console.WriteLine("Estado civil é obrigatório!");
                        break;
                }
            }
        }
        public Guid CodigoCliente()
        {
            bool test = true;
            while (test)
            {
                try
                {
                    Guid guid = Guid.NewGuid();

                    Console.WriteLine("Codigo do cliente: " + guid);
                    CodigoDoCliente = guid;
                    List<Cliente> jsonFileCliente = new List<Cliente>();
                    string fullFile = fileutilCliente.CarregarFromFile();
                    jsonFileCliente = JsonConvert.DeserializeObject<List<Cliente>>(fullFile);
                    if (jsonFileCliente.Any(c => c.CodigoDoCliente.ToString() == CodigoDoCliente.ToString()))
                    {
                        Console.WriteLine("Codigo de cliente já existe!");
                    }
                    else
                    {
                        test = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro na digitação!");

                }
            }
            return Guid.NewGuid();

        }

        public void TipoGeneros()
        {
            bool control = true;
            while (control)
            {
                Console.WriteLine("{0}  / {1}  / {2} ", EnumGenero.Masculino.ToString(), EnumGenero.Feminino.ToString(), EnumGenero.NA.ToString());
                string respostaGenero = Console.ReadLine().ToUpper();
                switch (respostaGenero)
                {
                    case "MASCULINO":
                        Genero = EnumGenero.Masculino;
                        control = false;
                        break;
                    case "FEMININO":
                        Genero = EnumGenero.Feminino;
                        control = false;
                        break;
                    case "NA":
                        Genero = EnumGenero.NA;
                        control = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        Console.WriteLine("Genero é obrigatório!");
                        break;
                }
            }
        }

        public void TipoDeCliente()
        {
            bool opcao = true;
            while (opcao)
            {
                Console.WriteLine("{0}  / {1} ", EnumTipoCliente.Fisica.ToString(), EnumTipoCliente.Juridica.ToString());
                string respostaTipoCliente = Console.ReadLine().ToUpper();
                switch (respostaTipoCliente)
                {
                    case "FISICA":
                        TipoCliente = EnumTipoCliente.Fisica;
                        opcao = false;
                        break;
                    case "JURIDICA":
                        TipoCliente = EnumTipoCliente.Juridica;
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
            Console.WriteLine("========= INFORMAÇÃO DO CLIENTE: ========");
            Console.WriteLine("Tipo de cliente:" + this.TipoCliente);
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("Nome do cliente:" + this.Nome);
            Console.WriteLine("Idade do cliente:" + this.Idade);
            Console.WriteLine("Estado civil do cliente:" + this.EstadoCivil);
            Console.WriteLine("Genero do cliente:" + this.Genero.ToString());
            //foreach (EnderecoBusiness dadosEndereco in listaEndereco)
            //{
            //    dadosEndereco.InfoDoEndereco();
            //}           
        }


        public void GetbyCode(string clientCode)
        {
            ProjectConnection pc = new ProjectConnection();
            ClienteRepository cr = new ClienteRepository(pc);
            var client = cr.GetByCode(clientCode);
            var clienBusiness = loadClientBusiness(client);
        }

        public List<ClientBusiness> LoadFromFile()
        {
            List<ClientBusiness> jsonFileCliente = new List<ClientBusiness>();
            string fullFile = fileutilCliente.CarregarFromFile();
            jsonFileCliente = JsonConvert.DeserializeObject<List<ClientBusiness>>(fullFile);
            foreach (var item in jsonFileCliente)
            {
                item.InfoDoCliente();
                var code = item.CodigoDoCliente;
                EnderecoBusiness endereco = new EnderecoBusiness();
                item.listaEndereco = endereco.GetbyCode(code.ToString());
            }
            return jsonFileCliente;
        }

        public void ListClientFromDB()
        {
            ProjectConnection pc = new ProjectConnection();
            ClienteRepository clienteRepository = new ClienteRepository(pc);
            List<Cliente> dbClientes = clienteRepository.GetAll();
            List<ClientBusiness> clientsBusiness = new List<ClientBusiness>();
            dbClientes.ForEach(
                (dbCliente) =>
                {
                    ClientBusiness clientBusiness = loadClientBusiness(dbCliente);
                    clientsBusiness.Add(clientBusiness);
                    EnderecoBusiness address = new EnderecoBusiness();
                    clientBusiness.listaEndereco = address.ListAddressFromDB(clientBusiness.CodigoDoCliente);
                });
        }

        private ClientBusiness loadClientBusiness(Cliente dbCliente)
        {
            ClientBusiness clientBusiness = new ClientBusiness();
            clientBusiness.TipoCliente = dbCliente.TipoCliente;
            clientBusiness.CodigoDoCliente = dbCliente.CodigoDoCliente;
            clientBusiness.Nome = dbCliente.Nome;
            clientBusiness.Idade = dbCliente.Idade;
            clientBusiness.EstadoCivil = dbCliente.EstadoCivil;
            clientBusiness.Genero = dbCliente.Genero;
            clientBusiness.InfoDoCliente();
            return clientBusiness;
        }
    }
}
