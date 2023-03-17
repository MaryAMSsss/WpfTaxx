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
    /// Логика взаимодействия для Система.xaml
    /// </summary>
    public partial class Система : Window
    {
        public int flag = 0;
        public int flagPagin = 0;
        List<Products> productsPagin = new List<Products>();
        List<Products> productsSorted = new List<Products>();
        public Система()
        {
            InitializeComponent();
            
            List<Products> products2 = chefReq.GetAllProducts();
            productsPagin = products2;
            
            List<Ingredients> ingredients2 = chefReq.GetAllIngredients();
            ingredients.ItemsSource = ingredients2;
            List<Menuu> menus2 = chefReq.GetAllMenu();
            menu.ItemsSource = menus2;
            if (flagPagin == 0)
            {
                prev.IsEnabled = false;

                products.ItemsSource = GetProductTen(0);
            }
        }

        private List<Products> GetProductTen(int indexPagin)
        {
            List<Products> products2 = new List<Products>();
            int index = indexPagin;
            if (index < productsPagin.Count - 13)
            {
                for (int i = indexPagin; i < indexPagin + 13; i++)
                {
                    products2.Add(new Products(){Id = productsPagin[i].Id, Наименование = productsPagin[i].Наименование,
                     Стоимость = productsPagin[i].Стоимость, Мера_веса = productsPagin[i].Мера_веса });
                }
            }          
            return products2;
        }

        private List<Products> GetProductSortedTen(int indexPagin)
        {
            List<Products> products2 = new List<Products>();
            int index = indexPagin;
            if (index < productsSorted.Count - 13)
            {
                for (int i = indexPagin; i < indexPagin + 13; i++)
                {
                    products2.Add(new Products()
                    {
                        Id = productsSorted[i].Id,
                        Наименование = productsSorted[i].Наименование,
                        Стоимость = productsSorted[i].Стоимость,
                        Мера_веса = productsSorted[i].Мера_веса
                    });
                }
            }
            return products2;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int code = 2;
            Products product = new Products();
            if (Tables.SelectedIndex == 0)
            {

            }
            else if (Tables.SelectedIndex == 1)
                {
                AEProducts view = new AEProducts(product, code);
                view.Show();
                this.Close();

                }
                else if (Tables.SelectedIndex == 2)
                {

                }
            
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (products.SelectedItem == null)
            {
                MessageBox.Show("hey ");
            }
            else
            {
                Products product = new Products();
                product.Id = Convert.ToInt32(((Products)products.SelectedItem).Id);
                product.Наименование = ((Products)products.SelectedItem).Наименование;
                product.Мера_веса = ((Products)products.SelectedItem).Мера_веса;
                product.Стоимость = Convert.ToInt32(((Products)products.SelectedItem).Стоимость);
                int code = 1;
                if (Tables.SelectedIndex == 0)
                {

                }
                else if (Tables.SelectedIndex == 1)
                {
                    AEProducts view = new AEProducts(product, code);
                    view.Show();
                    this.Close();

                }
                else if (Tables.SelectedIndex == 2)
                {

                }
            }
           
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (products.SelectedItem == null)
            {
                MessageBox.Show("hey ");
            }
            else
            {
                flagPagin = 0;
                var ibd = ((Products)products.SelectedItem).Id;
                MessageBox.Show($"{ibd}");
                DeleteProduct.DelProduct(ibd);
                products.ItemsSource = null;
                products.ItemsSource = GetProductTen(flagPagin);
            }
        }
        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            AutoriseWindow view = new AutoriseWindow();
            view.Show();
            this.Close();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SortBtn.Content== "↑")
            {
                SortBtn.Content = "↓";
                products.ItemsSource = null;
                productsSorted = SortReq.SortProducts("select* from Продукты order by Стоимость_шт Desc;");
                products.ItemsSource = GetProductSortedTen(0);
               // products.ItemsSource = SortReq.SortProducts("select* from Продукты order by Стоимость_шт Desc;");
            }
            else
            {
                SortBtn.Content = "↑";
                products.ItemsSource = null;
                productsSorted = SortReq.SortProducts("select* from Продукты order by Стоимость_шт Asc;");
                products.ItemsSource = GetProductSortedTen(0);
                // products.ItemsSource = SortReq.SortProducts("select* from Продукты order by Стоимость_шт Asc;");
            }
        }
        // следующие 
        private void next_Click(object sender, RoutedEventArgs e)
        {
            flagPagin += 13;
            prev.IsEnabled = true;
            products.ItemsSource = null;
            products.ItemsSource = GetProductTen(flagPagin);    
        }
        private void prev_Click(object sender, RoutedEventArgs e)
        {
           
            if (flagPagin >=10)
            {
                flagPagin -= 10;
                products.ItemsSource = null;
                products.ItemsSource = GetProductTen(flagPagin);
            }
            else
            {
                prev.IsEnabled = false;
            }
        }
    }
}
