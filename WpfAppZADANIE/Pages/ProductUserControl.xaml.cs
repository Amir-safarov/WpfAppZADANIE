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
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            ProductDescriptionTB.Text = product.GetDescription;
            ProductPriceTB.Text = product.GetRelevancePrice;
            OldProductPriceTB.Text = product.GetOldPrice;
            SaleTB.Text = product.GetSale;
            ReviewTB.Text = product.GetAverageFeedback;
            CountReviewTB.Text = product.GetReviewesAmount;
        }
    }
}
