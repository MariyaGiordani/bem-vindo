
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using bem.vindo.Util;
using bem.vindo.Business;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<Cliente> listaCliente = new List<Cliente>();
        public static List<Endereco> listaEndereco = new List<Endereco>();

        public void CadastroCliente()
        {
            string path = @"c:\temp\CADASTROCLIENTE.TXT";
            FileUtil fileutil = new FileUtil(path);


            Cliente cliente = new Cliente();
            cliente = cliente.CadastrarCliente();
            listaCliente.Add(cliente);

            Endereco endereco = new Endereco();
            for (int x = 1; x < 4; x++)
            {
                endereco.CodigoDoCliente = cliente.CodigoDoCliente;
                endereco = endereco.CadastrarEndereco();
                listaEndereco.Add(endereco);
            }


            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                try
                {
                    String newStringCliente = cliente.RetornarStringCliente();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(newStringCliente);
                        //sw.Close();
                    }

                    Console.WriteLine("Arquivo salvo!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nMensagem: " + ex.Message);

                }
            }

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                try
                {
                    String newStringEndereco = endereco.RetornarStringEndereco();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(newStringEndereco);
                        //sw.Close();
                    }

                    Console.WriteLine("Arquivo salvo!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nMensagem: " + ex.Message);

                }
            }
        }

        public void ListagemClientesTxt()
        {
            if (File.Exists(@"c:\temp\CADASTROCLIENTE.TXT"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(@"c:\temp\CADASTROCLIENTE.TXT"))
                    {
                        String linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(linha);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Não tem cadsastrados clientes no arquivo!");
            }
        }

        public void ExibirClientes()
        {
            Console.WriteLine("\nLista clientes já cadastrado:");
            foreach (var clientes in listaCliente)
            {
                clientes.InfoDoCliente();
            }
        }
    }
}
