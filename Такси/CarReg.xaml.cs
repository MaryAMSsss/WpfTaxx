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
using Такси.Requests;
using Такси.Models;

namespace Такси
{
    /// <summary>
    /// Логика взаимодействия для CarReg.xaml
    /// </summary>
    public partial class CarReg : Window
    {
        public Car car = new Car();
        public CarReg(Car car)
        {
            InitializeComponent();
            CarNum.Text = car.Number;
            CarBr.Text = car.Brand;
            CarMod.Text = car.Model;
            car.Id = car.Id;
        }

        private void CarRegButton_Click(object sender, RoutedEventArgs e)
        {
            car.Number = CarNum.Text;
            car.Brand = CarBr.Text;
            car.Model = CarMod.Text;
            AddCarReq.AddCar(car);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
