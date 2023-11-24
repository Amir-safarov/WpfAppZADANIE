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
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            IEnumerable<Product> productList = App.DDBB.Product;

            foreach (var item in productList)
            {
                ProductWrap.Children.Add(new ProductUserControl(item));
            }
        }
        private void Refresh()
        {
            IEnumerable<Product> servicesSortList = App.DDBB.Product;
            if (PriceSortCB.SelectedIndex > 0)
            {
                if (PriceSortCB.SelectedIndex == 1)
                    servicesSortList = servicesSortList.OrderBy(x => x.GetRelevancePrice);
                else if (PriceSortCB.SelectedIndex == 2)
                    servicesSortList = servicesSortList.OrderByDescending(x => x.GetRelevancePrice);
            }

            if (DiscountSortCB.SelectedIndex > 0)
            {
                if (DiscountSortCB.SelectedIndex == 1)
                    servicesSortList = servicesSortList.Where(x => x.Discount <= 5);
                else if (DiscountSortCB.SelectedIndex == 2)
                    servicesSortList = servicesSortList.Where(x => x.Discount > 5 && x.Discount <= 15);
                else if (DiscountSortCB.SelectedIndex == 3)
                    servicesSortList = servicesSortList.Where(x => x.Discount > 15 && x.Discount <= 30);
                else if (DiscountSortCB.SelectedIndex == 4)
                    servicesSortList = servicesSortList.Where(x => x.Discount > 30 && x.Discount <= 70);
                else if (DiscountSortCB.SelectedIndex == 5)
                    servicesSortList = servicesSortList.Where(x => x.Discount > 70);
            }

            if (SearchTextBox.Text != "" || SearchTextBox.Text != null)
                servicesSortList = servicesSortList.Where(x =>
                    x.Title.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                    x.Description.ToLower().Contains(SearchTextBox.Text.ToLower()));

            ProductWrap.Children.Clear();
            foreach (var item in servicesSortList)
            {
                ProductWrap.Children.Add(new ProductUserControl(item));
            }
            CountDataText.Text = $"{servicesSortList.Count()} из {App.DDBB.Product.Count()}";
        }

        private void PriceSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            ModernNavigationSystem.NextPage(new PageComponent("Добавление товара", new ProductEditPage(new Product())));
        }

        
    }
}
