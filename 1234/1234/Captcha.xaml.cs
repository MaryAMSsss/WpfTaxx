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
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        private string _login;
        private string _pass;
        private Window _window;

        public Captcha(string login,string pass,Window window)
        {
            InitializeComponent();
            _login = login;
            _pass = pass;
            _window = window;
        }
       
        private void CatButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы не прошли проверку, попробуйте еще раз!", "Ошибка");
           
        }
        private void DogButton_Click(object sender, RoutedEventArgs e)
        {
            
            int level = loginReq.login(_login,_pass, this);
            if (level == 2)
            {
                ManagerWindow view = new ManagerWindow();
                view.Show();
                this.Close();
            }
            else if (level == 3)
            {
                Система view = new Система();
                view.Show();
                this.Close();
            }
            else if (level == 4)
            {
                WaiterWindow view = new WaiterWindow();
                view.Show();
                this.Close();
            }
            MessageBox.Show("Проверка пройдена!", "Уведомление");

        }
        private void WolfButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы не прошли проверку, попробуйте еще раз!", "Ошибка");
           
        }
    }
}
