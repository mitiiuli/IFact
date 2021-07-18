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
namespace Program_Facturat
{
    public partial class Fiscalizare : Form
    {
        
        string constring = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        IFact_Main main = new IFact_Main();
        public Fiscalizare()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(constring);
            connection.Open();

            string commandStr = "If not exists (select name from sysobjects where name = 'catalog_prod') CREATE TABLE catalog_prod(id int IDENTITY(1,1) PRIMARY KEY, denumire varchar(50), um varchar(20), pret_f_tva varchar(20), val_tva varchar(5), sterge varchar(50))";
            string str_fact_detalii = "If not exists (select name from sysobjects where name = 'fact_detalii') CREATE TABLE fact_detalii(id int IDENTITY(1,1) PRIMARY KEY, nr_doc varchar(10), nr_crt varchar(10), denumire varchar(50), um varchar(20), cant varchar(20), pret_f_tva varchar(20), valoare varchar(20), val_tva varchar(10), cota_tva varchar(10))";
            string str_date_firma = "If not exists (select name from sysobjects where name = 'Date_firma') CREATE TABLE Date_firma(id int IDENTITY(1,1) PRIMARY KEY, nume_firma varchar(50), CUI varchar(50), nr_reg_comert varchar(50), sediul varchar(50), nr_telefon varchar(50),cont varchar(50), banca varchar(50), email varchar(50))";
            string str_date_clienti = "If not exists (select name from sysobjects where name = 'Date_clienti') CREATE TABLE Date_clienti(id int IDENTITY(1,1) PRIMARY KEY, nume_firma varchar(50), CUI varchar(50), nr_reg_comert varchar(50), sediul varchar(50), nr_telefon varchar(50),cont varchar(50), banca varchar(50), email varchar(50), pers_contact varchar(50), tel_pers_contact varchar(50), email_pers_contact varchar(50))";
            string str_documente = "If not exists (select name from sysobjects where name = 'Documente') CREATE TABLE Documente(id int IDENTITY(1,1) PRIMARY KEY, nr_doc varchar(10), data_emitere varchar(20), data_scadenta varchar(20), suma_totala varchar(20), nume_firma varchar(50), CUI varchar(50), nr_reg_comert varchar(50), sediul varchar(50), cont varchar(50), banca varchar(50), incasata varchar(59))";
            SqlCommand comand = new SqlCommand(commandStr, connection);
            
            SqlCommand cmd_date_firma = new SqlCommand(str_date_firma, connection);
            SqlCommand cmd_date_clienti = new SqlCommand(str_date_clienti, connection);
            SqlCommand cmd_documente = new SqlCommand(str_documente, connection);
            SqlCommand cmd_fact_detalii = new SqlCommand(str_fact_detalii, connection);
            comand.ExecuteNonQuery();
            
            cmd_date_firma.ExecuteNonQuery();
            cmd_date_clienti.ExecuteNonQuery();
            cmd_documente.ExecuteNonQuery();
            cmd_fact_detalii.ExecuteNonQuery();
            string command1 = "SELECT iD from Date_firma";
            SqlCommand sc = new SqlCommand(command1, connection);
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.HasRows)
            {
                // Deschide fereastra de fiscalizare
               // Form2 main = new Form2();
                main.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Trebuie sa fiscalizezi mai intai !");
            }
            //reader.Close();
            connection.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string command2 = "INSERT into Date_firma( nume_firma, CUI, nr_reg_comert, sediul, nr_telefon, cont, banca, email) VALUES( @nume_firma, @CUI, @nr_reg_comert, @sediul, @nr_telefon, @cont, @banca, @email)";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand sc1 = new SqlCommand(command2, con);
            // Adauga firma in baza de date
            if (txt_nume_firma.Text.Length > 0 && txt_cui.Text.Length > 0 && txt_reg.Text.Length > 0 && txt_sediul.Text.Length > 0 && txt_telefon.Text.Length > 0 && txt_cont.Text.Length > 0 && txt_banca.Text.Length > 0 && txt_email.Text.Length > 0)
            {

                sc1.Parameters.AddWithValue("@nume_firma", txt_nume_firma.Text);
                sc1.Parameters.AddWithValue("@CUI", txt_cui.Text);
                sc1.Parameters.AddWithValue("@nr_reg_comert", txt_reg.Text);
                sc1.Parameters.AddWithValue("@sediul", txt_sediul.Text);
                sc1.Parameters.AddWithValue("@nr_telefon", txt_telefon.Text);
                sc1.Parameters.AddWithValue("@cont", txt_cont.Text);
                sc1.Parameters.AddWithValue("@banca", txt_banca.Text);
                sc1.Parameters.AddWithValue("@email", txt_email.Text);
                sc1.ExecuteNonQuery();
                txt_nume_firma.Clear();
                txt_cui.Clear();
                txt_reg.Clear();
                txt_sediul.Clear();
                txt_telefon.Clear();
                txt_cont.Clear();
                txt_banca.Clear();
                txt_email.Clear();
                button1.Visible = false;
                this.Hide();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Trebuie completate toate campurile !");
            }
            con.Close();
        }
    }
}
