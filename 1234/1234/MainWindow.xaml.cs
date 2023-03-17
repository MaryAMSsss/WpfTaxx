using _1234.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1234
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cmb.ItemsSource = reginReq.GetLevels();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            reginReq.Registration(LoginText.Text, PassText.Password,reginReq.GetIdLevel(Cmb.SelectedItem.ToString()));
        
        }
        //Уже есть аккаунт?Войти
        private void AlreadyAcc_Click(object sender, RoutedEventArgs e)
        {
            AutoriseWindow autoriseWindow = new AutoriseWindow();
            autoriseWindow.Show();
            Hide();
        }
        //Проверка на уровень доступа
        private void ShomaretextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //если при нажатии на клавишу клавиатуры вводят букву, она не отображается
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
        //Кнопка закрытия окна
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Environment.Exit(0);            
        }
    }
}
