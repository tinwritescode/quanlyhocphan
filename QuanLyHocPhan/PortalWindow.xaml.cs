using System;
using System.Collections.Generic;
using System.Configuration;
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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace QuanLyHocPhan
{
    /// <summary>
    /// Interaction logic for PortalWindow.xaml
    /// </summary>
    public partial class PortalWindow : Window
    {
        OracleConnection Connection;

        ~PortalWindow()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Dispose();
                Connection.Close();
            }
        }

        private void btnDanhSachNguoiDung_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new UserList();
        }

        private void btnDanhSachRole_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RoleList();
        }

        private void btnThongTinNhom_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new GroupInfo();
        }

        public PortalWindow()
        {
            InitializeComponent();

            Main.Content = new UserList();

            try
            {
                // Please replace the connection string attribute settings
                Connection = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                Connection.Open();

                Console.WriteLine("Connected to Oracle Database {0}", Connection.ServerVersion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
            }

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
