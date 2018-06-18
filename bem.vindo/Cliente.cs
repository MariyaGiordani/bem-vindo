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
        public Guid CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Genero Genero { get; set; }

        public List<Endereco> listaEndereco = new List<Endereco>();




        public Cliente CadartrarCliente()
        {
            Console.WriteLine("\n======= Bem Vindo! ========");

            Cliente cliente = new Cliente();

            Console.WriteLine("Escolha tipo de cliente: ");
            cliente.TipoDeCliente();

            Console.WriteLine("Codigo do cliente: ");
            Console.WriteLine(cliente.CodigoDoCliente = System.Guid.NewGuid());
            Console.WriteLine("Digite o nome do cliente: ");
            cliente.NomeCliente();
            cliente.IdadeCliente();
            Console.WriteLine("Digite estado civil do cliente: ");
            cliente.EstadoCivilCliente();
            Console.WriteLine("Digite o genero do cliente: ");
            cliente.TipoGeneros();
            Console.Clear();

            for (int x = 1; x < 4; x++)
            {
                Endereco endereco = new Endereco();
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                endereco.CadastrarEndereco();
                cliente.listaEndereco.Add(endereco);
            }
            cliente.InfoDoCliente();
            Console.Clear();
            return cliente;
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
                Console.WriteLine("{0}  / {1}  / {2} / {3} ", EstadoCivil.Solteiro.ToString(), vindo.EstadoCivil.Casado.ToString(), vindo.EstadoCivil.Viuvo.ToString(), vindo.EstadoCivil.Divorciado.ToString());
                string respostaEstadoCivil = Console.ReadLine().ToUpper();
                switch (respostaEstadoCivil)
                {
                    case "SOLTEIRO":
                        EstadoCivil = EstadoCivil.Solteiro;
                        control = false;
                        break;
                    case "CASADO":
                        EstadoCivil = EstadoCivil.Casado;
                        control = false;
                        break;
                    case "VIUVO":
                        EstadoCivil = EstadoCivil.Viuvo;
                        control = false;
                        break;
                    case "DIVORCIADO":
                        EstadoCivil = EstadoCivil.Divorciado;
                        control = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida!");
                        Console.WriteLine("Estado civil é obrigatório!");
                        break;
                }
            }
        }
       public void CodigoCliente(List<Cliente> cliente)
        {
            bool test = true;
            while (test)
            {
                    do
                    {
                        if (cliente.FindIndex(x => x.CodigoDoCliente == CodigoDoCliente) != -1)
                        {
                            Console.WriteLine("Codigo de cliente já existe!");
                            Console.WriteLine("Codigo do cliente: ");
                            Console.WriteLine(this.CodigoDoCliente = System.Guid.NewGuid());
                        }
                    } while (cliente.FindIndex(x => x.CodigoDoCliente == this.CodigoDoCliente) != -1);
                    test = false;
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
                Console.WriteLine("" + dadosEndereco.TipoLogradouro + " : " + dadosEndereco.NomeLogradouro);
                Console.WriteLine("Complemento:" + dadosEndereco.Complemento);
                Console.WriteLine("CEP:" + dadosEndereco.CEP);
                Console.WriteLine("Bairro:" + dadosEndereco.Bairro);
                Console.WriteLine("Cidade:" + dadosEndereco.Cidade);
            }
            Console.ReadLine();
        }
    }
}
