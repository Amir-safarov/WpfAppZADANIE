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
using System.Xml.Serialization;
using WpfAppZADANIE.Comp;
using WpfAppZADANIE.Pages;
namespace WpfAppZADANIE.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        private Prod_Ord _order;
        private int _oneProdCost = 0;
        public OrderUserControl(Prod_Ord order)
        {
            InitializeComponent();
            _order = order;
            DataContext = _order;
            ShowCount.Text = _order.Prod_count.ToString();
            PerfectCostShow();
        }

        private void PerfectCostShow()
        {
            if (_order.Product == null)
                ShowPrice.Text = $"{_oneProdCost:0}₽";
            else
            {
                _oneProdCost = (int)(int.Parse(_order.Product.GetRelevancePriceINT) * _order.Prod_count);
                ShowPrice.Text = $"{_oneProdCost:0}₽";
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

        private void PlusCount_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(ShowCount.Text) < 99)
            {
                _order.Prod_count++;
                App.DDBB.SaveChanges();
                ShowCount.Text = (_order.Prod_count).ToString();
            };
            PerfectCostShow();
        }

        private void MinusCount_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(ShowCount.Text) > 1)
            {
                _order.Prod_count--;
                App.DDBB.SaveChanges();
                ShowCount.Text = (_order.Prod_count).ToString();
            };
            PerfectCostShow();
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            App.DDBB.Prod_Ord.Remove(_order);
            App.DDBB.SaveChanges();
        }
    }
}
