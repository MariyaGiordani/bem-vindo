using System;
using System.Collections.Generic;
using System.Linq;
using bem.vindo.Business;
using System.Text;
using System.Threading.Tasks;
using bem.vindo.Utils;
using bem.vindo.Util;
using System.IO;

namespace bem.vindo.Model
{
    public class Cliente
    {
        public EnumTipoCliente TipoCliente { get; set; }
        public Guid CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }

        public List<Endereco> listaEndereco = new List<Endereco>();
        private FileUtil fileutilCliente = new FileUtil(EnumTipoArquivo.Cliente);
        public Cliente CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("\n======= Bem Vindo! ========");

            Cliente cliente = new Cliente();

            Console.WriteLine("Escolha tipo de cliente: ");
            cliente.TipoDeCliente();
            cliente.CodigoCliente();
            //Console.WriteLine(cliente.CodigoDoCliente = this.CodigoCliente());
            Console.WriteLine("Digite o nome do cliente: ");
            cliente.NomeCliente();
            cliente.IdadeCliente();
            Console.WriteLine("Digite estado civil do cliente: ");
            cliente.EstadoCivilCliente();
            Console.WriteLine("Digite o genero do cliente: ");
            cliente.TipoGeneros();
            String newStringCliente = cliente.RetornarStringCliente();
            fileutilCliente.Update(newStringCliente);
            Console.Clear();
            Endereco endereco = new Endereco();
            for (int x = 1; x < 4; x++)
            {
                endereco = endereco.CadastrarEndereco();
                cliente.listaEndereco.Add(endereco);
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                endereco.GravarEndereco(endereco);
            }
            cliente.InfoDoCliente();
            Console.Clear();
            return cliente;
        }

        public String RetornarStringCliente()
        {
            String separador = "|";
            String separadorFinal = "#";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(" " + TipoCliente.ToString() + separador);
            stringBuilder.AppendLine(" " + CodigoDoCliente.ToString() + separador);
            stringBuilder.AppendLine(" " + Nome + separador);
            stringBuilder.AppendLine(" " + Idade.ToString() + separador);
            stringBuilder.AppendLine(" " + EstadoCivil.ToString() + separador);
            stringBuilder.AppendLine(" " + Genero.ToString() + separador);
            stringBuilder.Append(" " + separadorFinal);

            String descricao = stringBuilder.ToString();
            return descricao;
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
                    procuraNoTxt();
                    if (CadastroGeral.listaCliente.Any(c => c.CodigoDoCliente.ToString() == CodigoDoCliente.ToString()))
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

        public void procuraNoTxt()
        {
            if (File.Exists(@"c:\temp\CADASTROCLIENTE.TXT"))
            {
                String encontro = string.Empty;
                String procuraCodigoDoCliente = this.CodigoDoCliente.ToString();
                using (StreamReader sr = new StreamReader(@"c:\temp\CADASTROCLIENTE.TXT"))
                {
                    String input = sr.ReadToEnd();
                    encontro = "Codigo do Cliente: " + procuraCodigoDoCliente.ToString();
                    if (input.Contains(encontro))
                    {
                        Console.WriteLine("Exista o codigo do cliente " + procuraCodigoDoCliente + " no arquivo TXT");
                        CodigoCliente();
                    }
                }
            }
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
            foreach (Endereco dadosEndereco in listaEndereco)
            {
                dadosEndereco.InfoDoEndereco();
            }
            Console.ReadLine();
        }


        public void GetbyCode(string clientCode)
        {
            Guid code = Guid.Parse(clientCode);
            List<Cliente> clientlist = LoadFromFile(true,false);
            var filterClient = clientlist.FirstOrDefault(c => c.CodigoDoCliente == code);
            filterClient.InfoDoCliente();
        }

        /// <summary>
        ///  Carrega Arquivo de cliente
        /// </summary>
        /// <param name="loadclient">boolean</param>
        /// <param name="loadendereco">boolean</param>
        /// <returns>Retorna lisat de clientes</returns>
        public List<Cliente> LoadFromFile(bool loadclient, bool loadendereco)
        { 
            List<Cliente> listaCliente = new List<Cliente>();

            FileUtil fileutilCliente = new FileUtil(EnumTipoArquivo.Cliente);
            List<string> temp = fileutilCliente.CarregarFromFile('#');
            foreach (var item in temp)
            {

                List<string> parametros = fileutilCliente.CarregarFromString('|', item);

                Cliente clienteNovo = new Cliente();
                if (loadclient)
                {
                    int count = parametros.Count;
                    if (count >= 7)
                    {
                        var tipoClinte = parametros[0];
                        if (tipoClinte.Trim() == "Fisica")
                        {
                            clienteNovo.TipoCliente = EnumTipoCliente.Fisica;
                        }
                        else
                        {
                            clienteNovo.TipoCliente = EnumTipoCliente.Juridica;
                        }

                        var codigoDoCliente = parametros[1];
                        clienteNovo.CodigoDoCliente = Guid.Parse(codigoDoCliente);
                        var nome = parametros[2];
                        clienteNovo.Nome = nome;
                        var idade = parametros[3];
                        clienteNovo.Idade = Convert.ToInt32(idade);

                        var estadoCivil = parametros[4];
                        if (estadoCivil.Trim() == "Solteiro")
                        {
                            clienteNovo.EstadoCivil = EnumEstadoCivil.Solteiro;
                        }
                        else if (estadoCivil.Trim() == "Casado")
                        {
                            clienteNovo.EstadoCivil = EnumEstadoCivil.Casado;
                        }
                        else if (estadoCivil.Trim() == "Viuvo")
                        {
                            clienteNovo.EstadoCivil = EnumEstadoCivil.Viuvo;
                        }
                        else
                        {
                            clienteNovo.EstadoCivil = EnumEstadoCivil.Divorciado;
                        }

                        var genero = parametros[5];
                        if (genero.Trim() == "Feminino")
                        {
                            clienteNovo.Genero = EnumGenero.Feminino;
                        }
                        else if (genero.Trim() == "Masculino")
                        {
                            clienteNovo.Genero = EnumGenero.Masculino;
                        }
                        else
                        {
                            clienteNovo.Genero = EnumGenero.NA;
                        }
                    }
                   if(loadendereco)
                    { 
                        Endereco endereco = new Endereco();
                        clienteNovo.listaEndereco = endereco.LoadFromFile(clienteNovo.CodigoDoCliente);
                    }
                    listaCliente.Add(clienteNovo);
                }
            }
            return listaCliente;
        }
    }
}
