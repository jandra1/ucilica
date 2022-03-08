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
        List<string> predmeti = new List<string>();
        public Razred()
        {
            InitializeComponent();
            predmetiComboBox.Items.Add("geografija");
            predmetiComboBox.Items.Add("matematika");
            predmetiComboBox.Items.Add("hrvatski");
            predmetiComboBox.Items.Add("povijest");

            razredComboBox.Items.Add("5");
            razredComboBox.Items.Add("6");
            razredComboBox.Items.Add("7");
            razredComboBox.Items.Add("8");


            label4.Text = Form1.name + ", dobrodošao!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string predmet = predmetiComboBox.Text;
            Pitanje pitanje = new Pitanje(int.Parse(razredComboBox.Text), predmet, Form1.name);
            pitanje.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show(); // ponovno otvori login formu kako bi se drugi radnik mogao ulogirati
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bodovi bodovi = new Bodovi();
            bodovi.Show();
        }
    }
}
