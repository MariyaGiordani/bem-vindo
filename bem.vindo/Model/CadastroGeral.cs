
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using bem.vindo.Util;
using bem.vindo.Utils;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<Cliente> listaCliente = new List<Cliente>();

        FileUtil fileCliente = new FileUtil(EnumTipoArquivo.Cliente);
        FileUtil fileEndereco = new FileUtil(EnumTipoArquivo.Endereco);

        public void CadastroCliente()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.CadastrarCliente();

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
