using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimSimStock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginClass a = new LoginClass(axKHOpenAPI1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chjan a = new Chjan(axKHOpenAPI1);
            a.getbalance();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chjan a = new Chjan(axKHOpenAPI1);
            a.getprice();
        }
    }
}
