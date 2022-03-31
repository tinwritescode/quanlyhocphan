using Oracle.ManagedDataAccess.Client;
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

namespace QuanLyHocPhan
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

            userId.Text = "trungtin";
            password.Password = "aimabiet";

            loginButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(LoginHandler));
        }

        //private void SwitchToPortal(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //    PortalWindow portalWindow = new PortalWindow();
        //    portalWindow.Show();
        //}

        private async void LoginHandler(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {

                this.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        String connectionString = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + serviceName.Text + "))); User Id = " + userId.Text + "; Password = " + password.Password + ";";

                        // Please replace the connection string attribute settings
                        OracleConnection connection = new OracleConnection(connectionString);

                        connection.Open();

                        // Hide this windows and open portal window
                        this.Hide();
                        PortalWindow portalWindow = new PortalWindow(connection);
                        portalWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : {0}", ex);

                        MessageBox.Show("Error : " + ex.Message);
                    }
                });
            });

        }
    }
}
