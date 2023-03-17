using _1234.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace _1234.Requests
{
    public class chefReq
    {
        public static List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();
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



        public static List<Ingredients> GetAllIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from Ингредиенты_в_блюде;", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ingredients.Add(new Ingredients()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            Id_блюда = Convert.ToInt32(sqlDataReader.GetValue(1)),
                            Id_ингр = Convert.ToInt32(sqlDataReader.GetValue(2)),
                            Граммовка_объём = sqlDataReader.GetValue(3).ToString()
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
                MessageBox.Show("ErrorIngredients");
            }
            return ingredients;
        }

        public static List<Menuu> GetAllMenu()
        {
            List<Menuu> menus = new List<Menuu>();
            try
            {
                string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = пробная; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select* from Меню", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        menus.Add(new Menuu()
                        {
                            Id_блюда = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            Наименование = sqlDataReader.GetValue(1).ToString(),
                            Стоимость = Convert.ToInt32(sqlDataReader.GetValue(2)),
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
                MessageBox.Show("ErrorMenu");
            }
            return menus;
        }
    }
}
