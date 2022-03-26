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
    public class User
    {
        public String Username { get; set; }

        // custom get roles return string
        public string Roles
        {
            set; get;
        }
        public bool IsChecked { get; set; }
    }


    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }


        public void btnCheckInfo_Click(object sender, RoutedEventArgs e)
        {
        }

        public void btnGrantRole_Click(object sender, RoutedEventArgs e)
        {
            // loop through all checkboxes, if checked, add to list
            // List<User> list = new List<User>();
            // foreach (User user in UserDataGrid.Items)
            // {
            //     if (user.IsChecked)
            //     {
            //         list.Add(user);
            //     }
            // }

            // // get each roles
            // string[] roles = new string[list.Count];
            // for (int i = 0; i < list.Count; i++)
            // {
            //     roles[i] = list[i].GetRole();
            // }

            // // alert roles plat
            // MessageBox.Show(string.Join(",", roles));
        }

        public UserList()
        {
            InitializeComponent();

            // Load data
            UserDataGrid.ItemsSource = new List<User>()
            {
                new User() { Username = "admin", Roles = "admin,user", IsChecked = false },
                new User() { Username = "trungtin", Roles = "admin", IsChecked = false }
            };

        }
    }
}
