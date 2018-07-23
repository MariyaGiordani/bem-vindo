using bem.vindo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAO
{
    public class ClienteRepository
    {
        private ProjectConnection _projectConnection;
        public ClienteRepository(ProjectConnection projectConnection)
        {
            _projectConnection = projectConnection;
        }

        public void Create(string name)
        {
            _projectConnection.connect.Open();
            Console.WriteLine("Digite o novo nome com que você gostaria de substituir:");
            string newNome = Console.ReadLine();
            string query = "Update Cliente set Nome = '" + newNome + "' where Nome = '" + name + "'";
            SqlCommand comando = new SqlCommand(query, _projectConnection.connect);

            comando.ExecuteNonQuery();

            _projectConnection.connect.Close();
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clients = new List<Cliente>();
            _projectConnection.connect.Open();
            var reader = _projectConnection.GetInfoSql("select * from Cliente");
            IDataRecord row = reader;
            while (reader.Read())
            {
                var obj = getClientFromDataReader(row);
                clients.Add(obj);
            }
            reader.Close();
            _projectConnection.connect.Close();
            clients.ForEach(
                (cliente) =>
                {
                    EnderecoRepository address = new EnderecoRepository(_projectConnection);
                    cliente.listaEndereco = address.GetAll(cliente.CodigoDoCliente);
                });
            return clients;
        }

        private Cliente getClientFromDataReader(IDataRecord row)
        {
            Cliente clienteNovo = new Cliente();
            var codigoCliente = row[1].ToString();
            clienteNovo.CodigoDoCliente = Guid.Parse(codigoCliente);
            var tipoCliente = row[2];
            clienteNovo.TipoCliente = (EnumTipoCliente)tipoCliente;
            var nome = row[3].ToString();
            clienteNovo.Nome = nome;
            var idade = row[4];
            clienteNovo.Idade = Convert.ToInt32(idade);
            var estadoCivil = row[5];
            clienteNovo.EstadoCivil = (EnumEstadoCivil)estadoCivil;
            var genero = row[6];
            clienteNovo.Genero = (EnumGenero)genero;
            return clienteNovo;
        }

        public Cliente GetByCode(string clientCode)
        {
            Guid code = Guid.Parse(clientCode);
            Cliente client = new Cliente();

            string query = "select * from Cliente where CodigoCliente = @CodigoCliente";
            SqlCommand command = new SqlCommand(query, _projectConnection.connect);
            command.Parameters.AddWithValue("@CodigoCliente", clientCode);

            _projectConnection.connect.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var codigoCliente = reader["CodigoCliente"].ToString();
                client.CodigoDoCliente = Guid.Parse(codigoCliente);
                int tipoCliente = Convert.ToInt32(reader["TipoCliente"]);
                client.TipoCliente = (EnumTipoCliente)tipoCliente;
                client.Nome = reader["Nome"].ToString();
                int idade = Convert.ToInt32(reader["Idade"]);
                client.Idade = idade;
                int estadoCivil = Convert.ToInt32(reader["EstadoCivil"]);
                client.EstadoCivil = (EnumEstadoCivil)estadoCivil;
                int genero = Convert.ToInt32(reader["Genero"]);
                client.Genero = (EnumGenero)genero;
            }
            _projectConnection.connect.Close();
            return client;
        }



        public void Update(Cliente client)
        {
            try
            {
                _projectConnection.connect.Open();                
                string query = "INSERT INTO Cliente (CodigoCliente, TipoCliente, Nome, Idade, EstadoCivil, Genero) " +
                                "VALUES (@CodigoCliente, @TipoCliente, @Nome, @Idade, @EstadoCivil, @Genero)";

                SqlCommand comando = new SqlCommand(query,_projectConnection.connect);
                comando.Parameters.Add(new SqlParameter("@CodigoCliente", client.CodigoDoCliente));
                comando.Parameters.Add(new SqlParameter("@TipoCliente", client.TipoCliente));
                comando.Parameters.Add(new SqlParameter("@Nome", client.Nome));
                comando.Parameters.Add(new SqlParameter("@Idade", client.Idade));
                comando.Parameters.Add(new SqlParameter("@EstadoCivil", client.EstadoCivil));
                comando.Parameters.Add(new SqlParameter("@Genero", client.Genero));
                

                comando.ExecuteNonQuery();

                _projectConnection.connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMensagem: " + ex.Message);
            }
        }

        public void Delete(Cliente client)
        {
            try
            {
                _projectConnection.connect.Open();
                
                string query = "Delete from Cliente where CodigoCliente = @CodigoCliente";

                SqlCommand command = new SqlCommand(query,_projectConnection.connect);
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@CodigoCliente", client.CodigoDoCliente);
                
                command.ExecuteNonQuery();
                _projectConnection.connect.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("\nMensagem: " + ex.Message);
            }
        }

    }
}
