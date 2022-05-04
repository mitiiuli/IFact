using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using System.Data.SqlClient;
using System.Configuration;

namespace Program_Facturat
{
    public partial class Adaugare_clienti : Form
    {
        SqlConnection constring = new SqlConnection( ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        private readonly IFact_Main frm1;
        //string constring = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        public Adaugare_clienti(IFact_Main fr)
        {
            InitializeComponent();
            frm1 = fr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command2 = "INSERT into Date_clienti( nume_firma, CUI, nr_reg_comert, sediul, nr_telefon, cont, banca, email, pers_contact, tel_pers_contact, email_pers_contact) VALUES( @nume_firma, @CUI, @nr_reg_comert, @sediul, @nr_telefon, @cont, @banca, @email, @pers_contact, @tel_pers_contact, @email_pers_contact)";
            //SqlConnection con = new SqlConnection(constring);
            constring.Open();
            SqlCommand sc1 = new SqlCommand(command2, constring);
            // Adauga Date clienti in baza de date
            if (txt_nume_firma.Text.Length > 0 && txt_cui.Text.Length > 0 && txt_reg.Text.Length > 0 && txt_sediul.Text.Length > 0 && txt_cont.Text.Length > 0 && txt_banca.Text.Length > 0)
            {

                sc1.Parameters.AddWithValue("@nume_firma", txt_nume_firma.Text);
                sc1.Parameters.AddWithValue("@CUI", txt_cui.Text);
                sc1.Parameters.AddWithValue("@nr_reg_comert", txt_reg.Text);
                sc1.Parameters.AddWithValue("@sediul", txt_sediul.Text);
                sc1.Parameters.AddWithValue("@nr_telefon", txt_telefon.Text);
                sc1.Parameters.AddWithValue("@cont", txt_cont.Text);
                sc1.Parameters.AddWithValue("@banca", txt_banca.Text);
                sc1.Parameters.AddWithValue("@email", txt_email.Text);
                sc1.Parameters.AddWithValue("@pers_contact", txt_pers_contact.Text);
                sc1.Parameters.AddWithValue("@tel_pers_contact", txt_tel_pers_contact.Text);
                sc1.Parameters.AddWithValue("@email_pers_contact", txt_email_pers_contact.Text);
                sc1.ExecuteNonQuery();
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

                SqlDataAdapter MyDA = new SqlDataAdapter();
                string sqlSelectAll = "SELECT * from Date_clienti";
                MyDA.SelectCommand = new SqlCommand(sqlSelectAll, constring);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                frm1.comboBox1.DataSource = bSource;
                frm1.comboBox1.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Trebuie completate campurile marcate cu * !");
            }
            constring.Close();
        }

        private void Adaugare_clienti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.Date_clienti' table. You can move, or remove it, as needed.
            this.date_clientiTableAdapter.Fill(this.masterDataSet.Date_clienti);

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Modificare_date_clienti modif_clienti = new Modificare_date_clienti(this);
            modif_clienti.txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            modif_clienti.txt_nume_firma.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            modif_clienti.txt_cui.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            modif_clienti.txt_reg.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            modif_clienti.txt_sediul.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            modif_clienti.txt_cont.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            modif_clienti.txt_banca.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            modif_clienti.txt_telefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            modif_clienti.txt_email.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            modif_clienti.txt_pers_contact.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            modif_clienti.txt_tel_pers_contact.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            modif_clienti.txt_email_pers_contact.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            modif_clienti.ShowDialog();
        }

        private void txt_nume_firma_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(constring);
            string command1 = "SELECT * from Date_clienti where nume_firma like '%" + txt_nume_firma.Text + "%'";
           // constring.Open();
            SqlCommand sqlcmd = new SqlCommand(command1, constring);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            constring.Close();
        }
    }
}
