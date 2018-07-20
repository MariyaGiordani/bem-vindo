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
    public class EnderecoRepository
    {
        private ProjectConnection _projectConnection;
        public EnderecoRepository(ProjectConnection projectConnection)
        {
            _projectConnection = projectConnection;
        }

        public void Create()
        {

        }

        public List<Endereco> GetAll(Guid clientCode)
        {
            List<Endereco> address = new List<Endereco>();

            if (_projectConnection.connect.State == ConnectionState.Closed)
            {
                _projectConnection.connect.Open();
            }
            string codCliente = clientCode.ToString();
            string query = "select * from Endereco where CodigoCliente ='" + codCliente+"'";
            var reader = _projectConnection.GetInfoSql(query);
            IDataRecord row = reader;
            while (reader.Read())
            {
                var obj = getAddressFromDataReader(row);
                address.Add(obj);
            }           
            reader.Close();
            _projectConnection.connect.Close();
            return address;
        }
        private Endereco getAddressFromDataReader(IDataRecord row)
        {
            Endereco addressNew = new Endereco();
            var codigoCliente = row[1].ToString();
            addressNew.CodigoDoCliente = Guid.Parse(codigoCliente);
            var idAddress = row[2].ToString();
            addressNew.IdAddress = Guid.Parse(idAddress);
            var tipoLogradouro = row[3];
            addressNew.TipoLogradouro = (EnumTipoLogradouro) tipoLogradouro;
            var nomeLogradouro = row[4].ToString();
            addressNew.NomeLogradouro = nomeLogradouro;
            var complemento = row[5].ToString();
            addressNew.Complemento = complemento;
            var cep = row[6].ToString();
            addressNew.CEP = cep;
            var bairro = row[7].ToString();
            addressNew.Bairro = bairro;
            var cidade = row[8].ToString();
            addressNew.Cidade = cidade;
            return addressNew;
        }

        public Endereco GetById(string id)
        {
            Guid code = Guid.Parse(id);
            Endereco address = new Endereco();

            string query = "select * from Endereco where IDEndereco = @IDEndereco";
            SqlCommand command = new SqlCommand(query, _projectConnection.connect);
            command.Parameters.AddWithValue("@IDEndereco", id);

            _projectConnection.connect.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var codigoCliente = reader["CodigoCliente"].ToString();
                address.CodigoDoCliente = Guid.Parse(codigoCliente);
                var idAddress = reader["IDEndereco"].ToString();
                address.IdAddress = Guid.Parse(idAddress);
                int tipoLogradouro = Convert.ToInt32(reader["TipoLogradouro"]);
                address.TipoLogradouro = (EnumTipoLogradouro)tipoLogradouro;
                address.NomeLogradouro = reader["NomeLogradouro"].ToString();
                address.Complemento = reader["Complemento"].ToString();
                address.CEP = reader["CEP"].ToString();
                address.Bairro = reader["Bairro"].ToString();
                address.Cidade = reader["Cidade"].ToString();
            }
            _projectConnection.connect.Close();
            return address;
        }

        public void Update(Endereco address)
        {
            try
            {
                _projectConnection.connect.Open();
                string query = "INSERT INTO Endereco (CodigoCliente, IDEndereco, TipoLogradouro, NomeLogradouro, Complemento, CEP, Bairro, Cidade) " +
                                "VALUES (@CodigoCliente, @IDEndereco, @TipoLogradouro, @NomeLogradouro, @Complemento, @CEP, @Bairro, @Cidade)";

                SqlCommand comando = new SqlCommand(query, _projectConnection.connect);
                comando.Parameters.Add(new SqlParameter("@CodigoCliente", address.CodigoDoCliente));
                comando.Parameters.Add(new SqlParameter("@IDEndereco", address.IdAddress));
                comando.Parameters.Add(new SqlParameter("@TipoLogradouro", address.TipoLogradouro));
                comando.Parameters.Add(new SqlParameter("@NomeLogradouro", address.NomeLogradouro));
                comando.Parameters.Add(new SqlParameter("@Complemento", address.Complemento));
                comando.Parameters.Add(new SqlParameter("@CEP", address.CEP));
                comando.Parameters.Add(new SqlParameter("@Bairro", address.Bairro));
                comando.Parameters.Add(new SqlParameter("@Cidade", address.Cidade));


                comando.ExecuteNonQuery();

                _projectConnection.connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMensagem: " + ex.Message);
            }
        }

        public void Delete()
        {

        }
    }
}
