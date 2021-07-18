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
    public partial class Modificare_prod : Form
    {
        string constring = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private readonly Catalog_produse catalog_p;
        private readonly IFact_Main frm1;
        public Modificare_prod(Catalog_produse c_prod, IFact_Main fr)
        {
            InitializeComponent();
            catalog_p = c_prod;
            frm1 = fr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            string command1 = "UPDATE catalog_prod SET denumire=@denumire, um=@um, pret_f_tva=@pret_f_tva, val_tva=@val_tva where id=@id";

            SqlCommand com1 = new SqlCommand(command1, con);
            com1.Parameters.AddWithValue("@id", textBox3.Text );
            com1.Parameters.AddWithValue("@denumire", textBox1.Text);
            com1.Parameters.AddWithValue("@um", textBox2.Text);
            com1.Parameters.AddWithValue("@pret_f_tva", numericUpDown1.Text);
            com1.Parameters.AddWithValue("@val_tva", comboBox1.Text);
            con.Open();
            com1.ExecuteNonQuery();

            SqlDataAdapter MyDA = new SqlDataAdapter();
            string sqlSelectAll = "SELECT * from catalog_prod";
            MyDA.SelectCommand = new SqlCommand(sqlSelectAll, con);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            catalog_p.dataGridView1.DataSource = bSource;
            frm1.comboBox4.DataSource = bSource;
            frm1.comboBox4.SelectedItem = null;
            con.Close();
            this.Close();
        }
    }
}
