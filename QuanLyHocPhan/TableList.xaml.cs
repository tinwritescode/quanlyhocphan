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
    public class Table
    {
        public String Tablename { get; set; }

        public string Tableid { set; get; }
        public String Created { get; set; }
    }

    /// <summary>
    /// Interaction logic for TableList.xaml
    /// </summary>
    public partial class TableList : Page
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

        private List<Table> tables;

        public void btnCheckInfo_Click(object sender, RoutedEventArgs e)
        {
        }

        public void btnGrantRole_Click(object sender, RoutedEventArgs e)
        {
        }

        public TableList(OracleConnection connection)
        {
            InitializeComponent();

            // set ItemsSource for DataGrid
            tables = new List<Table>();

            // get all users
            OracleCommand cmd = new OracleCommand("select username as schema_name, user_id, created from sys.all_users order by username", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Table table = new Table();
                table.Tablename = reader.GetString(0);
                table.Tableid = reader.GetString(1);
                table.Created = reader.GetString(2);
                tables.Add(table);
            }

            TableDataGrid.ItemsSource = tables;
        }
    }
}
