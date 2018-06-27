
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using bem.vindo.Business;
using bem.vindo.Utils;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<Cliente> listaCliente = new List<Cliente>();
        public static List<Endereco> listaEndereco = new List<Endereco>();

        FileUtil fileCliente = new FileUtil(EnumTipoArquivo.Cliente);
        FileUtil fileEndereco = new FileUtil(EnumTipoArquivo.Endereco);

        public void CadastroCliente()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.CadastrarCliente();

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
            listaCliente.Add(cliente);

            String newString = cliente.RetornarString();

            fileCliente.Update(newString);

        }
        public void ListagemClientesTxt()
        {
            fileCliente.Listagem();
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
