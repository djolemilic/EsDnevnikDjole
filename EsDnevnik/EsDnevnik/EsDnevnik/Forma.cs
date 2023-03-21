using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsDnevnik
{
    public partial class Forma : Form
    {
        DataTable informacije;
        SqlCommand promene;
        string tabela;


        public Forma(string ime)
        {
            tabela = ime;
            
            InitializeComponent();
        }


        private void Refresh(string tabela)
        {
            try
            {
                informacije = new DataTable();
                informacije = Konekcija.Unos("SELECT * FROM " + tabela);
                if (dataGridView1.Rows.Count != 1)
                {
                    while (dataGridView1.Rows.Count != 1)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                    }
                }

                if (tabela == "Predmet")
                {
                    textBox3.Visible = true;
                    label3.Visible = true;
                    label2.Text = tabela;
                    dataGridView1.Columns["Smer"].Visible = false;
                    for (int i = 0; i < informacije.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["IDD"].Value = Convert.ToString(informacije.Rows[i]["id"]);
                        dataGridView1.Rows[i].Cells["Predmet"].Value = Convert.ToString(informacije.Rows[i]["naziv"]);
                        dataGridView1.Rows[i].Cells["Razred"].Value = Convert.ToString(informacije.Rows[i]["razred"]);
                    }

                }
                else if (tabela == "Smer")
                {
                    label2.Text = tabela;
                    dataGridView1.Columns["Predmet"].Visible = false;
                    dataGridView1.Columns["Razred"].Visible = false;

                    for (int i = 0; i < informacije.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["IDD"].Value = Convert.ToString(informacije.Rows[i]["id"]);
                        dataGridView1.Rows[i].Cells["Smer"].Value = Convert.ToString(informacije.Rows[i]["naziv"]);
                    }
                }
                else
                {
                    label2.Text = "Skolska godina";
                    dataGridView1.Columns["Predmet"].Visible = false;
                    dataGridView1.Columns["Razred"].Visible = false;
                    dataGridView1.Columns["Smer"].Visible = false;
                    dataGridView1.Columns["IDD"].Visible = false;
                    dataGridView1.DataSource = informacije;
                    dataGridView1.Columns["id"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
        }

        private void Skolska_Godina_Load(object sender, EventArgs e)
        {
            Refresh(tabela);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                        int indeks;
                        if (tabela == "Skolska_godina")
                        {
                            indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        }
                        else
                        {
                            indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDD"].Value);
                        }

                        promene = new SqlCommand();
                        promene.CommandText = ("DELETE FROM " + tabela + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        Refresh(tabela);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh(tabela);
                }
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                        promene = new SqlCommand();

                        if (tabela == "Predmet")
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDD"].Value);
                            string razred;
                            razred = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Razred"].Value);
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);

                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv, razred FROM " + tabela + " WHERE naziv = " + "'" + naziv + "' AND razred = " + "'" + razred + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks +
                                " UPDATE " + tabela + " SET razred = " + "'" + razred + "'" + " WHERE id = " + indeks);
                        }
                        else if (tabela == "Smer")
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDD"].Value);
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Smer"].Value);

                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks);
                        }
                        else
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["naziv"].Value);

                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks);
                        }

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();

                        Refresh(tabela);
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh(tabela);
                }
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                        promene = new SqlCommand();

                        if (tabela == "Predmet")
                        {
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Predmet"].Value);
                            string razred;
                            razred = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Razred"].Value);

                            if (naziv == "" || razred == "")
                            {
                                throw new Exception();
                            }

                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv, razred FROM " + tabela + " WHERE naziv = " + "'" + naziv + "' AND razred = " + "'" + razred + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "', " + "'" + razred + "')");
                        }
                        else if (tabela == "Smer")
                        {
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Smer"].Value);
                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "')");
                        }
                        else
                        {
                            string naziv;
                            naziv = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["naziv"].Value);
                            informacije = new DataTable();
                            informacije = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (informacije.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "')");
                        }

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();

                        Refresh(tabela);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh(tabela);
                }
            }


        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int indeks = dataGridView1.CurrentRow.Index;

                if (tabela == "Skolska_godina")
                {
                    textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["id"].Value);
                    textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["naziv"].Value);
                }
                else if (tabela == "Smer")
                {
                    textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["IDD"].Value);
                    textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Smer"].Value);
                }
                else
                {
                    textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["IDD"].Value);
                    textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Predmet"].Value);
                    textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Razred"].Value);
                }
            }
        }
    }
}
