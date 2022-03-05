using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ucilica
{
    public partial class Pitanje: Form
    {
        string predmet;
        int razred;
        List<pitanjeKlasa> pitanja;
        dataBase db = new dataBase();
        Random rnd = new Random();
        pitanjeKlasa trenutnoPitanje;
        int brojac = 0;
        int bodovi = 0;
        private SoundPlayer yay;
        private SoundPlayer wrong;

        private Timer t;
        private int timeElapsed;
        public Pitanje(int _razred, string _predmet)
        {
            
            InitializeComponent();
            initializeTime();
            predmet = _predmet;
            razred = _razred;
            pitanja = db.getQuestionsByYearAndSubject(razred, predmet);
            
            yay = new SoundPlayer(Properties.Resources.yay);
            wrong = new SoundPlayer(Properties.Resources.wrong);
            sljedećePitanje();
        }

        private void odgovor1_Click(object sender, EventArgs e)
        {
            if(odgovor1.Text == trenutnoPitanje.točan)
            {
                odgovor1.BackColor = Color.Green;
                yay.Play();
                bodovi += 10;
            }
            else
            {
                odgovor1.BackColor = Color.Red;
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan) odgovor2.BackColor = Color.Green;
                else if (odgovor3.Text == trenutnoPitanje.točan) odgovor3.BackColor = Color.Green;
                else odgovor4.BackColor = Color.Green;
            }
        }

        private void odgovor2_Click(object sender, EventArgs e)
        {
            if (odgovor2.Text == trenutnoPitanje.točan)
            {
                odgovor2.BackColor = Color.Green;
                yay.Play();
                bodovi += 10;
            }
            else
            {
                odgovor2.BackColor = Color.Red;
                wrong.Play();
                if (odgovor1.Text == trenutnoPitanje.točan) odgovor1.BackColor = Color.Green;
                else if (odgovor3.Text == trenutnoPitanje.točan) odgovor3.BackColor = Color.Green;
                else odgovor4.BackColor = Color.Green;
            }
        }

        private void odgovor3_Click(object sender, EventArgs e)
        {
            if (odgovor3.Text == trenutnoPitanje.točan)
            {
                odgovor3.BackColor = Color.Green;
                yay.Play();
                bodovi += 10;
            }
            else
            {
                odgovor3.BackColor = Color.Red;
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan) odgovor2.BackColor = Color.Green;
                else if (odgovor4.Text == trenutnoPitanje.točan) odgovor4.BackColor = Color.Green;
                else odgovor1.BackColor = Color.Green;
            }
        }

        private void odgovor4_Click(object sender, EventArgs e)
        {
            if (odgovor4.Text == trenutnoPitanje.točan)
            {
                odgovor3.BackColor = Color.Green;
                yay.Play();
                bodovi += 10;
            }
            else
            {
                odgovor4.BackColor = Color.Red;
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan) odgovor2.BackColor = Color.Green;
                else if (odgovor3.Text == trenutnoPitanje.točan) odgovor3.BackColor = Color.Green;
                else odgovor1.BackColor = Color.Green;
            }
        }

        private void sljedećePitanje()
        {
            if (brojac > 9)
            {
                //kraj kviza
            }
            bodoviLabel.Text = "Bodovi: " + bodovi;
            odgovor1.BackColor = Color.FromKnownColor(KnownColor.Control);
            odgovor2.BackColor = Color.FromKnownColor(KnownColor.Control);
            odgovor3.BackColor = Color.FromKnownColor(KnownColor.Control);
            int i = rnd.Next(0, pitanja.Count);
            trenutnoPitanje = pitanja[i];
            pitanja.RemoveAt(i);
            pitanjeTextBox.Text = trenutnoPitanje.pitanje;
            List<string> odgovori = trenutnoPitanje.odgovori;
            int r = rnd.Next(0, odgovori.Count);
            odgovor1.Text = odgovori[r]; odgovori.RemoveAt(r);
            r = rnd.Next(0, odgovori.Count);
            odgovor2.Text = odgovori[r]; odgovori.RemoveAt(r);
            r = rnd.Next(0, odgovori.Count);
            odgovor3.Text = odgovori[r]; odgovori.RemoveAt(r);
            odgovor4.Text = odgovori[0];
            if (trenutnoPitanje.slika != "") //otvori sliku u novom prozoru
            {
                string imeSlike = trenutnoPitanje.slika;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imeSlike);
                pictureBox.Size = pictureBox.Image.Size;
                Form f = new Form();
                f.Size = pictureBox.Image.Size;
                f.Controls.Add(pictureBox);
                f.ShowDialog();
            }
            ++brojac;
        }

        private void initializeTime()
        {
            timeElapsed = 0;
            TimeSpan timespan = TimeSpan.FromMilliseconds(timeElapsed);
            time.Text = "Vrijeme: " + timespan.ToString(@"mm\:ss");
            t = new Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 1000;
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            timeElapsed += t.Interval;
            TimeSpan timespan = TimeSpan.FromMilliseconds(timeElapsed);
            time.Text = "Time: " + timespan.ToString(@"mm\:ss");
        }
    }
}
