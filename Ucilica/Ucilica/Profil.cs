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
    public partial class Profil : Form
    {
        string _name;
        int _razred;
        public Profil(string name, int razred)
        {
            InitializeComponent();
            _name = name;
            _razred = razred;
            label1.Text = name;
            if (razred == 0) label2.Text = "Nije odabran razred";
            else label2.Text = razred.ToString() + ". razred";
            dataBase db = new dataBase();
            List<Tuple<int, string, int, string>> rez = db.getResultsByName(name);
            RowStyle temp = resultTable.RowStyles[0];
            foreach(var r in rez)
            {
                resultTable.RowCount++;
                resultTable.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                Label raz = new Label();
                raz.Text = r.Item1.ToString();
                raz.Font = new Font(label7.Font.Name, 10);
                raz.Dock = DockStyle.Fill;
                raz.TextAlign = ContentAlignment.MiddleCenter;
                Label predmet = new Label();
                predmet.Text = r.Item2.ToString();
                predmet.Font = new Font(label7.Font.Name, 10);
                predmet.Dock = DockStyle.Fill;
                predmet.TextAlign = ContentAlignment.MiddleCenter;
                Label bodovi = new Label();
                bodovi.Text = r.Item3.ToString();
                bodovi.Font = new Font(label7.Font.Name, 10);
                bodovi.Dock = DockStyle.Fill;
                bodovi.TextAlign = ContentAlignment.MiddleCenter;
                Label vrijeme = new Label();
                vrijeme.Text = r.Item4.ToString();
                vrijeme.Font = new Font(label7.Font.Name, 10);
                vrijeme.Dock = DockStyle.Fill;
                vrijeme.TextAlign = ContentAlignment.MiddleCenter;
                resultTable.Controls.Add(predmet);
                resultTable.Controls.Add(raz);
                resultTable.Controls.Add(bodovi);
                resultTable.Controls.Add(vrijeme);
            }
           
        }

        private void nameButton_Click(object sender, EventArgs e)
        {

        }

        private void passButton_Click(object sender, EventArgs e)
        {

        }

        private void yearButton_Click(object sender, EventArgs e)
        {

        }

    }
}
