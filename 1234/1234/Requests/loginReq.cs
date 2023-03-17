using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace _1234.Requests
{
    public class loginReq
    {
        public static int login(string login, string pass, Window window)
        {
            int level = 0;
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select Id, Уровень_доступа from Аккаунт where Логин='{login}' and Пароль='{pass}';", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                        string a = (sqlDataReader.GetValue(0)).ToString();
                        level = Convert.ToInt32(sqlDataReader.GetValue(1));                                    
                    }
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return level;
        }
    }
}
