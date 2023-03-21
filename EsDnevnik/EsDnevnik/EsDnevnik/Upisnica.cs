using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsDnevnik
{
    public partial class Upisnica : Form
    {
        DataTable podaci, podaci1;
        SqlCommand menjanja;
        string[] pomocna;
        public Upisnica()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Upisnica.id AS id, Osoba.ime + ' ' + Osoba.prezime AS 'ime i prezime', STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje, Smer.naziv AS Smer FROM Upisnica\r\nJOIN Osoba ON Upisnica.osoba_id = Osoba.id\r\nJOIN Odeljenje ON Upisnica.odeljenje_id = Odeljenje.id\r\nJOIN Smer ON Odeljenje.smer_id = Smer.id");

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
                dataGridView1.Rows[i].Cells["Id"].Value = Convert.ToString(podaci.Rows[i]["id"]);
                dataGridView1.Rows[i].Cells["Ime_i_prezime"].Value = Convert.ToString(podaci.Rows[i]["ime i prezime"]);
                dataGridView1.Rows[i].Cells["Odeljenje"].Value = Convert.ToString(podaci.Rows[i]["Odeljenje"]);
                dataGridView1.Rows[i].Cells["Smer"].Value = Convert.ToString(podaci.Rows[i]["Smer"]);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("DELETE FROM Upisnica WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);

                        Refresh();
                    
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
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string[] odeljenje = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Upisnica WHERE osoba_id = " + osoba_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("UPDATE Upisnica SET osoba_id = " + osoba_id + " WHERE id = " + indeks +
                            " UPDATE Upisnica SET odeljenje_id = " + odeljenje_id + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Refresh();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh();
                }
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string[] odeljenje = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');
                        string smer = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Smer"]);

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || odeljenje[0] == "" || odeljenje[1] == "" || smer == "")
                            throw new Exception();

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Upisnica WHERE osoba_id = " + osoba_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("INSERT INTO Upisnica VALUES (" + osoba_id + ", " + odeljenje_id + ")");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh();
                }
            }
        }

        private void Upisnica_Load(object sender, EventArgs e)
        {
            podaci1 = new DataTable();
            podaci1 = Konekcija.Unos("SELECT ime + ' ' + prezime AS 'ime i prezime' FROM Osoba WHERE uloga = 1");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["ime i prezime"]);
                Ime_i_prezime.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();
            podaci1 = Konekcija.Unos("SELECT STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje FROM Odeljenje");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["Odeljenje"]);
                Odeljenje.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();
            podaci1 = Konekcija.Unos("SELECT naziv FROM Smer");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["naziv"]);
                Smer.Items.Add(pomocna[i]);
            }
            Refresh();
        }
    }
}