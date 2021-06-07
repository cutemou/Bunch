using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Bunch.Models
{
    public class DBmanager
    {
        private readonly string ConnStr = "Data Source=DESKTOP-4KFR4H7\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;User Instance=False";

        public List<Test> GetUsers()
        {
            List<Test> tests = new List<Test>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Test");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Test test = new Test
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        state = reader.GetString(reader.GetOrdinal("state")),
                        temperature = reader.GetDecimal(reader.GetOrdinal("temperature")),
                        time = reader.GetString(reader.GetOrdinal("time")),
                    };
                    tests.Add(test);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return tests;
        }

        public void NewUser(Test test)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO Test(state,temperature,time)
                VALUES (@state,@temperature,@time)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@state", test.state));
            sqlCommand.Parameters.Add(new SqlParameter("@temperature", test.temperature));
            sqlCommand.Parameters.Add(new SqlParameter("@time", test.time));
            sqlConnection.Open();   
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Test GetUserById(int id)
        {
            Test test = new Test();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Test WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    test = new Test
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        state = reader.GetString(reader.GetOrdinal("state")),
                        temperature = reader.GetDecimal(reader.GetOrdinal("temperature")),
                        time = reader.GetString(reader.GetOrdinal("time")),
                    };
                }
            }
            else
            {
                Console.WriteLine("未找到該筆資料！");
            }
            sqlConnection.Close();
            return test;
        }

        public void UpdateUser(Test test)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE Test SET state = @state, temperature = @temperature, time = @time WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@state", test.state));
            sqlCommand.Parameters.Add(new SqlParameter("@temperature", test.temperature));
            sqlCommand.Parameters.Add(new SqlParameter("@time", test.time));
            sqlCommand.Parameters.Add(new SqlParameter("@id", test.id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void DeleteUserById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"DELETE FROM Test WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
     }
}