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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            itog.Text = "";
            var loginn = Loginn.Text;
            var email = Loginn.Text;
            var passsword = Passsword.Password.ToString();
            var context = new AppDbContext();
            var user1 = context.Users.SingleOrDefault(x => x.Login == loginn || x.Email == email);
            if(user1 is null)
            {
                Loginn.Foreground = Brushes.Red;
                if (itog.Text != "")
                    itog.Text += "\nНеправильный логин";
                else
                    itog.Text += "Неправильный логин";
                return;
            }
            else
            {
                Loginn.Foreground = Brushes.Black;
            }
            var user2 = context.Users.SingleOrDefault(x => x.Password == passsword);
            if (user2 is null)
            {
                Passsword.Foreground = Brushes.Red;
                if(itog.Text != "")
                itog.Text += "\nНеправильный пароль";
                else
                    itog.Text += "Неправильный пароль";
                return;
            }
            else
            {
                Loginn.Foreground = Brushes.Black;
            }

            var loginn1 = Loginn.Text;
            var passsword1 = passv.Text;
            var context1 = new AppDbContext();
            var user3 = context.Users.SingleOrDefault(x => x.Login == loginn || x.Email == email);
            if (user3 is null)
            {
                Loginn.Foreground = Brushes.Red;
                if (itog.Text != "")
                    itog.Text += "\nНеправильный логин";
                else
                    itog.Text += "Неправильный логин";
                return;
            }
            else
            {
                Loginn.Foreground = Brushes.Black;
                passv.Foreground = Brushes.Black;
            }
            var user4 = context.Users.SingleOrDefault(x => x.Password == passsword);
            if (user4 is null)
            {
                Passsword.Foreground = Brushes.Red;
                passv.Foreground = Brushes.Red;
                if (itog.Text != "")
                    itog.Text += "\nНеправильный пароль";
                else
                    itog.Text += "Неправильный пароль";
                return;
            }
            else
            {
                Loginn.Foreground = Brushes.Black;
                passv.Foreground = Brushes.Black;
            }
            this.Hide();
            QQ q = new QQ();
            q.Show();
            MessageBox.Show("Здравствуйте, " + Loginn.Text + "!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg reg = new Reg();
            reg.Show();
        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            var cbb = sender as CheckBox;
            if (cbb.IsChecked.Value)        
            {
                passv.Text = Passsword.Password.ToString();
                passv.Visibility = Visibility.Visible;
            }
            else
            {
                Passsword.Password = passv.Text;
                passv.Visibility = Visibility.Hidden;
            }
        }
    }
}
