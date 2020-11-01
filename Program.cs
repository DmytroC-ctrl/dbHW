using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbHW
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PersonsOrders;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }

            string sqlExpression = "SELECT * FROM Persons";

            var dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var sqlCommand = new SqlCommand(sqlExpression, connection))
                {
                    sqlCommand.CommandText = sqlExpression;
                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dataSet);
                }
            }
            if (sqlExpression.StartsWith("SELECT") && dataSet.Tables[0].Rows[0] != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    foreach (DataColumn column in dataSet.Tables[0].Columns)
                    {
                        Console.Write(row[column] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

        }
    }
}
