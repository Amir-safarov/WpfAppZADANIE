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
using WpfAppZADANIE.Pages;
using WpfAppZADANIE.Comp;
using System.IO;

namespace WpfAppZADANIE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ModernNavigationSystem.mainWindow = this;
            ModernNavigationSystem.NextPage(new PageComponent("Контора 'Эль - Доллара'", new LOG()));

            /*foreach (var item in App.DDBB.Product.ToArray())
            {
                item.MainImage = File.ReadAllBytes(item.ImagePath);
            }
            App.DDBB.SaveChanges();*/
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            ModernNavigationSystem.BackPage();
        }

        private void CrashBTN_Click(object sender, RoutedEventArgs e)
        {
            ModernNavigationSystem.BackAuth();
        }
    }
}
