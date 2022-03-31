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
            Main.Content = new RoleList();
        }

        private void btnThongTinNhom_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new GroupInfo();
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

                    // fetch all users and MessageBox show
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT * FROM all_users";

                    cmd.CommandType = System.Data.CommandType.Text;

                    OracleDataReader reader = cmd.ExecuteReader();

                    // Create an array
                    List<User> list = new List<User>();

                    while (reader.Read())
                    {
                        // Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        User user = new User();
                        user.Username = reader.GetString(0);
                        user.Roles = reader.GetString(2);

                        list.Add(user);
                    }

                    reader.Dispose();
                    cmd.Dispose();
                }
                else
                {
                    throw new Exception("Connection is not open");
                }

                // Set main content
                Main.Content = new UserList(Connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);

                // Alert
                MessageBox.Show("Error : " + ex.Message);
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
