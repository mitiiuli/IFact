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
using System.Configuration;

namespace Program_Facturat
{
    
    public partial class Modificare_date_clienti : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
       // string constring = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private readonly Adaugare_clienti frm1;
        public Modificare_date_clienti(Adaugare_clienti fr)
        {
            InitializeComponent();
            frm1 = fr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection(constring);
            string command1 = "UPDATE Date_clienti SET nume_firma=@nume_firma, CUI=@CUI, nr_reg_comert=@nr_reg_comert, sediul=@sediul, nr_telefon=@nr_telefon, cont=@cont, banca=@banca, email=@email, pers_contact=@pers_contact, tel_pers_contact=@tel_pers_contact, email_pers_contact=@email_pers_contact where id=@id";
            
            SqlCommand com1 = new SqlCommand(command1, constring);
            com1.Parameters.AddWithValue("@id", txt_id.Text);
            com1.Parameters.AddWithValue("@nume_firma", txt_nume_firma.Text);
            com1.Parameters.AddWithValue("@CUI", txt_cui.Text);
            com1.Parameters.AddWithValue("@nr_reg_comert", txt_reg.Text);
            com1.Parameters.AddWithValue("@sediul", txt_sediul.Text);
            com1.Parameters.AddWithValue("@nr_telefon", txt_telefon.Text);
            com1.Parameters.AddWithValue("@cont", txt_cont.Text);
            com1.Parameters.AddWithValue("@banca", txt_banca.Text);
            com1.Parameters.AddWithValue("@email", txt_email.Text);
            com1.Parameters.AddWithValue("@pers_contact", txt_pers_contact.Text);
            com1.Parameters.AddWithValue("@tel_pers_contact", txt_tel_pers_contact.Text);
            com1.Parameters.AddWithValue("@email_pers_contact", txt_email_pers_contact.Text);
            constring.Open();
            com1.ExecuteNonQuery();

            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = "SELECT * from Date_clienti";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, constring);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            frm1.dataGridView1.DataSource = bSource;
            constring.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection(constring);
            string command1 = "DELETE from Date_clienti where id=@id";
            SqlCommand com1 = new SqlCommand(command1, constring);
            com1.Parameters.AddWithValue("@id", txt_id.Text);
            constring.Open();
            com1.ExecuteNonQuery();
            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = "SELECT * from Date_clienti";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, constring);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            frm1.dataGridView1.DataSource = bSource;

            txt_nume_firma.Clear();
            txt_cui.Clear();
            txt_reg.Clear();
            txt_sediul.Clear();
            txt_telefon.Clear();
            txt_cont.Clear();
            txt_banca.Clear();
            txt_email.Clear();
            txt_pers_contact.Clear();
            txt_tel_pers_contact.Clear();
            txt_email_pers_contact.Clear();
            constring.Close();
            this.Close();
        }
    }
}
