using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Такси.Models;

namespace Такси.Requests
{
    public class ClientOrders
    {
        public static List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from Продукты;", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new Order()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            DriverId = Convert.ToInt32(sqlDataReader.GetValue(1)),
                            Status = Convert.ToInt32(sqlDataReader.GetValue(2)),
                            ClientId = Convert.ToInt32(sqlDataReader.GetValue(3))
                        });
                        //string a = (sqlDataReader.GetValue(0)).ToString();
                        //MessageBox.Show($"Вы вошли с Id={a}");
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
                MessageBox.Show("Error Orders");
            }
            return orders;
        }
    }
}
