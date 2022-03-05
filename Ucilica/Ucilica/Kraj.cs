using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ucilica
{
    public partial class Kraj : Form
    {
        public Kraj(int b, string time)
        {
            InitializeComponent();
            label4.Text = time;
            label2.Text = b + "/90";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
