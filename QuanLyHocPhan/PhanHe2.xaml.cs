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

namespace QuanLyHocPhan
{
    /// <summary>
    /// Interaction logic for PhanHe2.xaml
    /// </summary>
    public partial class PhanHe2 : Page
    {
        public PhanHe2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            YC1 window = new YC1();

            window.Show();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            YC2 window = new YC2();

            window.Show();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            YC3 window = new YC3();

            window.Show();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            YC4 window = new YC4();

            window.Show();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            YC5 window = new YC5();

            window.Show();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            YC6 window = new YC6();

            window.Show();
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            YC7 window = new YC7();

            window.Show();
        }
    }
}
