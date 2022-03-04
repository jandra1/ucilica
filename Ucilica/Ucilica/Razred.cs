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
        dataBase db = new dataBase();
        List<string> predmeti = new List<string>();
        public Razred()
        {
            InitializeComponent();
            //predmeti = db.getTableNames();
            predmeti.Add("geografija");
            predmeti.Add("matematika");
            predmeti.Add("hrvatski");
            predmeti.Add("povijest");
            foreach(string predmet in predmeti) predmetiComboBox.Items.Add(predmet);

            label4.Text = Form1.name + ", dobrodošao!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string predmet = predmetiComboBox.Text;
            Pitanje pitanje = new Pitanje(int.Parse(textBox1.Text), predmet);
            pitanje.Show();
            
        }
    }
}
