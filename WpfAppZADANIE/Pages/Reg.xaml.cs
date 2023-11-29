using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void ZaxodBTN_Click(object sender, RoutedEventArgs e)
        {
            ////////////////////EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();
            ////////////////////if (emailAddressAttribute.IsValid(EmailTB.Text))
            ////////////////////    MessageBox.Show("kavasaki no4ta");
            ////////////////////else
            ////////////////////    MessageBox.Show("HOT kavasaki no4ta");
            ////////////////////PhoneAttribute phoneAttribute = new PhoneAttribute();
            ////////////////////if (phoneAttribute.IsValid(PhoneTB.Text))
            ////////////////////    MessageBox.Show("Снегр TEJleqpoHe");
            ////////////////////else
            ////////////////////    MessageBox.Show("HOT Снегр TEJleqpoHe");
            ///

            Regex no4ta = new Regex(@"^\S+@(gmail.com|mail.ru|🍌)$");
            if (no4ta.IsMatch(EmailTB.Text))
                MessageBox.Show("no4ta");
            else
                MessageBox.Show("HOT no4ta");

            Regex TEJleqpoHe = new Regex(@"^(\+7|8|🍌)\s(\d{3}|🍌🍌🍌)\s(\d{3}|🍌🍌🍌)\s(\d{2}|🍌🍌)\s(\d{2}|🍌🍌)$");
            if (TEJleqpoHe.IsMatch(PhoneTB.Text))
                MessageBox.Show("TEJleqpoHe");
            else
                MessageBox.Show("HOT TEJleqpoHe");
        }
    }
}
