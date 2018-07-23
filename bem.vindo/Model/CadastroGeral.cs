
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using bem.vindo_Util;
using bem.vindo.Models;
using GeneralDAO;
using bem.vindo_Busines;

namespace bem.vindo.Model
{
    public class CadastroGeral
    {
        public static List<ClientBusiness> listaCliente = new List<ClientBusiness>();

        public void CadastroCliente()
        {
            ClientBusiness cliente = new ClientBusiness();
            cliente = cliente.CadastrarCliente();

            listaCliente.Add(cliente);
        }

        public void DeleteCliente(string code)
        {
            ClientBusiness cliente = new ClientBusiness();
            cliente.DeleteByCode(code);
        }

        public void ListagemClienteID(string code)
        {
            ClientBusiness cliente = new ClientBusiness();
            cliente.GetbyCode(code);
        }

        public void ListagemEnderecoID(string id)
        {
            EnderecoBusiness endereco = new EnderecoBusiness();
            endereco.GetbyId(id);
        }


        public void CarregarDadosTxt()
        {
            ClientBusiness cliente = new ClientBusiness();
            listaCliente = cliente.LoadFromFile();
            cliente.SaveClienteEndereco(listaCliente);
        }

        public void SQLTest()
        {            
            ClientBusiness cb = new ClientBusiness();
            cb.ListClientFromDB();
        }

        public void ChangeClientName(string nameCliente)
        {
            ClientBusiness cliente = new ClientBusiness();
            cliente.ChangeName(nameCliente);
        }
    }
}
