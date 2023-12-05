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
using System.Windows.Threading;
using WpfAppZADANIE.Comp;

namespace WpfAppZADANIE.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        private int _basketCost;
        private DispatcherTimer timer;

        public Basket()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            Loaded += MainWindow_Loaded;
            Unloaded += MainWindow_UnLoaded;
            RefreshOrders();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshCost();
            RefreshOrders();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void MainWindow_UnLoaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        private void RefreshOrders()
        {
            OrderWrap.Children.Clear();
            Order lastOrder = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
            IEnumerable<Prod_Ord> orderslist = App.DDBB.Prod_Ord.Where(x => x.ID_ord == lastOrder.ID & lastOrder.Enable == true);
            if (lastOrder != null)
            {
                foreach (var order in orderslist)
                    OrderWrap.Children.Add(new OrderUserControl(order));
            }
            else
                return;
        }
        public void RefreshCost()
        {
            _basketCost = 0;
            Order lastOrder = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
            IEnumerable<Prod_Ord> orderslist = App.DDBB.Prod_Ord.Where(x => x.ID_ord == lastOrder.ID & lastOrder.Enable == true);
            if (lastOrder != null)
            {
                foreach (var order in orderslist)
                {
                    if (order.Product == null)
                        _basketCost += 0;
                    else
                        _basketCost += (int)(int.Parse(order.Product.GetRelevancePriceINT) * order.Prod_count);
                }
                BasketCost.Text = $"Цена корзины: {_basketCost}";
            }
            else
                return;
        }

        private void BuyBTN_Click(object sender, RoutedEventArgs e)
        {
            Order lastOrder = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
            if (lastOrder.Enable == false)
            {
                MessageBox.Show("Корзина пуста. Дырка от бублика. Ничего. НИ-ЧЕ-ГО.");
                return;
            }
            else
            {
                lastOrder.Enable = false;
                App.DDBB.SaveChanges();
                MessageBox.Show($"Заказ {lastOrder.ID} офорлмен. Он пропал в небытие.");
                ModernNavigationSystem.BackPage();
            }
        }

        private void RefreshCostBTN_Click(object sender, RoutedEventArgs e)
        {
            RefreshCost();
        }

        private void CrashBasketBTN_Click(object sender, RoutedEventArgs e)
        {
            int countDeleted = 0;
            _basketCost = 0;
            Order lastOrder = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
            IEnumerable<Prod_Ord> orderslist = App.DDBB.Prod_Ord.Where(x => x.ID_ord == lastOrder.ID & lastOrder.Enable == true);
            foreach(var order in orderslist)
            {
                App.DDBB.Prod_Ord.Remove(order);
                countDeleted++;
            }
            App.DDBB.Order.Remove(lastOrder);
            RefreshOrders();
            BasketCost.Text = $"Цена корзины: {_basketCost}";
            App.DDBB.SaveChanges();
            ModernNavigationSystem.BackPage();
            MessageBox.Show($"Корзина очищена. Удалено {countDeleted} товаров.");

        }
    }
}
