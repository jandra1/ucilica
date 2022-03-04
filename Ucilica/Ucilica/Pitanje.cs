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
    public partial class Pitanje: Form
    {
        string predmet;
        int razred;
        dataBase db = new dataBase();
        Random rnd = new Random();
        public Pitanje()
        {
            InitializeComponent();
            List<pitanjeKlasa> pitanja = db.getQuestionsByYearAndubject(razred, predmet);
            int i = rnd.Next(0, pitanja.Count);
            pitanjeTextBox.Text = pitanja[].pitanje;
        }
    }
}
