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
    public partial class Ticket : Window
    {
        ZooparkDEntities db = new ZooparkDEntities();
        TicketT ani = new TicketT();
        int n = 0;
        public Ticket()
        {
            InitializeComponent();
            foreach (var text in db.TicketT)
            {
                if (n == 0)
                {
                    txtPriceCh.Text = text.Price;
                    n = 1;
                }
                else if (n == 1)
                {
                    txtPriceAd.Text = text.Price;
                }
                if (Role.role == "User")
                {
                    EditB.Visibility = Visibility.Hidden;
                    txtPriceCh.IsReadOnly = true;
                    txtPriceAd.IsReadOnly = true;
                    txtID.Visibility = Visibility.Hidden;
                    lblID.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            General gen = new General();
            gen.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(txtCard.Text != "" && (txtTic.Text != "" || txtTic1.Text != ""))
            {
                MessageBox.Show("Билет успешно приобретен!", "Успех!");
            }
            else
            {
                MessageBox.Show("Некорректный ввод", "Ошибка!");
            }
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            if (txtPriceCh.Text != "" && txtPriceAd.Text != "")
            {
                int id = Convert.ToInt32(txtID.Text);
                foreach (var text in db.TicketT)
                {
                    if (text.IDTicket == id)
                    {
                        ani = text;
                        break;
                    }
                }
                if (id == 1)
                {
                    ani.Price = txtPriceCh.Text;
                    db.SaveChanges();
                    MessageBox.Show("Информация обновлена!", "Успех!");
                }
                else if (id == 2)
                {
                    ani.Price = txtPriceAd.Text;
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
