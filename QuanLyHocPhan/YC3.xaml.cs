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
    public class HSBA
    {
        public string MAHSBA { get; set; }
        public string MABN { get; set; }
        public string NGAY { get; set; }
        public string CHUANDOAN { get; set; }
        public string MABS { get; set; }
        public string MAKHOA { get; set; }
        public string MACSYT { get; set; }
        public string KETLUAN { get; set; }

    }

    /// <summary>
    /// Interaction logic for YC3.xaml
    /// </summary>
    public partial class YC3 : Window
    {
        public YC3()
        {
            InitializeComponent();

            List<HSBA> list = new List<HSBA>();

            // add sample data
            list.Add(new HSBA() { MAHSBA = "1", MABN = "1", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "1", MAKHOA = "1", MACSYT = "1", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "2", MABN = "2", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "2", MAKHOA = "2", MACSYT = "2", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "3", MABN = "3", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "3", MAKHOA = "3", MACSYT = "3", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "4", MABN = "4", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "4", MAKHOA = "4", MACSYT = "4", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "5", MABN = "5", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "5", MAKHOA = "5", MACSYT = "5", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "6", MABN = "6", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "6", MAKHOA = "6", MACSYT = "6", KETLUAN = "Kết luận" });
            list.Add(new HSBA() { MAHSBA = "7", MABN = "7", NGAY = "11/11/2011", CHUANDOAN = "Chuẩn", MABS = "7", MAKHOA = "7", MACSYT = "7", KETLUAN = "Kết luận" });


            // Add sample item to DSHSBA
            DSHSBA.ItemsSource = list;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
