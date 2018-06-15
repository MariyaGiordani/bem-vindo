using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class Cliente
    {
        public TipoCliente TipoCliente { get; set; }
        public int CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String EstadoCivil { get; set; }
        public Genero Genero { get; set; }

        public List<Endereco> listaEndereco = new List<Endereco>();

        public void NomeCliente()
        {
            this.Nome = Console.ReadLine();
            while (string.IsNullOrEmpty(this.Nome))
            {
                if (string.IsNullOrEmpty(this.Nome))
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
                    while (string.IsNullOrEmpty(this.Idade.ToString()))
                    {
                        if (string.IsNullOrEmpty(this.Idade.ToString()))
                        {
                            Console.WriteLine("Idade é obrigatório.");
                        }
                    }
                    test = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na digitação!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                    Console.ReadKey();

                }
            }

        }

        public void EstadoCivilCliente()
        {
            this.EstadoCivil = Console.ReadLine();
            while (string.IsNullOrEmpty(this.EstadoCivil))
            {
                if (string.IsNullOrEmpty(this.EstadoCivil))
                {
                    Console.WriteLine("Estado civil é obrigatório.");
                }
                Console.WriteLine("Digite o estado civil do cliente: ");
                this.EstadoCivil = Console.ReadLine();
            }

        }
        public void CodigoCliente(List<Cliente> clientes)
        {
            bool test = true;
            while (test)
            {
                try
                {
                    Console.WriteLine("Digite o codigo do cliente: ");
                    this.CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());
                    do
                    {
                        if (clientes.FindIndex(x => x.CodigoDoCliente == CodigoDoCliente) != -1)
                        {
                            Console.WriteLine("Codigo de cliente já existe!");
                            Console.WriteLine("Digite o codigo do cliente: ");
                            CodigoDoCliente = Convert.ToInt32(Console.ReadLine().ToString());
                        }
                    } while (clientes.FindIndex(x => x.CodigoDoCliente == this.CodigoDoCliente) != -1);
                    test = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na digitação!");
                    Console.WriteLine("Mensagem de erro:" + ex.Message);
                    Console.ReadKey();
                }
            }
        }

        public void TipoGeneros()
        {
            bool control = true;
            while (control)
            {
                Console.WriteLine("{0}  / {1}  / {2} ", Genero.Masculino.ToString(), Genero.Feminino.ToString(), Genero.NA.ToString());
                string respostaGenero = Console.ReadLine().ToUpper();
                switch (respostaGenero)
                {
                    case "MASCULINO":
                        Genero = Genero.Masculino;
                        control = false;
                        break;
                    case "FEMININO":
                        Genero = Genero.Feminino;
                        control = false;
                        break;
                    case "NA":
                        Genero = Genero.NA;
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
                Console.WriteLine("{0}  / {1} ", TipoCliente.Fisica.ToString(), TipoCliente.Juridica.ToString());
                string respostaTipoCliente = Console.ReadLine().ToUpper();
                switch (respostaTipoCliente)
                {
                    case "FISICA":
                        TipoCliente = TipoCliente.Fisica;
                        opcao = false;
                        break;
                    case "JURIDICA":
                        TipoCliente = TipoCliente.Juridica;
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
            int numEndereco = 0;
            Console.WriteLine("========= INFORMAÇÃO DO CLIENTE: ========");
            Console.WriteLine("Tipo de cliente:" + this.TipoCliente);
            Console.WriteLine("Codigo do cliente:" + this.CodigoDoCliente);
            Console.WriteLine("Nome do cliente:" + this.Nome);
            Console.WriteLine("Idade do cliente:" + this.Idade);
            Console.WriteLine("Estado civil do cliente:" + this.EstadoCivil);
            Console.WriteLine("Genero do cliente:" + this.Genero.ToString());

            foreach (Endereco dadosEndereco in listaEndereco)
            {
                numEndereco++;
                Console.WriteLine("\n========= INFORMAÇÃO DO ENDEREÇO:" + numEndereco + " ========");
                Console.WriteLine("Codigo do cliente:" + dadosEndereco.CodigoDoCliente);
                Console.WriteLine("" + dadosEndereco.TipoLogradouro + ": " + dadosEndereco.NomeLogradouro);
                Console.WriteLine("Complemento:" + dadosEndereco.Complemento);
                Console.WriteLine("CEP:" + dadosEndereco.CEP);
                Console.WriteLine("Bairro:" + dadosEndereco.Bairro);
                Console.WriteLine("Cidade:" + dadosEndereco.Cidade);
            }
            Console.ReadLine();
        }



    }
}
