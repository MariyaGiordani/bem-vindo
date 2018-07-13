
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
using bem.vindo.Business;
using GeneralDAO;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<Cliente> listaCliente = new List<Cliente>();

        public void CadastroCliente()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.CadastrarCliente();

            listaCliente.Add(cliente);
        }
        public void ListagemClienteID(string code)
        {
            Cliente cliente = new Cliente();
            cliente.GetbyCode(code);
        }

        public void ListagemEnderecoID(string id)
        {
            Endereco endereco = new Endereco();
            endereco.GetbyId(id);
        }


        public void CarregarDadosTxt()
        {
            Cliente cliente = new Cliente();
            listaCliente = cliente.LoadFromFile();
            cliente.SaveClienteEndereco(listaCliente);
        }

        public void SQLTest()
        {
            ProjectConnection pc = new ProjectConnection();
            pc.GetInfoSql("select * from Cliente");
            pc.GetInfoSql("select * from Endereco");
        }
    }
}
