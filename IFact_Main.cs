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
    public partial class IFact_Main : Form
    {
        string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        public IFact_Main()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_Societate update_societate = new Update_Societate(this);
            update_societate.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.date_firma_clienti' table. You can move, or remove it, as needed.
            this.date_firma_clientiTableAdapter.Fill(this.masterDataSet.date_firma_clienti);
            // TODO: This line of code loads data into the 'masterDataSet.Date_firma' table. You can move, or remove it, as needed.
            this.date_firmaTableAdapter.Fill(this.masterDataSet.Date_firma);
            comboBox1.SelectedItem = null;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Catalog_produse catalog_prod = new Catalog_produse();
            catalog_prod.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                label27.Text = null;
                label28.Text = null;
                label29.Text = null;
                label30.Text = null;
                label31.Text = null;
            }
            else
            {
                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                string command1 = "SELECT * from date_firma_clienti where nume_firma = '" + comboBox1.Text + "'";
                SqlCommand sc = new SqlCommand(command1, connection);
                sc.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label27.Text = dr["CUI"].ToString();
                    label28.Text = dr["nr_reg_comert"].ToString();
                    label29.Text = dr["sediul"].ToString();
                    label30.Text = dr["cont"].ToString();
                    label31.Text = dr["banca"].ToString();
                }
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adaugare_clienti add_clients = new Adaugare_clienti();
            add_clients.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                Factura fact = new Factura(label27.Text, label28.Text, label29.Text, label30.Text, label31.Text, comboBox1.Text);
                fact.ShowDialog();
            }
            else
            {
                MessageBox.Show("Trebuie sa selectezi un client !");
            }
        }
    }
}
