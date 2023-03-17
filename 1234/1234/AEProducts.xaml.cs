using _1234.Models;
using _1234.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1234
{
    /// <summary>
    /// Логика взаимодействия для AEProducts.xaml
    /// </summary>
    public partial class AEProducts : Window
    {
        public Products product = new Products();
        public AEProducts(Products products,int code)
        {
            InitializeComponent();
            naim.Text = products.Наименование;
            price.Text = products.Стоимость.ToString();
            ves.Text = products.Мера_веса;
            product.Id = products.Id;
            if (code==1)
            {
                AddButton.Visibility = Visibility.Hidden;
            }
            else
            {
                EditButton.Visibility = Visibility.Hidden;

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;

            if (double.TryParse(price.Text, out num))
            {
                product.Мера_веса = ves.Text;
                product.Наименование = naim.Text;
                product.Стоимость = Convert.ToInt32(price.Text);
                AddChangeProductReq.AddProduct(product);
            }
            else
            {
                MessageBox.Show($" {price.Text} - это не число! Введите числоо !!!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
           
            if (double.TryParse(price.Text, out num))
            {
                product.Мера_веса = ves.Text;
                product.Наименование = naim.Text;
                product.Стоимость = Convert.ToInt32(price.Text);
                AddChangeProductReq.ChangeProduct(product);
            }
            else
            {
                MessageBox.Show($" {price.Text} - это не число! Введите числоо !!!");
            }
                
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Система view = new Система();
            view.Show();
            this.Close();
        }
    }
}
