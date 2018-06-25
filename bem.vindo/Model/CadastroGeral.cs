
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using bem.vindo.Util;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<Cliente> listaCliente = new List<Cliente>();

        public void CadastroCliente()
        {
            string path = @"c:\temp\CADASTROCLIENTE.TXT";
            FileUtil fileutil = new FileUtil(path);


            Cliente cliente = new Cliente();
            cliente = cliente.CadastrarCliente();
            listaCliente.Add(cliente);


            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                try
                {
                    String newString = cliente.RetornarString();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(newString);
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
