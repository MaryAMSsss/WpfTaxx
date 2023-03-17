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
    /// Логика взаимодействия для AutoriseWindow.xaml
    /// </summary>
    public partial class AutoriseWindow : Window
    {
        public AutoriseWindow()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int level = loginReq.login(LoginText.Text, PassText.Password, this);
            if (level != 0)
            {
                Captcha viewCaptha = new Captcha(LoginText.Text, PassText.Password, this);
                viewCaptha.Show();
                this.Close();
            }
        }
    }
}
