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
using System.Windows.Shapes;

namespace QuanLyHocPhan
{
    /// <summary>
    /// Interaction logic for WholesomePopup.xaml
    /// </summary>
    public partial class WholesomePopup : Window
    {
        public WholesomePopup(string _content)
        {
            InitializeComponent();

            content.Text = _content;
        }
    }
}
