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
using KHOpenAPILib;

namespace KiwoomAPITest
{
// 포팅 하는 법 참조 : https://tech.sangron.com/archives/84
    public partial class MainWindow : Window
    {
        KHAxLib.KHAxControl khAxCtr = null;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();
            khAxCtr = new KHAxLib.KHAxControl();
            host.Child = khAxCtr;
            this.grid1.Children.Add(host);

            if (khAxCtr.CommConnect() == 0)
            {
                tb1.Text = "Success";
            }
            else
            {
                tb1.Text = "Fail";
            }



        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = khAxCtr.GetMasterListedStockCnt().ToString();
        }
    }
}
