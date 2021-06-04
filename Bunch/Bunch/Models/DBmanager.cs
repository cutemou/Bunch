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

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                        email = reader.GetString(reader.GetOrdinal("email")),
                        password = reader.GetString(reader.GetOrdinal("password")),
                    };
                    users.Add(user);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return users;
        }

        public void NewUser(User user)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO Users(name,email,password)
                VALUES (@name,@email,@password)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@name", user.name));
            sqlCommand.Parameters.Add(new SqlParameter("@email", user.email));
            sqlCommand.Parameters.Add(new SqlParameter("@password", user.password));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public User GetUserById(int id)
        {
            User user = new User();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                        email = reader.GetString(reader.GetOrdinal("email")),
                        password = reader.GetString(reader.GetOrdinal("password")),
                    };
                }
            }
            else
            {
                Console.WriteLine("未找到該筆資料！");
            }
            sqlConnection.Close();
            return user;
        }

        public void UpdateUser(User user)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE Users SET name = @name, email = @email, password = @password WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@name", user.name));
            sqlCommand.Parameters.Add(new SqlParameter("@email", user.email));
            sqlCommand.Parameters.Add(new SqlParameter("@password", user.password));
            sqlCommand.Parameters.Add(new SqlParameter("@id", user.id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void DeleteUserById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"DELETE FROM Users WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}