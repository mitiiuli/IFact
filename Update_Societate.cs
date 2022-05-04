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
    public partial class Update_Societate : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
       // string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private readonly IFact_Main frm2;
        public Update_Societate(IFact_Main fr2)
        {
            InitializeComponent();
            frm2 = fr2;
        }

        private void Update_Societate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.Date_firma' table. You can move, or remove it, as needed.
            this.date_firmaTableAdapter.Fill(this.masterDataSet.Date_firma);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(con);
            constring.Open();
            string command1 = "UPDATE Date_firma SET nume_firma=@nume_firma , CUI=@CUI, nr_reg_comert=@nr_reg_comert, sediul=@sediul, nr_telefon=@nr_telefon, cont=@cont, banca=@banca, email=@email ";
            SqlCommand sc = new SqlCommand(command1, constring);
            sc.Parameters.AddWithValue("@nume_firma", textBox1.Text);
            sc.Parameters.AddWithValue("@CUI", textBox2.Text);
            sc.Parameters.AddWithValue("@nr_reg_comert",textBox3.Text );
            sc.Parameters.AddWithValue("@sediul", textBox4.Text);
            sc.Parameters.AddWithValue("@nr_telefon", textBox7.Text);
            sc.Parameters.AddWithValue("@cont", textBox5.Text);
            sc.Parameters.AddWithValue("@banca", textBox6.Text);
            sc.Parameters.AddWithValue("@email", textBox8.Text);
            sc.ExecuteNonQuery();
            frm2.label11.Text = textBox1.Text;
            frm2.label17.Text = textBox2.Text;
            frm2.label18.Text = textBox3.Text;
            frm2.label19.Text = textBox4.Text;
            frm2.label20.Text = textBox5.Text;
            frm2.label21.Text = textBox6.Text;
            constring.Close();
        }
    }
}
