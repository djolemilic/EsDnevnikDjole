using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Configuration;

namespace EsDnevnik
{
    public partial class Osoba : Form
    {
        DataTable osoba, promene;
        SqlCommand menjanja, resetovanje_id;
        int BrVrste;

        public Osoba()
        {
            InitializeComponent();
        }

        private void TextLoad()
        {

            if (osoba.Rows.Count == 1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                textBox1.Text = osoba.Rows[BrVrste][0].ToString();
                textBox2.Text = osoba.Rows[BrVrste][1].ToString();
                textBox3.Text = osoba.Rows[BrVrste][2].ToString();
                textBox4.Text = osoba.Rows[BrVrste][3].ToString();
                textBox5.Text = osoba.Rows[BrVrste][4].ToString();
                textBox6.Text = osoba.Rows[BrVrste][5].ToString();
                textBox7.Text = osoba.Rows[BrVrste][6].ToString();
                textBox8.Text = osoba.Rows[BrVrste][7].ToString();
                if (BrVrste == 0)
                {
                    button2.Enabled = false;
                    button1.Enabled = false;
                }
                else
                {
                    button2.Enabled = true;
                    button1.Enabled = true;
                }
                if (BrVrste == osoba.Rows.Count - 1)
                {
                    button6.Enabled = false;
                    button7.Enabled = false;
                }
                else
                {
                    button6.Enabled = true;
                    button7.Enabled = true;
                }
            }
        }

        private void Osoba_Load(object sender, EventArgs e)
        {
            osoba = new DataTable();
            osoba = Konekcija.Unos("SELECT * FROM Osoba");
            TextLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            BrVrste = 0;
            TextLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            if (BrVrste > 0)
            {
                BrVrste--;
                TextLoad();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            if (BrVrste < osoba.Rows.Count - 1)
            {
                BrVrste++;
                TextLoad();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text.Length == 13)
                {
                    if (textBox8.Text == "1" || textBox8.Text == "2")
                    {
                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("INSERT INTO Osoba VALUES (" + "'" + textBox2.Text + "'" + ", " + "'" + textBox3.Text + "'" + ", " + "'" + textBox4.Text + "'" + ", " + "'" + textBox5.Text + "'" + ", " + "'" + textBox6.Text + "'" + ", " + "'" + textBox7.Text + "'" + ", " + Convert.ToInt32(textBox8.Text) + ")");
                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        label9.Text = "Uspesno ste dodali podatak!";
                        label9.Visible = true;
                        osoba = new DataTable();
                        osoba = Konekcija.Unos("SELECT * FROM Osoba");
                        TextLoad();
                    }
                    else label9.Text = "Uloga mora biti ili 1 ili 2!"; label9.Visible = true;
                }
                else label9.Text = "JMBG mora imati 13 cifara!"; label9.Visible = true;
                
            }
            catch
            {
                label9.Text = "Niste uneli odgovarajuce podatke podatke!";
                label9.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text.Length == 13)
                {
                    if (textBox8.Text == "1" || textBox8.Text == "2")
                    {
                        int ID = Convert.ToInt32(textBox1.Text);
                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("UPDATE Osoba SET ime = " + "'" + textBox2.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET prezime = " + "'" + textBox3.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET adresa = " + "'" + textBox4.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET jmbg = " + "'" + textBox5.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET email = " + "'" + textBox6.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET pass = " + "'" + textBox7.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET uloga = " + Convert.ToInt32(textBox8.Text) + " WHERE id = " + ID);
                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        osoba = new DataTable();
                        osoba = Konekcija.Unos("SELECT * FROM Osoba");
                        TextLoad();
                        label9.Text = "Uspesno ste izmenili podatak!";
                        label9.Visible = true;
                    }
                    else label9.Text = "Uloga mora biti ili 1 ili 2!"; label9.Visible = true;
                }
                else label9.Text = "JMBG mora imati 13 cifara!"; label9.Visible = true;
            }
            catch
            {
                label7.Text = "Niste dobro uneli podatke!";
                label7.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            BrVrste = osoba.Rows.Count - 1;
            TextLoad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int max_id;
                menjanja = new SqlCommand();
                menjanja.CommandText = ("DELETE FROM Osoba WHERE id = " + Convert.ToInt32(textBox1.Text));
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT * FROM Osoba");
                max_id = promene.Rows.Count - 1;
                resetovanje_id = new SqlCommand();
                resetovanje_id.CommandText = ("DBCC CHECKIDENT ('Osoba', RESEED, " + max_id + ")");

                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Open();
                menjanja.Connection = con;
                resetovanje_id.Connection = con;
                menjanja.ExecuteNonQuery();
                resetovanje_id.ExecuteNonQuery();
                con.Close();

                label9.Text = "Uspesno ste obrisali podatak!";
                label9.Visible = true;
                osoba = new DataTable();
                osoba = Konekcija.Unos("SELECT * FROM Osoba");
                BrVrste = 0;
                TextLoad();
            }
            catch
            {
                label9.Text = "Ne mozete da obrisete dati podatak!";
                label9.Visible = true;
            }
        }
    }
}
