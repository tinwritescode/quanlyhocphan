using Oracle.ManagedDataAccess.Client;
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
    /// Interaction logic for RoleList.xaml
    /// </summary>
    public partial class RoleList : Page
    {
        public RoleList(OracleConnection connection)
        {
            InitializeComponent();

            // get all users OracleCommand cmd = new OracleCommand("select username from all_users", Connection);
            OracleCommand cmd = new OracleCommand("select username from all_users", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            // create list of user
            var users = new List<string>();
            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }

            // set 
            ChonNguoiDung.ItemsSource = users;

            try
            {
                // get all roles 
                OracleCommand cmd2 = new OracleCommand("select role from DBA_ROLES", connection);
                OracleDataReader reader2 = cmd2.ExecuteReader();

                // create list of role
                var roles = new List<string>();
                while (reader2.Read())
                {
                    roles.Add(reader2.GetString(0));
                }

                ChonRole.ItemsSource = roles;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản của bạn không có quyền truy cập vào bảng DBA_ROLES");
            }


            CapQuyen.Click += (sender, e) =>
            {
                try
                {
                    // grant privilege
                    OracleCommand cmd3 = new OracleCommand("grant " + ChonRole.SelectedItem + " to " + ChonNguoiDung.SelectedItem, connection);
                    cmd3.ExecuteNonQuery();

                    // message box in vietnamsese
                    MessageBox.Show("Đã cấp Role " + ChonRole.SelectedItem + " cho người dùng " + ChonNguoiDung.SelectedItem + " thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            };

            HuyQuyen.Click += (sender, e) =>
            {
                try
                {

                    // revoke privilege
                    OracleCommand cmd3 = new OracleCommand("revoke " + ChonRole.SelectedItem + " from " + ChonNguoiDung.SelectedItem, connection);
                    cmd3.ExecuteNonQuery();

                    // message box in vietnamsese
                    MessageBox.Show("Đã hủy Role " + ChonRole.SelectedItem + " cho người dùng " + ChonNguoiDung.SelectedItem + " thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            };


        }
    }

}