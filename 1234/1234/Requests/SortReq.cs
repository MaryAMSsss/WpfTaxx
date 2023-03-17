using _1234.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace _1234.Requests
{
    public class SortReq
    {
        public static List<Products> SortProducts(string select)
        {
            List<Products> products = new List<Products>();
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        products.Add(new Products()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            Наименование = sqlDataReader.GetValue(1).ToString(),
                            Стоимость = Convert.ToInt32(sqlDataReader.GetValue(2)),
                            Мера_веса = sqlDataReader.GetValue(3).ToString()
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
                MessageBox.Show("Errorproducts");
            }
            return products;
        }
    }
}
