using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsDnevnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void odeljenjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Odeljenje f1 = new Odeljenje();
            f1.ShowDialog();
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Osoba f2 = new Osoba();
            f2.ShowDialog();
        }

        private void skolskaGodinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forma f1 = new Forma("Skolska_godina");
            f1.Text = "Skolska godina";
            f1.ShowDialog();
        }

        private void smerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forma f1 = new Forma("Smer");
            f1.Text = "Smer";
            f1.ShowDialog();
        }

        private void predmetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forma f1 = new Forma("Predmet");
            f1.Text = "Predmet";
            f1.ShowDialog();
        }

        private void raspodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raspodela f = new Raspodela();
            f.ShowDialog();
        }

        private void upisnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upisnica f = new Upisnica();
            f.ShowDialog();
        }

        private void oceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ocene f = new Ocene();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
