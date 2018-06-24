using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHAxLib
{
    public partial class KHAxControl: UserControl
    {
        public KHAxControl()
        {
            InitializeComponent();
        }

        public int CommConnect()//connect
        {
            return axKHOpenAPI1.CommConnect();
        }
        public long GetMasterListedStockCnt(){
            return axKHOpenAPI1.GetMasterListedStockCnt("000810");
        }

    }
}
