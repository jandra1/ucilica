﻿using System;
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
    public partial class Dodaj : Form
    {
        public List<string> predmeti = new List<string>();
        public Dodaj()
        {
            InitializeComponent();
            predmeti.Add("geografija");
            predmeti.Add("matematika");
            predmeti.Add("hrvatski");
            predmeti.Add("povijest");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase db = new dataBase();
            if (!predmeti.Contains(textBox2.Text)){
                db.addSubject(textBox2.Text);
                
            }
            pitanjeKlasa pitanje = new pitanjeKlasa()
            {

            };
            db.addQuestion(pitanje);
        }
    }
}
