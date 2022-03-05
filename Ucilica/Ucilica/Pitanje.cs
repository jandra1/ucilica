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
using System.Threading;

namespace Ucilica
{
    public partial class Pitanje : Form
    {
        string predmet;
        int razred;
        List<pitanjeKlasa> pitanja;
        dataBase db = new dataBase();
        Random rnd = new Random();
        pitanjeKlasa trenutnoPitanje;
        int brojac = 0;
        int bodovi = 0;
        int time = 0;
        int gotovkviz = 0;
        string vrijeme = "";
        private SoundPlayer yay;
        private SoundPlayer wrong;
        public Pitanje(int _razred, string _predmet)
        {

            InitializeComponent();
            predmet = _predmet;
            razred = _razred;
            pitanja = db.getQuestionsByYearAndSubject(razred, predmet);

            yay = new SoundPlayer(Properties.Resources.yay);
            wrong = new SoundPlayer(Properties.Resources.wrong);
            sljedećePitanje();

        }

        private void odgovor1_Click(object sender, EventArgs e)
        {
            if (odgovor1.Text == trenutnoPitanje.točan)
            {
                odgovor1.BackColor = Color.Green;
                odgovor1.Refresh();
                yay.Play();
                bodovi += 10;
                Thread.Sleep(6000);
                sljedećePitanje();
            }
            else
            {
                odgovor1.BackColor = Color.Red;
                odgovor1.Refresh();
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan)
                {
                    odgovor2.BackColor = Color.Green;
                    odgovor2.Refresh();
                }
                else if (odgovor3.Text == trenutnoPitanje.točan)
                {
                    odgovor3.BackColor = Color.Green;
                    odgovor3.Refresh();
                }
                else
                {
                    odgovor4.BackColor = Color.Green;
                    odgovor4.Refresh();
                }
                Thread.Sleep(6000);
                sljedećePitanje();
            }
        }

        private void odgovor2_Click(object sender, EventArgs e)
        {
            if (odgovor2.Text == trenutnoPitanje.točan)
            {
                odgovor2.BackColor = Color.Green;
                odgovor2.Refresh();
                yay.Play();
                bodovi += 10;
                Thread.Sleep(6000);
                sljedećePitanje();
            }
            else
            {
                odgovor2.BackColor = Color.Red;
                odgovor2.Refresh();
                wrong.Play();
                if (odgovor1.Text == trenutnoPitanje.točan)
                {
                    odgovor1.BackColor = Color.Green;
                    odgovor1.Refresh();
                }
                else if (odgovor3.Text == trenutnoPitanje.točan)
                {
                    odgovor3.BackColor = Color.Green;
                    odgovor3.Refresh();
                }
                else
                {
                    odgovor4.BackColor = Color.Green;
                    odgovor4.Refresh();
                }
                Thread.Sleep(6000);
                sljedećePitanje();
            }
        }

        private void odgovor3_Click(object sender, EventArgs e)
        {
            if (odgovor3.Text == trenutnoPitanje.točan)
            {
                odgovor3.BackColor = Color.Green;
                odgovor3.Refresh();
                yay.Play();
                bodovi += 10;
                Thread.Sleep(6000);
                sljedećePitanje();
            }
            else
            {
                odgovor3.BackColor = Color.Red;
                odgovor3.Refresh();
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan)
                {
                    odgovor2.BackColor = Color.Green;
                    odgovor2.Refresh();
                }
                else if (odgovor4.Text == trenutnoPitanje.točan)
                {
                    odgovor4.BackColor = Color.Green;
                    odgovor4.Refresh();
                }
                else
                {
                    odgovor1.BackColor = Color.Green;
                    odgovor1.Refresh();
                }
                Thread.Sleep(6000);
                sljedećePitanje();
            }
        }

        private void odgovor4_Click(object sender, EventArgs e)
        {
            if (odgovor4.Text == trenutnoPitanje.točan)
            {
                odgovor4.BackColor = Color.Green;
                odgovor4.Refresh();
                yay.Play();
                bodovi += 10;
                Thread.Sleep(6000);
                sljedećePitanje();
            }
            else
            {
                odgovor4.BackColor = Color.Red;
                odgovor4.Refresh();
                wrong.Play();
                if (odgovor2.Text == trenutnoPitanje.točan)
                {
                    odgovor2.BackColor = Color.Green;
                    odgovor2.Refresh();
                }
                else if (odgovor3.Text == trenutnoPitanje.točan)
                {
                    odgovor3.BackColor = Color.Green;
                    odgovor3.Refresh();
                }
                else
                {
                    odgovor1.BackColor = Color.Green;
                    odgovor1.Refresh();
                }
                Thread.Sleep(6000);
                sljedećePitanje();
            }
        }

        private void sljedećePitanje()
        {
            if (brojac >= 9)
            {
                gotovkviz = 1;
                //kraj kviza
                this.Close();
                Kraj f = new Kraj(bodovi, vrijeme);
                f.Show();
            }

            odgovor1.BackColor = Color.FromKnownColor(KnownColor.Control);
            odgovor2.BackColor = Color.FromKnownColor(KnownColor.Control);
            odgovor3.BackColor = Color.FromKnownColor(KnownColor.Control);
            odgovor4.BackColor = Color.FromKnownColor(KnownColor.Control);
            var a = brojac;
            label1.Text = "Pitanje " + (a + 1) + ":";
            var mogucibodovi = a * 10;
            label2.Text = "Trenutno stanje bodova: " + bodovi + "/" + mogucibodovi;
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
                Form f = new Form();
                string ime = "..\\..\\pitanja i slike\\" + imeSlike;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = new Bitmap(ime);
                f.Controls.Add(pictureBox);
                //f.ShowDialog();
            }
            ++brojac;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gotovkviz = 1;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++time;
            var t = time;
            if(t < 60)
            {
                vrijeme = t.ToString() + " s";
                label3.Text = t.ToString() + " s";
            }
            else
            {
                var minute = 0;
                while( (t - 60) > 0)
                {
                    t -= 60;
                    ++minute;
                }
                vrijeme = minute.ToString() + " min " + t.ToString() + " s";
                label3.Text = minute.ToString() + " min " + t.ToString() + " s";
            }

            if (gotovkviz == 1)
            {
                timer1.Enabled = false;
            }
        }
    }
}
