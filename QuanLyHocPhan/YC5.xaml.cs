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
    /// Interaction logic for YC5.xaml
    /// </summary>
    public partial class YC5 : Window
    {
        public YC5()
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

            List<HSBADV> list2 = new List<HSBADV>();

            // add sample data
            list2.Add(new HSBADV() { MAHSBA = "1", MADV = "1", NGAY = "11/11/2011", MAKTV = "1", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "2", MADV = "2", NGAY = "11/11/2011", MAKTV = "2", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "3", MADV = "3", NGAY = "11/11/2011", MAKTV = "3", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "4", MADV = "4", NGAY = "11/11/2011", MAKTV = "4", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "5", MADV = "5", NGAY = "11/11/2011", MAKTV = "5", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "6", MADV = "6", NGAY = "11/11/2011", MAKTV = "6", KETLUAN = "Kết luận" });
            list2.Add(new HSBADV() { MAHSBA = "7", MADV = "7", NGAY = "11/11/2011", MAKTV = "7", KETLUAN = "Kết luận" });
            // Add sample item to DSHSBA
            DSHSBA.ItemsSource = list;
            DSHSBADV.ItemsSource = list2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemHoSoBenhAn window = new ThemHoSoBenhAn();

            window.Show();
        }

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

        public class HSBADV
        {
            public string MAHSBA { get; set; }
            public string MADV { get; set; }
            public string NGAY { get; set; }
            public string MAKTV { get; set; }
            public string KETLUAN { get; set; }

        }
    }
}
