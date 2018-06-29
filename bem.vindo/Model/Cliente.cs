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
        public int CodigoDoCliente { get; set; }
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Informação cliente: |,|");
            stringBuilder.Append("Tipo Cliente: ");
            stringBuilder.AppendLine(TipoCliente.ToString() + "|,|");
            stringBuilder.Append("Codigo do Cliente: ");
            stringBuilder.AppendLine(CodigoDoCliente.ToString() + "|,|");
            stringBuilder.Append("Nome do Cliente: ");
            stringBuilder.AppendLine(Nome + "|,|");
            stringBuilder.Append("Idade do Cliente: ");
            stringBuilder.AppendLine(Idade.ToString() + "|,|");
            stringBuilder.Append("Estado Civil do Cliente: ");
            stringBuilder.AppendLine(EstadoCivil.ToString() + "|,|");
            stringBuilder.Append("Genero do Cliente: ");
            stringBuilder.AppendLine(Genero.ToString() + "|,|");
            stringBuilder.Append("||");

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
        public void CodigoCliente()
        {
            bool test = true;
            while (test)
            {
                try
                {
                    Console.WriteLine("Digite codigo do cliente: ");
                    this.CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());
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
            //return Guid.NewGuid();

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
    }
}
