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
    public partial class Rapoarte : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        //string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private string tip_raport = null, stare_facturi, nume_firma = null;
        private DateTime data_inceput, data_sfarsit;
        public Rapoarte()
        {
            InitializeComponent();
        }

        private void Rapoarte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.Date_clienti' table. You can move, or remove it, as needed.
            this.date_clientiTableAdapter.Fill(this.masterDataSet.Date_clienti);
            comboBox1.SelectedItem = null;
            comboBox1.Enabled = false;
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                label5.Visible = false;
                comboBox2.Visible = false;
                label2.Text = radioButton3.Text;
                checkBox6.Checked = false;

                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                tip_raport = radioButton3.Text;
            }
            else
            {
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                label5.Visible = true;
                comboBox2.Visible = true;
                label2.Text = null;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label5.Visible = false;
                comboBox2.Visible = false;
                label2.Text = radioButton1.Text;
                checkBox6.Checked = false;
                tip_raport = radioButton1.Text;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                label5.Visible = true;
                comboBox2.Visible = true;
                label2.Text = null;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
              
            }
        }
       

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateTimePicker2.Enabled = true;

            }
            else
            {
                dateTimePicker2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                label2.Text = radioButton2.Text;
                checkBox6.Checked = false;
                tip_raport = radioButton2.Text;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                label2.Text = null;
            }
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                label2.Text = radioButton4.Text;
                label5.Visible = false;
                comboBox2.Visible = false;
                checkBox6.Checked = false;
                tip_raport = radioButton4.Text;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;

            }
            else
            {
                label5.Visible = true;
                comboBox2.Visible = true;
                label2.Text = null;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                comboBox1.Enabled = true;
                nume_firma = comboBox1.Text;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = null;
                nume_firma = null;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                stare_facturi = comboBox2.Text;
            }
            else
            {
                stare_facturi = null;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            data_sfarsit = dateTimePicker2.Value.Date;
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           // string d_inceput = dateTimePicker1.Value.Date.ToShortDateString();
            //data_inceput = DateTime.Parse(d_inceput).Date;
            //data_inceput = DateTime.Now.Date;
            data_inceput = dateTimePicker1.Value.Date;
            //data_inceput = Convert.ToDateTime(d_inceput);
            //data_inceput.Date.AddHours(12);
           // MessageBox.Show("" + data_inceput + "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Raport raport = new Raport(nume_firma, tip_raport, data_inceput, stare_facturi, data_sfarsit);
            raport.ShowDialog();
           
        }
    }
}
