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
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
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
        private void Password2TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (Password2TextBox.Password == "")
            {
                Password2TextBlock.Opacity = 0.45;
            }
            else
            {
                Password2TextBlock.Opacity = 0;
            }
            
            if (PasswordTextBox.Password != Password2TextBox.Password)
            {
                CreateClick.IsEnabled = false;
                Password2TextBox.Background = Brushes.Pink;
            }
            else
            {
                CreateClick.IsEnabled = true;
                Password2TextBox.Background = Brushes.LightGreen;
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameTextBlock.Opacity = 0.45;
            }
            else
            {
                NameTextBlock.Opacity = 0;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
                if (context.Users.Count(x => x.Login == LoginTextBox.Text) != 0)
                {
                    MessageBox.Show("Такой пользователь уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            try
            {
                User UserObj = new User()
                {
                    Login = LoginTextBox.Text,
                    Password = Password2TextBox.Password,
                    UserName = NameTextBox.Text,
                    RoleId = 2
                };
                using (var context = new ApplicationContext())
                {
                    context.Users.Add(UserObj);
                    context.SaveChanges();
                }
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + " Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
