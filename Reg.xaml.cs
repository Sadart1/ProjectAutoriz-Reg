using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        private static readonly char[] SpecialChar = "!@#$%^&*()".ToCharArray();
        private static readonly char[] SpecialCharem = "@.".ToCharArray();
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            var loginn = Loginn.Text;
            var passsword = Passsword.Password;
            var email = Email.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == loginn);
            if(user_exists is not null)
            {
                tb.Text = "Такой ДедИнсайд уже есть";
                Loginn.Foreground = Brushes.Red;
                return;
            }

            var indexx = Email.Text.IndexOfAny(SpecialCharem);
            if(indexx == -1)
            {
                tb.Text = "Неправильный формат почты";
                Email.Foreground = Brushes.Red;
                return;
            }
            if(Passsword.Password.Length < 8)
            {
                tb.Text = "Введит пароль из 8 или более символов";
                Passsword.Foreground = Brushes.Red;
                Passsword1.Foreground = Brushes.Red;
                return;
            }
            if(Passsword1.Text.Length < 8)
            {
                tb.Text = "Введит пароль из 8 или более символов";
                Passsword.Foreground = Brushes.Red;
                Passsword1.Foreground = Brushes.Red;
                return;
            }
            var indexOf = Passsword.Password.IndexOfAny(SpecialChar);
            if(indexOf == -1)
            {
                tb.Text = "Введите спецсимвол";
                Passsword.Foreground = Brushes.Red;
                Passsword1.Foreground = Brushes.Red;
                return;
            }

            if (Passsword.Password == Passsword2.Password)
            {
                var user = new User { Login = loginn, Password = passsword, Email = email};
                context.Users.Add(user);
                context.SaveChanges();
                tb.Text = "Ты теперь ДедИнсайд";
            }
            else
            {
                tb.Text = "Пароли не совпадают";
                Passsword.Foreground = Brushes.Red;
                Passsword1.Foreground = Brushes.Red;
                Passsword2.Foreground = Brushes.Red;
                Passsword21.Foreground = Brushes.Red;
                return; 
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cbb = sender as CheckBox;
            if (cbb.IsChecked.Value)
            {
                Passsword1.Text = Passsword.Password.ToString();
                Passsword1.Visibility = Visibility.Visible;
                Passsword21.Text = Passsword2.Password.ToString();
                Passsword21.Visibility = Visibility.Visible;
            }
            else
            {
                Passsword.Password = Passsword1.Text;
                Passsword1.Visibility = Visibility.Hidden;
                Passsword2.Password = Passsword21.Text;
                Passsword21.Visibility = Visibility.Hidden;
            }
        }
    }
}
