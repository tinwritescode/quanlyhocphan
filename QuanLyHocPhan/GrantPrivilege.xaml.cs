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
using System.Windows.Shapes;

namespace QuanLyHocPhan
{
    /// <summary>
    /// Interaction logic for GrantPrivilege.xaml
    /// </summary>
    public partial class GrantPrivilege : Window
    {
        public GrantPrivilege(OracleConnection Connection)
        {
            InitializeComponent();

            ChonQuyen.Items.Add("SELECT");
            ChonQuyen.Items.Add("INSERT");
            ChonQuyen.Items.Add("UPDATE");
            ChonQuyen.Items.Add("DELETE");


            // get all users
            OracleCommand cmd = new OracleCommand("select username from all_users", Connection);
            OracleDataReader reader = cmd.ExecuteReader();

            // create list of user
            var users = new List<string>();
            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }

            // set 
            CapChoAi.ItemsSource = users;
            ChonSchema.ItemsSource = users;


            // on schema change
            ChonSchema.SelectionChanged += (sender, e) =>
            {
                // get all tables
                OracleCommand cmd2 = new OracleCommand("select table_name from all_tables where owner='" + ChonSchema.SelectedItem + "'", Connection);
                OracleDataReader reader2 = cmd2.ExecuteReader();

                // create list of table
                var tables = new List<string>();
                while (reader2.Read())
                {
                    tables.Add(reader2.GetString(0));
                }

                // set 
                ChonBang.ItemsSource = tables;
            };

            // on button click
            CapQuyen.Click += (sender, e) =>
            {
                try
                {

                    // get selected user
                    string user = CapChoAi.SelectedItem.ToString();

                    // get selected table
                    string table = ChonBang.SelectedItem.ToString();

                    // get selected privilege
                    string privilege = ChonQuyen.SelectedItem.ToString();

                    // get selected schema
                    string schema = ChonSchema.SelectedItem.ToString();


                    // grant
                    OracleCommand cmd3 = new OracleCommand("grant " + privilege + " on " + schema + "." + table + " to " + user, Connection);
                    cmd3.ExecuteNonQuery();

                    //alert in vietnamese
                    MessageBox.Show("Đã cấp quyền " + privilege + " cho người dùng " + user + " trên bảng " + table + " của schema " + schema);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thất bại: " + ex.Message);
                }
            };


            HuyQuyen.Click += (sender, e) =>
            {
                try
                {

                    // get selected user
                    string user = CapChoAi.SelectedItem.ToString();

                    // get selected table
                    string table = ChonBang.SelectedItem.ToString();

                    // get selected privilege
                    string privilege = ChonQuyen.SelectedItem.ToString();

                    // get selected schema
                    string schema = ChonSchema.SelectedItem.ToString();

                    // revoke
                    OracleCommand cmd3 = new OracleCommand("revoke " + privilege + " on " + schema + "." + table + " from " + user, Connection);
                    cmd3.ExecuteNonQuery();

                    //alert in vietnamese
                    MessageBox.Show("Đã hủy quyền " + privilege + " cho người dùng " + user + " trên bảng " + table + " của schema " + schema);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thất bại: " + ex.Message);
                }
            };


            CapChoAi.SelectionChanged += (sender, e) =>
                {
                    if (CapChoAi.SelectedItem == null) return;

                    // update KiemTraQuyen button
                    KiemTraQuyen.Content = "Kiểm tra quyền của " + CapChoAi.SelectedItem.ToString();
                };

            KiemTraQuyen.Click += (sender, e) =>
                    {
                        try
                        {
                            // get all privileges just on specified table
                            OracleCommand cmd4;

                            if (CapChoRole.IsChecked == true)
                            {
                                cmd4 = new OracleCommand("select privilege from user_role_privs where grantee='" + CapChoAi.SelectedItem.ToString() + "' and table_name='" + ChonBang.SelectedItem.ToString() + "'", Connection);
                            }
                            else
                            {
                                cmd4 = new OracleCommand("select privilege from user_tab_privs where grantee='" + CapChoAi.SelectedItem.ToString() + "' and table_name='" + ChonBang.SelectedItem.ToString() + "'", Connection);
                            }

                            //print command to console
                            Console.WriteLine(cmd4.CommandText);
                            OracleDataReader reader4 = cmd4.ExecuteReader();

                            // create list of privilege
                            var privileges = new List<string>();
                            while (reader4.Read())
                            {
                                privileges.Add(reader4.GetString(0));
                            }

                            string platten = privileges.Aggregate((i, j) => i + ", " + j);

                            MessageBox.Show("Quyền của người dùng " + CapChoAi.SelectedItem.ToString() + " trên bảng " + ChonBang.SelectedItem.ToString() + " của schema " + ChonSchema.SelectedItem.ToString() + ": " + platten);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thao tác thất bại, có thể là do bạn chưa điền đủ thông tin hoặc người dùng không có quyền trên bảng này: " + ex.Message);
                        }
                    };

            // CapChoRole is checkbox, handle change
            CapChoRole.Checked += (sender, e) =>
            {

                try
                {

                    // get all roles
                    OracleCommand cmd5 = new OracleCommand("select role from dba_roles", Connection);
                    OracleDataReader reader5 = cmd5.ExecuteReader();

                    // create list of roles
                    var roles = new List<string>();
                    while (reader5.Read())
                    {
                        roles.Add(reader5.GetString(0));
                    }

                    // set
                    CapChoAi.ItemsSource = roles;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Người dùng không có quyền truy cập vào bảng dba_roles: " + error.Message);
                }
            };

            CapChoRole.Unchecked += (sender, e) =>
            {
                // get all users
                OracleCommand cmd6 = new OracleCommand("select username from all_users", Connection);
                OracleDataReader reader6 = cmd6.ExecuteReader();

                // create list of user
                var users2 = new List<string>();
                while (reader6.Read())
                {
                    users2.Add(reader6.GetString(0));
                }

                // set 
                CapChoAi.ItemsSource = users2;
            };

        }

    }
}
