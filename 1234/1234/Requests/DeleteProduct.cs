using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using _1234.Models;

namespace _1234.Requests
{
    public class DeleteProduct
    {
        public static void DelProduct(int Id)
        {
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Продукты WHERE Id_продукта={Id}", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Продукт удалён");
            }
            catch
            {
                MessageBox.Show("Этот продукт не может быть удален так как находится в составе блюда!");
            }
        }
    }
}

