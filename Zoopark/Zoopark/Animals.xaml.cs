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
    public partial class Animals : Window
    {
        ZooparkDEntities db = new ZooparkDEntities();
        AnimalsT ani = new AnimalsT();
        int n = 0;
        public Animals()
        {
            InitializeComponent();
            foreach (var text in db.AnimalsT)
            {
                if (n == 0)
                {
                    txtZebr.Text = text.Animal + text.Name + text.Weight + text.Height;
                    n = 1;
                }
                else if (n == 1)
                {
                    txtNos.Text = text.Animal + text.Name + text.Weight + text.Height;
                    n = 2;
                }
                else if (n == 2)
                {
                    txtPing.Text = text.Animal + text.Name + text.Weight + text.Height;
                    n = 3;
                }
                if (Role.role == "User")
                {
                    EditB.Visibility = Visibility.Hidden;
                    txtID.Visibility = Visibility.Hidden;
                    lblID.Visibility = Visibility.Hidden;
                    txtZebr.IsReadOnly = true;
                    txtPing.IsReadOnly = true;
                    txtNos.IsReadOnly = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            General gen = new General();
            gen.Show();
            this.Close();
        }

        private void tab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                int id = Convert.ToInt32(txtID.Text);
                foreach (var text in db.AnimalsT)
                {
                    if (text.IDAnimal == id)
                    {
                        ani = text;
                        break;
                    }
                }
                if (id == 1)
                {
                    var lines = txtZebr.GetLineText(0);
                    ani.Animal = lines;
                    lines = txtZebr.GetLineText(1);
                    ani.Name = lines;
                    lines = txtZebr.GetLineText(2);
                    ani.Weight = lines;
                    lines = txtZebr.GetLineText(3);
                    ani.Height = lines;
                    db.SaveChanges();
                    MessageBox.Show("Информация обновлена!", "Успех!");
                }
                else if (id == 2)
                {
                    var lines = txtNos.GetLineText(0);
                    ani.Animal = lines;
                    lines = txtNos.GetLineText(1);
                    ani.Name = lines;
                    lines = txtNos.GetLineText(2);
                    ani.Weight = lines;
                    lines = txtNos.GetLineText(3);
                    ani.Height = lines;
                    db.SaveChanges();
                    MessageBox.Show("Информация обновлена!", "Успех!");
                }
                else if (id == 3)
                {
                    var lines = txtPing.GetLineText(0);
                    ani.Animal = lines;
                    lines = txtPing.GetLineText(1);
                    ani.Name = lines;
                    lines = txtPing.GetLineText(2);
                    ani.Weight = lines;
                    lines = txtPing.GetLineText(3);
                    ani.Height = lines;
                    db.SaveChanges();
                    MessageBox.Show("Информация обновлена!", "Успех!");
                }
                else
                {
                    MessageBox.Show("ID не существует", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Укажите ID", "Ошибка");
            }
                
        }

        private void txtID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
