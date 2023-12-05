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
            OrderListView.ItemsSource = App.DDBB.Prod_Ord.ToList();

        }

        private void StatusSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StatusSortCB.SelectedIndex == 0)
                OrderListView.ItemsSource = App.DDBB.Prod_Ord.Where(x => x.Order.Enable==false).ToList();
            if (StatusSortCB.SelectedIndex == 1)
                OrderListView.ItemsSource = App.DDBB.Prod_Ord.Where(x => x.Order.Enable == true).ToList();

        }
    }
}
