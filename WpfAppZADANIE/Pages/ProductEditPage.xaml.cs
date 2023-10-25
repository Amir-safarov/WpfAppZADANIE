using Microsoft.Win32;
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

namespace WpfAppZADANIE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        private Product product;
        public ProductEditPage(Product product)
        {
            InitializeComponent();
            this.product = product;

            this.DataContext = product;
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|All files (*.*)|*.*"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName)); ;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();           
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.DDBB.SaveChanges();
            ModernNavigationSystem.BackPage();
        }
        private void OnlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
