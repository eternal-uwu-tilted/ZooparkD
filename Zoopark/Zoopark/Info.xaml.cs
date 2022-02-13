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
    public partial class Info : Window
    {
        ZooparkDEntities db = new ZooparkDEntities();
        ZooparkT zoo = new ZooparkT();
        public Info()
        {
            InitializeComponent();
            foreach (var text in db.ZooparkT)
            {
                txtInfo.Text += text.Text;
                if (Role.role == "User")
                {
                    EditB.Visibility = Visibility.Hidden;
                    txtInfo.IsReadOnly = true;
                }
                return;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            General gen = new General();
            gen.Show();
            this.Close();
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            foreach (var info in db.ZooparkT)
            {
                    zoo = info;
                    break;
            }
            zoo.Text = txtInfo.Text;
            MessageBox.Show("Изменения применины!", "Успех");
            db.SaveChanges();
        }
    }
}
