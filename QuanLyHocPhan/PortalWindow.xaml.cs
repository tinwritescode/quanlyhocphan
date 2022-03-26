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
    /// Interaction logic for PortalWindow.xaml
    /// </summary>
    public partial class PortalWindow : Window
    {
        private void btnDanhSachNguoiDung_Click(object sender, RoutedEventArgs e) {
            Main.Content = new UserList();
        } 

        private void btnDanhSachRole_Click(object sender, RoutedEventArgs e) {
            Main.Content = new RoleList();
        }

        private void btnThongTinNhom_Click(object sender, RoutedEventArgs e) {
            Main.Content = new GroupInfo();
        }

        public PortalWindow()
        {
            InitializeComponent();

            Main.Content = new UserList();

            
        }

    }

    //public class MenuItem {
    //    private String _name;
    //    private Page _page;

    //    public MenuItem(String name, Page page)
    //    {
    //        _name = name;
    //        _page = page;
    //    }
    //}
}
