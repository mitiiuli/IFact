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
    public partial class Catalog_produse : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        //string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private readonly IFact_Main frm1;
        public Catalog_produse(IFact_Main fr)
        {
            InitializeComponent();
            frm1 = fr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && numericUpDown1.Value > 0 && comboBox1.SelectedItem != null)
            {
                //SqlConnection connection = new SqlConnection(con);
                constring.Open();
                string command1 = "INSERT into catalog_prod( denumire, um, pret_f_tva, val_tva, sterge ) VALUES( @denumire, @um, @pret_f_tva, @val_tva, @sterge)";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.Parameters.AddWithValue("@denumire", textBox1.Text);
                sc.Parameters.AddWithValue("@um", textBox2.Text);
                sc.Parameters.AddWithValue("@pret_f_tva", numericUpDown1.Value.ToString());
                sc.Parameters.AddWithValue("@val_tva", comboBox1.SelectedItem.ToString());
                sc.Parameters.AddWithValue("@sterge", "Sterge");
                sc.ExecuteNonQuery();

                SqlDataAdapter MyDA = new SqlDataAdapter();
                string sqlSelectAll = "SELECT * from catalog_prod";
                MyDA.SelectCommand = new SqlCommand(sqlSelectAll, constring);
                DataTable table = new DataTable();
                MyDA.Fill(table);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
                frm1.comboBox4.DataSource = bSource;
                frm1.comboBox4.SelectedItem = null;

                textBox1.Clear();
                textBox2.Clear();
                numericUpDown1.ResetText();
                numericUpDown1.Value = 0;
                comboBox1.ResetText();
                constring.Close();
            }
            else
            {
                MessageBox.Show("Trebuie sa completezi toate campurile marcate cu *");
            }
        }

        private void Catalog_produse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.catalog_prod' table. You can move, or remove it, as needed.
            this.catalog_prodTableAdapter.Fill(this.masterDataSet.catalog_prod);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.sterge.Index)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                   // SqlConnection constr = new SqlConnection(con);
                    string command1 = "DELETE from catalog_prod where id=@id";
                    SqlCommand com1 = new SqlCommand(command1, constring);
                    com1.Parameters.AddWithValue("@id", dataGridView1.Rows[index].Cells[0].Value);
                    constring.Open();
                    com1.ExecuteNonQuery();
                    constring.Close();

                    SqlDataAdapter MyDA = new SqlDataAdapter();
                    string sqlSelectAll = "SELECT * from catalog_prod";
                    MyDA.SelectCommand = new SqlCommand(sqlSelectAll, constring);
                    DataTable table = new DataTable();
                    MyDA.Fill(table);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;
                    dataGridView1.DataSource = bSource;
                    frm1.comboBox4.DataSource = bSource;
                    frm1.comboBox4.SelectedItem = null; 
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(con);
            string command1 = "SELECT * from catalog_prod where denumire like '%" + textBox1.Text + "%'";
           // constring.Open();
            SqlCommand sqlcmd = new SqlCommand(command1, constring);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            constring.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Modificare_prod modificare_produs = new Modificare_prod(this, frm1);
            modificare_produs.textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            modificare_produs.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            modificare_produs.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            modificare_produs.numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            modificare_produs.comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            modificare_produs.ShowDialog();
        }
    }
}
