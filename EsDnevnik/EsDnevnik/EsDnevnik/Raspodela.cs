using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace EsDnevnik
{
    public partial class Raspodela : Form
    {
        DataTable podaci, podaci1;
        SqlCommand menjanja;
        string[] pomocna;
        public Raspodela()
        {
            InitializeComponent();
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT raspodela.id, Osoba.ime + ' ' + Osoba.prezime AS Nastavnik, Skolska_godina.naziv AS Godina, Predmet.naziv AS Predmet, STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje FROM Raspodela left join Osoba ON Raspodela.nastavnik_id = Osoba.id left join Skolska_godina ON Raspodela.godina_id = Skolska_godina.id left join Predmet ON Raspodela.predmet_id = Predmet.id left join Odeljenje ON Raspodela.odeljenje_id = Odeljenje.id");

            if (dataGridView1.Rows.Count != 1)
            {
                while (dataGridView1.Rows.Count != 1)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }

            for (int i = 0; i < podaci.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = Convert.ToString(podaci.Rows[i]["id"]);
                dataGridView1.Rows[i].Cells["Nastavnik"].Value = Convert.ToString(podaci.Rows[i]["Nastavnik"]);
                dataGridView1.Rows[i].Cells["Godina"].Value = Convert.ToString(podaci.Rows[i]["Godina"]);
                dataGridView1.Rows[i].Cells["Predmet"].Value = Convert.ToString(podaci.Rows[i]["Predmet"]);
                dataGridView1.Rows[i].Cells["Odeljenje"].Value = Convert.ToString(podaci.Rows[i]["Odeljenje"]);
            }
        }

        private void Raspodela_Load(object sender, EventArgs e)
        {
            podaci1 = new DataTable();//Dodavanje skolskih godina
            podaci1 = Konekcija.Unos("SELECT naziv FROM Skolska_godina");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["naziv"]);
                Godina.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje nastavnika
            podaci1 = Konekcija.Unos("SELECT ime + ' ' + prezime AS Nastavnik FROM Osoba WHERE uloga = 2");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["Nastavnik"]);
                Nastavnik.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje predmeta
            podaci1 = Konekcija.Unos("SELECT DISTINCT naziv FROM Predmet");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["naziv"]);
                Predmet.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje odeljenja
            podaci1 = Konekcija.Unos("SELECT STR(razred,1,0) + '/' + indeks AS Odlj FROM Odeljenje");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["Odlj"]);
                Odeljenje.Items.Add(pomocna[i]);
            }
            Osvezi();
        }

       /* private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            int indeks;
            indeks = dataGridView1.CurrentRow.Index;
            textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["id"].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Nastavnik"].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Godina"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Predmet"].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Odeljenje"].Value);
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("DELETE FROM Raspodela WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);

                        Osvezi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nastavnik"].Value).Split(' ');
                        string godina = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Godina"].Value);
                        string predmet = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string[] odeljenje = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = " + "'" + godina + "'");
                        int godina_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Raspodela WHERE nastavnik_id = " + osoba_id + " AND godina_id = " + godina_id + " AND predmet_id = " + predmet_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("UPDATE Raspodela SET nastavnik_id = " + osoba_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET godina_id = " + godina_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET predmet_id = " + predmet_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET odeljenje_id = " + odeljenje_id + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Osvezi();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi();
                }
            }
            
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nastavnik"].Value).Split(' ');
                        string godina = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Godina"].Value);
                        string predmet = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string[] odeljenje = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || godina == "" || predmet == "" || odeljenje[0] == "" || odeljenje[1] == "")
                            throw new Exception();

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = " + "'" + godina + "'");
                        int godina_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Raspodela WHERE nastavnik_id = " + osoba_id + " AND godina_id = " + godina_id + " AND predmet_id = " + predmet_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("INSERT INTO Raspodela VALUES (" + osoba_id + ", " + godina_id + ", " + predmet_id + ", " + odeljenje_id + ")");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Osvezi();
                    }
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi();
                }
            }
        }
    }
}
