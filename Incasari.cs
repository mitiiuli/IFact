using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Facturat
{
    public partial class Incasari : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        //string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        public Incasari()
        {
            InitializeComponent();
        }
        decimal suma_incasata = 0;
        private void Incasari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.Documente' table. You can move, or remove it, as needed.
            this.documenteTableAdapter.Fill(this.masterDataSet.Documente);
            // TODO: This line of code loads data into the 'masterDataSet.tipuri_incasari' table. You can move, or remove it, as needed.
            this.tipuri_incasariTableAdapter.Fill(this.masterDataSet.tipuri_incasari);
            // TODO: This line of code loads data into the 'masterDataSet.Date_clienti' table. You can move, or remove it, as needed.
            this.date_clientiTableAdapter.Fill(this.masterDataSet.Date_clienti);
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            textBox1.Text = Properties.Settings.Default.nr_incasare.ToString();
           
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal s_incasata = 0;
            if (comboBox1.SelectedItem == null)
            {
                textBox3.Text = null;
            }
            else
            {
                //SqlConnection connection = new SqlConnection(con);
                constring.Open();

                string command1 = "SELECT * from Date_clienti where nume_firma = '" + comboBox1.Text + "'";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(dt);
                DataRow dr = dt.Rows[0];
                textBox3.Text = dr["CUI"].ToString();

                string command2 = "SELECT * from Documente where nume_firma = '" + comboBox1.Text + "' and CUI = '" + textBox3.Text + "' ORDER BY data_scadenta ASC ";
                SqlCommand sc1 = new SqlCommand(command2, constring);
                sc1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(sc1);
                da1.Fill(dt1);

                suma_incasata += Convert.ToDecimal(numericUpDown1.Text);
               
                dataGridView1.Rows.Clear();
                foreach (DataRow dr1 in dt1.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr1["nr_doc"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr1["nume_firma"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr1["CUI"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr1["suma_totala"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr1["data_scadenta"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr1["incasata_anterior"].ToString();
                    s_incasata = Convert.ToDecimal(dr1["suma_totala"].ToString());
                    if (s_incasata == 0)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[0];
                        dataGridView1.Rows.Remove(dgvDelRow);
                    }
                }
                suma_incasata = Convert.ToDecimal(dataGridView1.Rows[0].Cells[5].Value);
                constring.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection conection = new SqlConnection(con);
            double total_rest_plata = 0;
            double s_incasata = 0;
            decimal rest_de_plata_verific = 0;
            double rest_plata = 0;
            decimal suma_de_incasat = 0;
            rest_de_plata_verific = Convert.ToDecimal(dataGridView1.Rows[0].Cells[3].Value);
            suma_de_incasat = numericUpDown1.Value;
            
            if (rest_de_plata_verific - suma_de_incasat >= 0)
            {
                suma_incasata += Convert.ToDecimal(numericUpDown1.Text);
                dataGridView1.Rows[0].Cells[6].Value = numericUpDown1.Value;
                dataGridView1.Rows[0].Cells[5].Value = suma_incasata;
                s_incasata = Convert.ToDouble(dataGridView1.Rows[0].Cells[6].Value);
                rest_plata = Math.Round(Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value), 2);
                total_rest_plata = Math.Round(rest_plata - s_incasata, 2);
                dataGridView1.Rows[0].Cells[3].Value = total_rest_plata;
               
                string command2 = "INSERT into incasari( nr_incasare, client, cui, data, metoda, suma, incasat_anterior) VALUES(@nr_incasare, @client, @cui, @data, @metoda, @suma, @incasat_anterior)";

                constring.Open();
                SqlCommand sc1 = new SqlCommand(command2, constring);
                sc1.Parameters.AddWithValue("@nr_incasare", textBox1.Text);
                sc1.Parameters.AddWithValue("@client", comboBox1.Text);
                sc1.Parameters.AddWithValue("@cui", textBox3.Text);
                sc1.Parameters.AddWithValue("@data", dateTimePicker1.Value.Date);
                sc1.Parameters.AddWithValue("@metoda", comboBox2.Text);
                sc1.Parameters.AddWithValue("@suma", s_incasata);
                sc1.Parameters.AddWithValue("@incasat_anterior", suma_incasata);
                sc1.ExecuteNonQuery();

                int id_fact = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                string command4 = "UPDATE Documente SET suma_totala = @suma_totala, incasata_anterior = @incasata_anterior WHERE CUI = '" + textBox3.Text + "' and nr_doc = '" + id_fact + "' ";
                SqlCommand sc4 = new SqlCommand(command4, constring);
                sc4.Parameters.AddWithValue("@suma_totala", total_rest_plata.ToString());
                sc4.Parameters.AddWithValue("@incasata_anterior", suma_incasata.ToString());
                sc4.ExecuteNonQuery();
                
                if (total_rest_plata==0)
                {
                    DataGridViewRow dgvDelRow = dataGridView1.Rows[0];
                    dataGridView1.Rows.Remove(dgvDelRow);
                }
                constring.Close();

                Properties.Settings.Default.nr_incasare++;
                textBox1.Text = Properties.Settings.Default.nr_incasare.ToString();
                Properties.Settings.Default.Save();

                numericUpDown1.Value = 0;
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            } 
            else
            {
                MessageBox.Show("Valoarea incasata depaseste restul de plata pe factura curenta !");
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // SqlConnection connection = new SqlConnection(con);
            constring.Open();

            int nr_document = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            string command1 = "SELECT * from fact_detalii where nr_doc = '" + nr_document + "'";
            SqlCommand sc = new SqlCommand(command1, constring);
            sc.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sc);
            da.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow dr1 in dt.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dr1["nr_doc"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = dr1["denumire"].ToString();
                dataGridView2.Rows[i].Cells[2].Value = dr1["um"].ToString();
                dataGridView2.Rows[i].Cells[3].Value = dr1["cant"].ToString();
                dataGridView2.Rows[i].Cells[4].Value = dr1["pret_f_tva"].ToString();
                dataGridView2.Rows[i].Cells[5].Value = dr1["valoare"].ToString();
                dataGridView2.Rows[i].Cells[6].Value = dr1["val_tva"].ToString();
                dataGridView2.Rows[i].Cells[7].Value = dr1["cota_tva"].ToString();
            }
            constring.Close();

        }
    }
}
