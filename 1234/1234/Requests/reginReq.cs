using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace _1234.Requests
{
    class reginReq
    {
        public static void Registration(string login, string pass, int level)
        {
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Аккаунт(Логин, Пароль, Уровень_доступа) values('{login}','{pass}',{level})", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Пользователь добавлен");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        public static List<string> GetLevels()
        {
            List<string> levels = new List<string>();
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select Название from Уровень_доступа;", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        levels.Add((sqlDataReader.GetValue(0)).ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch
            {
                MessageBox.Show("ErrorOrganizator");
            }
            return levels;
        }
        public static int GetIdLevel(string level)
        {
            int id = 1;
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select Id_уровня from Уровень_доступа where Название='{level}';", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        id=Convert.ToInt32(sqlDataReader.GetValue(0));
                    }
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch
            {
                MessageBox.Show("ErrorOrganizator");
            }
            return id;
        }
    }
}
