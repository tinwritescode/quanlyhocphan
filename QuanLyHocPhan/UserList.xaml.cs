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
using Oracle.ManagedDataAccess.Client;

namespace QuanLyHocPhan
{
    public class User
    {
        public String Username { get; set; }

        public string Userid { set; get; }
        public String Created { get; set; }
    }

    public class Database
    {
        public String TableName { get; set; }
    }

    public class PermissionResponse
    {
        public String Username { get; set; }
        public String Privilege { get; set; }
        public String AdminOption { get; set; }
    }

    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

        private List<User> users;
        private OracleConnection oracleConnection;

        public void btnCheckInfo_Click(object sender, RoutedEventArgs e)
        {
            //SELECT * FROM USER_SYS_PRIVS WHERE username='TRUNGTIN'
            // get selected user from datagrid
            User user = (User)UserDataGrid.SelectedItem;

            // get all databases
            OracleCommand cmd = new OracleCommand("SELECT USERNAME, PRIVILEGE, ADMIN_OPTION FROM USER_SYS_PRIVS WHERE username='" + user.Username.ToUpper() + "'", oracleConnection);
            OracleDataReader reader = cmd.ExecuteReader();

            // create list of permission
            List<PermissionResponse> permissions = new List<PermissionResponse>();

            while (reader.Read())
            {
                PermissionResponse permission = new PermissionResponse();
                permission.Username = reader.GetString(0);
                permission.Privilege = reader.GetString(1);
                permission.AdminOption = reader.GetString(2);
                permissions.Add(permission);
            }

            string data = "";

            // loop through
            foreach (PermissionResponse permission in permissions)
            {
                data += permission.Username + " " + permission.Privilege + " " + permission.AdminOption + "\n";
            }

            // show in WholesomePopup window
            new WholesomePopup(data).Show();
        }

        public void btnGrantRole_Click(object sender, RoutedEventArgs e)
        {
        }

        public UserList(OracleConnection connection)
        {
            InitializeComponent();

            // set ItemsSource for DataGrid
            users = new List<User>();
            oracleConnection = connection;

            // get all users
            OracleCommand cmd = new OracleCommand("select username, user_id, created from all_users", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();
                user.Username = reader.GetString(0);
                user.Userid = reader.GetString(1);
                user.Created = reader.GetString(2);
                users.Add(user);
            }

            UserDataGrid.ItemsSource = users;
        }
    }
}
