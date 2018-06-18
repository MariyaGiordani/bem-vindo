using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bem.vindo
{
    class CadastroGeral
    {
        public List<Cliente> listaCliente = new List<Cliente>();

        public void CadastroCliente()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.CadartrarCliente();
            listaCliente.Add(cliente);
            
        }

        public void ExibirClientes()
        {
            Console.WriteLine("\nLista clientes já cadastrado:");
            foreach (var clientes in listaCliente)
            {
                clientes.InfoDoCliente();
            }
        }

        public void sairPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Você está saindo da programa. Muito obrigada :-)");
            Environment.Exit(0);
        }
    }
}
