using System;
using System.Collections.Generic;
using System.IO;
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
using WpfAppZADANIE.Properties;

namespace WpfAppZADANIE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        private Product product;
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            this.product = product;
            IconIMG.Source = GetimageSources(product.MainImage);
            ProductDescriptionTB.Text = product.GetDescription;
            ProductPriceTB.Text = product.GetRelevancePrice;
            OldProductPriceTB.Text = product.GetOldPrice;
            SaleTB.Text = product.GetSale;
            ReviewTB.Text = product.GetAverageFeedback;
            CountReviewTB.Text = product.GetReviewesAmount;
            if (App.isAdmin)
                BasketBTN.Visibility = Visibility.Collapsed;
            else
            {
                DelBTN.Visibility = Visibility.Hidden;
                EditBTN.Visibility = Visibility.Hidden;
            }
        }
        private BitmapImage GetimageSources(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream memoryStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memoryStream;
                image.EndInit();
                return image;
            }
            else
                return new BitmapImage(new Uri(@"\Resource\analys.png", UriKind.Relative));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            ModernNavigationSystem.NextPage(new PageComponent("Изменение товара", new ProductEditPage(product)));
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            App.DDBB.Product.Remove(product);
            App.DDBB.SaveChanges();
            ModernNavigationSystem.NextPage(new PageComponent("Список услуг", new ProductListPage()));
        }

        private void BasketBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = App.DDBB.Order.OrderByDescending(x => x.ID).FirstOrDefault();
                if (order == null || order.Enable == false)
                {
                    App.DDBB.Order.Add(new Order()
                    {
                        OrdDate = DateTime.UtcNow,
                        Enable = true
                    });
                    App.DDBB.Prod_Ord.Add(new Prod_Ord()
                    {
                        ID_prod = product.Id,
                        ID_ord = 1,
                        Prod_count = 2
                    });
                }
                else if (order.Enable == false)
                {
                    App.DDBB.Order.Add(new Order()
                    {
                        OrdDate = DateTime.UtcNow,
                        Enable = true
                    });
                    App.DDBB.Prod_Ord.Add(new Prod_Ord()
                    {
                        ID_prod = product.Id,
                        ID_ord = order.ID,
                        Prod_count = 2
                    });
                }
                else if (order.Enable == true)
                {
                    App.DDBB.Prod_Ord.Add(new Prod_Ord()
                    {
                        ID_prod = product.Id,
                        ID_ord = order.ID,
                        Prod_count = 2
                    });
                }
                App.DDBB.SaveChanges();
                MessageBox.Show($"Товар {product.Title} в корзине");
            }
            catch
            {
                MessageBox.Show("При попытке добавления товара в коризну что-то пошло н");
            }
        }
    }
}
