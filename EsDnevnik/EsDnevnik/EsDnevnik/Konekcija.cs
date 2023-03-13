using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace EsDnevnik
{
    class Konekcija
    {
        static public SqlConnection Connect()
        {
            string CS;
            CS = ConfigurationManager.ConnectionStrings["home"].ConnectionString;
            SqlConnection conn = new SqlConnection(CS);
            return conn;
        }

        static public string Veza()
        {
            return ConfigurationManager.ConnectionStrings["home"].ConnectionString;
        }

        static public DataTable Unos(string Komanda)
        {
            DataTable Tabela = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Komanda, Konekcija.Connect());
            adapter.Fill(Tabela);
            return Tabela;
        }

    }
}
