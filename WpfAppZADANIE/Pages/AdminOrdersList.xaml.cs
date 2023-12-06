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
using WpfAppZADANIE.Comp;

namespace WpfAppZADANIE.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminOrdersList.xaml
    /// </summary>
    public partial class AdminOrdersList : Page
    {
        public AdminOrdersList()
        {
            InitializeComponent();
            OrderListView.ItemsSource = App.DDBB.Order.ToList();
            StatusSortCB.SelectedIndex = 0;
        }

        private void StatusSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusSortCB.SelectedIndex == 0)
                OrderListView.ItemsSource = App.DDBB.Order.Where(x => x.Enable == false).ToList();
            if (StatusSortCB.SelectedIndex == 1)
                OrderListView.ItemsSource = App.DDBB.Order.Where(x => x.Enable == true).ToList();

        }

        private void ChangeOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListView.SelectedItem != null)
            {
                if ((OrderListView.SelectedItem as Order).Enable == false)
                    MessageBox.Show("Нельзя изменить статус данного заказа.");
                else
                    (OrderListView.SelectedItem as Order).Enable = false;
                App.DDBB.SaveChanges();
                OrderListView.ItemsSource = App.DDBB.Order.ToList();
            }
            else
                MessageBox.Show("Выберите запись");

        }
    }
}
