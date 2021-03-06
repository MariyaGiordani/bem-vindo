﻿
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

        public void ExibirClientes()
        {
            Console.WriteLine("\nLista clientes já cadastrado:");
            foreach (var clientes in listaCliente)
            {
                clientes.InfoDoCliente();
            }
        }

        public void CarregarDadosTxt()
        {
            Cliente cliente = new Cliente();
            listaCliente = cliente.LoadFromFile(true, true);
            ExibirClientes();
        }
    }
}
