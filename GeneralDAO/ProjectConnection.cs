using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GeneralDAO
{
    public class ProjectConnection
    {

       public SqlConnection connect = null;

        public ProjectConnection()
        {
            Connection();
        }

        private void Connection()
        {
            try
            {
                connect = new SqlConnection("Data Source=ec2-34-239-246-6.compute-1.amazonaws.com;Initial Catalog=TesteMaria;Persist Security Info=True;User ID=mariya.lukanova;Password=isobartender");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex);
            }
        }

        public SqlDataReader GetInfoSql(string query)
        {            
            SqlCommand cmd = new SqlCommand(query, connect);
            return Connection(cmd);
        }



        private SqlDataReader Connection(SqlCommand cmd)
        {
            SqlDataReader reader = null;
            try
            {               
               reader =   cmd.ExecuteReader();
                //IDataRecord row = reader;
                //while (reader.Read())
                //{
                //    if (row.FieldCount == 7)
                //    {
                //        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]));
                //    }
                //    else
                //    {
                //        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} ", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]));
                //    }
                //}
                //reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensagem: " + ex);
            }
            return reader;
        }
    }
}
