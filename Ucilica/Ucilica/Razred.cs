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
    public partial class Razred : Form
    {
        public Razred()
        {

            InitializeComponent();

            label4.Text = Form1.name + ", dobrodošao!";
        }
    }
}
