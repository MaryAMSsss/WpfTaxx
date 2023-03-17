using System;
using System.Collections.Generic;
using System.Text;
using Такси.Models;
using System.Windows;
using System.Data.SqlClient;

namespace Такси.Requests
{
    public class AddCarReq
    {
        public static void AddCar(Car car)
        {
            try
            {
                MessageBox.Show($"{car}");
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Автомобиль values ('{car.Number}','{car.Brand}','{car.Model}');", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Автомобиль зарегистрирован");
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e}");
            }
        }
    }
}
