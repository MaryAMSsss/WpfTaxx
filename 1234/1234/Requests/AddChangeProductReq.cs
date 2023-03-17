using _1234.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace _1234.Requests
{
    public class AddChangeProductReq
    {
        public static void ChangeProduct(Products products)
        {
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"update Продукты set Наименование='{products.Наименование}', Стоимость_шт={products.Стоимость}, Мера_веса='{products.Мера_веса}' where Id_продукта={products.Id}", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Продукт изменен");
            }
            catch
            {
                MessageBox.Show("Ошибка изменения продукта");
            }
        }

        public static void AddProduct(Products products)
        {
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Продукты values ('{products.Наименование}',{products.Стоимость},'{products.Мера_веса}');", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Продукт добавлен");
            }
            catch
            {
                MessageBox.Show("Ошибка добавления продукта");
            }
        }
    }
}
