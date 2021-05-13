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
    public partial class Catalog_produse : Form
    {
        string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        
        public Catalog_produse()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string command1 = "INSERT into catalog_prod( denumire, um, pret_f_tva, val_tva ) VALUES( @denumire, @um, @pret_f_tva, @val_tva)";
            SqlCommand sc = new SqlCommand(command1, connection);
            sc.Parameters.AddWithValue("@denumire", textBox1.Text);
            sc.Parameters.AddWithValue("@um", textBox2.Text);
            sc.Parameters.AddWithValue("@pret_f_tva", numericUpDown1.Value.ToString());
            sc.Parameters.AddWithValue("@val_tva", comboBox1.SelectedItem.ToString());
            sc.ExecuteNonQuery();
           
            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = "SELECT * from catalog_prod";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            connection.Close();
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.ResetText();
            numericUpDown1.Value = 0;
            comboBox1.ResetText();
        }

        private void Catalog_produse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.catalog_prod' table. You can move, or remove it, as needed.
            this.catalog_prodTableAdapter.Fill(this.masterDataSet.catalog_prod);

        }
    }
}
