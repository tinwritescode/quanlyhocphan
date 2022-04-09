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
            Main.Content = new UserList(Connection);
        }

        private void btnDanhSachRole_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RoleList(Connection);
        }

        private void btnCapRole_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new GroupInfo();
        }

        private void btnDanhSachTable_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TableList(Connection);
        }

        private void btnCapQuyen_Click(object sender, RoutedEventArgs e)
        {
            // open window GrantPrivilege
            GrantPrivilege grantPrivilege = new GrantPrivilege(Connection);
            grantPrivilege.Show();
        }

        public PortalWindow(OracleConnection Connection)
        {
            InitializeComponent();

            try
            {
                this.Connection = Connection;

                // Check if the connection is open
                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connected to Oracle Database {0}", Connection.ServerVersion);

                    MessageBox.Show("Đăng nhập thành công " + Connection.ServerVersion);


                    // Set main content
                    Main.Content = new UserList(Connection);
                }
                else
                {
                    throw new Exception("Connection is not open");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);

                // Alert
                MessageBox.Show("Error : " + ex.Message);
            }

        }

        private void btnDangXuat(object sender, RoutedEventArgs e)
        {
            // close current windows and show login window
            this.Close();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
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
