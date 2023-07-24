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

namespace Registration.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTextBox.Text == "")
            {
                LoginTextBlock.Opacity = 0.45;
            }
            else
            {
                LoginTextBlock.Opacity = 0;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == "")
            {
                PasswordTextBlock.Opacity = 0.45;
            }
            else
            {
                PasswordTextBlock.Opacity = 0;
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string current_Login = LoginTextBox.Text;
            string current_Pass = PasswordTextBox.Password;
            try
            {
                User user = ApplicationContext.Sravn(current_Login, current_Pass);
                
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + user.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Ученик " + user.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + " Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
    }
}
