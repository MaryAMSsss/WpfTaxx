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
using Такси.Models;
using Такси.Requests;

namespace Такси
{
    /// <summary>
    /// Логика взаимодействия для MainClientWin.xaml
    /// </summary>
    public partial class MainClientWin : Window
    {
        public int flagPagin = 0;
        List<Order> ordersPagin = new List<Order>();
        public MainClientWin()
        {
            InitializeComponent();
            List<Order> orders2 = ClientOrders.GetAllOrders();
            ordersPagin = orders2;

            if (flagPagin == 0)
            {
                prev.IsEnabled = false;

                products.ItemsSource = GetOrdersTen(0);
            }
        }
        private List<Order> GetOrdersTen(int indexPagin)
        {
            List<Order> orders2 = new List<Order>();
            int index = indexPagin;
            if (index < ordersPagin.Count - 13)
            {
                for (int i = indexPagin; i < indexPagin + 13; i++)
                {
                    orders2.Add(new Order()
                    {
                        Id = ordersPagin[i].Id,
                        Наименование = ordersPagin[i].Наименование,
                        Стоимость = ordersPagin[i].Стоимость,
                        Мера_веса = ordersPagin[i].Мера_веса
                    });
                }
            }
            return products2;
        }
    }
}
