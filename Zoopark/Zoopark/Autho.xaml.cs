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
using System.Windows.Shapes;

namespace Zoopark
{
    public partial class Autho : Window
    {
        public Autho()
        {
            InitializeComponent();
        }
        ZooparkDEntities db = new ZooparkDEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (db.User.Where(r => r.Login == TextLogin.Text && r.Password == TextPass.Text && r.Role == "Admin").Count() > 0)
            {
                Role.role = "Admin";
                General gen = new General();
                gen.Show();
                this.Close();
            }
            else if (db.User.Where(r => r.Login == TextLogin.Text && r.Password == TextPass.Text && r.Role == "User").Count() > 0)
            {
                Role.role = "User";
                General gen = new General();
                gen.Show();
                this.Close();
            }
            else
            {
                TextLogin.Text = "";
                TextPass.Text = "";
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
            }
        }
    }
}
