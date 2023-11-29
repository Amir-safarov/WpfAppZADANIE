﻿using System;
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
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        private int _basketCost;

        public Basket()
        {
            InitializeComponent();
            RefreshOrders();
        }

        private void RefreshOrders()
        {
            Order lastOrder = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
            IEnumerable<Prod_Ord> orderslist = App.DDBB.Prod_Ord.Where(x => x.ID_ord == lastOrder.ID & lastOrder.Enable == true);
            if (lastOrder != null)
            {
                foreach (var order in orderslist)
                {
                    _basketCost += (int)(order.Product.Cost * order.Prod_count); 
                    OrderWrap.Children.Add(new OrderUserControl(order));
                }
                BasketCost.Text = $"Цена корзины: {_basketCost}";
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
                    _basketCost += (int)(order.Product.Cost * order.Prod_count);
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
    }
}
