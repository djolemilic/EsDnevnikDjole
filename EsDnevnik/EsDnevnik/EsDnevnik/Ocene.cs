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

namespace EsDnevnik
{
    public partial class Ocene : Form
    {
        DataTable podaci, podaci1;
        SqlCommand menjanja;
        string[] pomocna;

        public Ocene()
        {
            InitializeComponent();
        }

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
                        menjanja.CommandText = ("DELETE FROM Ocena WHERE id = " + indeks);

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
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string datum = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Datum"].Value);
                        string raspodela = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string ocena = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ocena"].Value);
                        string predmet = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Raspodela WHERE predmet_id = " + predmet_id);
                        int raspodela_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Ocena WHERE datum = '" + datum + "' AND raspodela_id = " + raspodela_id + " AND ocena = '" + ocena + "' AND ucenik_id = " + osoba_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("UPDATE Ocena SET datum = '" + datum + "' WHERE id = " + indeks +
                            " UPDATE Ocena SET raspodela_id = " + raspodela_id + " WHERE id = " + indeks +
                            " UPDATE Ocena SET ocena = '" + ocena + "' WHERE id = " + indeks +
                            " UPDATE Ocena SET ucenik_id = " + osoba_id + " WHERE id = " + indeks);

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
                        string[] ime_prezime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string datum = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Datum"].Value);
                        string ocena = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Ocena"].Value);
                        string predmet = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || predmet == "" || datum == "" || ocena == "") throw new Exception();

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Raspodela WHERE predmet_id = " + predmet_id);
                        int raspodela_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Ocena WHERE datum = '" + datum + "' AND raspodela_id = " + raspodela_id + " AND ocena = '" + ocena + "' AND ucenik_id = " + osoba_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("INSERT INTO Ocena VALUES ('" + datum + "', " + raspodela_id + ", " + ocena + ", " + osoba_id + ")");

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

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Ocena.id AS Id, datum AS Datum, Osoba.ime + ' ' + Osoba.prezime AS Ucenik, ocena AS Ocena, Predmet.naziv AS Predmet FROM Ocena\r\n JOIN Osoba ON Ocena.ucenik_id = Osoba.id\r\n JOIN Raspodela ON Raspodela.id = Ocena.raspodela_id\r\n JOIN Predmet ON Predmet.id = Raspodela.predmet_id");

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
                dataGridView1.Rows[i].Cells["Id"].Value = Convert.ToString(podaci.Rows[i]["Id"]);
                dataGridView1.Rows[i].Cells["Datum"].Value = Convert.ToString(podaci.Rows[i]["Datum"]);
                dataGridView1.Rows[i].Cells["Ime_i_prezime"].Value = Convert.ToString(podaci.Rows[i]["Ucenik"]);
                dataGridView1.Rows[i].Cells["Ocena"].Value = Convert.ToString(podaci.Rows[i]["Ocena"]);
                dataGridView1.Rows[i].Cells["Predmet"].Value = Convert.ToString(podaci.Rows[i]["Predmet"]);
            }
        }

        private void Ocene_Load(object sender, EventArgs e)
        {
            podaci1 = new DataTable();//Dodavanje ucenika
            podaci1 = Konekcija.Unos("SELECT ime + ' ' + prezime AS Ucenik FROM Osoba WHERE ULOGA = 1");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["Ucenik"]);
                Ime_i_prezime.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje predmeta
            podaci1 = Konekcija.Unos("SELECT DISTINCT naziv FROM Predmet");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["naziv"]);
                Predmet.Items.Add(pomocna[i]);
            }

            Osvezi();
        }
    }
}
