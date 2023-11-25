using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppZADANIE.Comp;

namespace WpfAppZADANIE
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShop_SAFEntities7 DDBB = new HardwareShop_SAFEntities7();
        public static bool isAdmin = false;
    }
}
