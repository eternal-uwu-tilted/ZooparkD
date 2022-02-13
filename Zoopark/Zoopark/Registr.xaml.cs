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
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        User client = new User();
        ZooparkDEntities db = new ZooparkDEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtLog.Text != "" && nameTxt.Text != "" && passTxt.Text != "")
            {
                foreach (var user in db.User)
                {
                    if (user.Login == txtLog.Text)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка");
                        return;
                    }
                }
                client.Login = txtLog.Text.Trim();
                client.Name = nameTxt.Text.Trim();
                client.Password = passTxt.Text.Trim();
                client.Role = "User";
                db.User.Add(client);
                db.SaveChanges();
                Role.role = "User";
                General gen = new General();
                gen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все данные введены!");
            }
        }
    }
}
