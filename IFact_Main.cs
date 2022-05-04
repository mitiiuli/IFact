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
using Microsoft.Reporting.WinForms;
using System.Configuration;

namespace Program_Facturat
{
    public partial class IFact_Main : Form
    {
       // string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
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
            // TODO: This line of code loads data into the 'masterDataSet.tipuri_incasari' table. You can move, or remove it, as needed.
            this.tipuri_incasariTableAdapter.Fill(this.masterDataSet.tipuri_incasari);
            // TODO: This line of code loads data into the 'masterDataSet.catalog_prod' table. You can move, or remove it, as needed.
            this.catalog_prodTableAdapter.Fill(this.masterDataSet.catalog_prod);
            // TODO: This line of code loads data into the 'masterDataSet.Date_clienti' table. You can move, or remove it, as needed.
            this.date_clientiTableAdapter.Fill(this.masterDataSet.Date_clienti);
            // TODO: This line of code loads data into the 'masterDataSet.date_firma_clienti' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'masterDataSet.Date_firma' table. You can move, or remove it, as needed.
            this.date_firmaTableAdapter.Fill(this.masterDataSet.Date_firma);
            comboBox1.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txt_total_valoare.Text = "0.00";
            txt_total_valoare_tva.Text = "0.00";
            txt_total_de_plata.Text = "0.00";
            textBox1.Text = Properties.Settings.Default.nr_doc.ToString();
            dateTimePicker2.MinDate = DateTime.Today;
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Catalog_produse catalog_prod = new Catalog_produse(this);
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
                // SqlConnection connection = new SqlConnection(con);
                constring.Open();
                string command1 = "SELECT * from Date_clienti where nume_firma = '" + comboBox1.Text + "'";
                SqlCommand sc = new SqlCommand(command1, constring);
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
                constring.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adaugare_clienti add_clients = new Adaugare_clienti(this);
            add_clients.ShowDialog();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            decimal t_val_fara_tva = 0;
            decimal total_val_tva = 0;
            decimal subtotal_de_scazut = 0;
           
            if (comboBox1.SelectedIndex > -1)
            {
               
                string command2 = "INSERT into Documente( nr_doc, data_emitere, data_scadenta, suma_totala, nume_firma, CUI, nr_reg_comert, sediul, cont, banca, incasata) VALUES(@nr_doc, @data_emitere, @data_scadenta, @suma_totala, @nume_firma, @CUI, @nr_reg_comert, @sediul, @cont, @banca, @incasata)";
                //SqlConnection conection = new SqlConnection(con);
                constring.Open();
                SqlCommand sc1 = new SqlCommand(command2, constring);
                sc1.Parameters.AddWithValue("@nr_doc", textBox1.Text);
                sc1.Parameters.AddWithValue("@data_emitere", dateTimePicker1.Value.Date.ToShortDateString());
                sc1.Parameters.AddWithValue("@data_scadenta", dateTimePicker2.Value.Date.ToShortDateString());
                sc1.Parameters.AddWithValue("@suma_totala", Convert.ToDecimal( txt_total_de_plata.Text));
                sc1.Parameters.AddWithValue("@nume_firma", comboBox1.Text);
                sc1.Parameters.AddWithValue("@CUI", label27.Text);
                sc1.Parameters.AddWithValue("@nr_reg_comert", label28.Text);
                sc1.Parameters.AddWithValue("@sediul", label29.Text);
                sc1.Parameters.AddWithValue("@cont", label30.Text);
                sc1.Parameters.AddWithValue("@banca", label31.Text);
                sc1.Parameters.AddWithValue("@incasata", comboBox3.Text);
                sc1.ExecuteNonQuery();
                constring.Close();
                Factura fact = new Factura(label27.Text, label28.Text, label29.Text, label30.Text, label31.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Text, textBox1.Text, textBox1.Text, txt_total_valoare.Text, txt_total_valoare_tva.Text, txt_total_de_plata.Text);
                fact.ShowDialog();
                do
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            t_val_fara_tva = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[5].Value);
                            total_val_tva = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[6].Value);
                            t_val = Math.Round(t_val - t_val_fara_tva, 2);
                            t_val_tva = Math.Round(t_val_tva - total_val_tva, 2);
                            subtotal_de_scazut = Math.Round(t_val_fara_tva + total_val_tva, 2);
                            t_de_plata = Math.Round(t_de_plata - subtotal_de_scazut, 2);
                            txt_total_valoare.Text = t_val.ToString();
                            txt_total_valoare_tva.Text = t_val_tva.ToString();
                            txt_total_de_plata.Text = t_de_plata.ToString();
                            dataGridView1.Rows.Remove(row);
                        }
                        catch (Exception) { }
                    }
                } while (dataGridView1.Rows.Count > 1);

                Properties.Settings.Default.nr_doc++;
                textBox1.Text = Properties.Settings.Default.nr_doc.ToString();
                Properties.Settings.Default.Save();
              
                comboBox3.SelectedItem = null;
                comboBox2.SelectedItem = null;
                comboBox1.SelectedItem = null;
                dateTimePicker2.Value = DateTime.Today;
                
            }
            else
            {
                MessageBox.Show("Trebuie sa selectezi un client !");
            }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                txt_um.Text = null;
                txt_pret_fara_tva.Text = null;
                txt_cota_tva.Text = null;
               
            }
            else
            {
                //SqlConnection connection = new SqlConnection(con);
                constring.Open();
                string command1 = "SELECT * from catalog_prod where denumire = '" + comboBox4.Text + "'";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txt_um.Text = dr["um"].ToString();
                    txt_pret_fara_tva.Text = dr["pret_f_tva"].ToString();
                    txt_cota_tva.Text = dr["val_tva"].ToString();
                    
                }
                constring.Close();
            }
            
        }
        
        decimal t_val;
        decimal t_val_tva;
        decimal t_de_plata;
        
        private void button9_Click(object sender, EventArgs e)
        {
            if (txt_cantitate.Value > 0 && comboBox4.SelectedItem != null)
            {
                int i = dataGridView1.Rows.Add();
                decimal subtotal_val = 0;
                decimal subtotal_val_tva = 0;
                decimal subtotal_de_plata = 0;
                decimal val_fara_tva = 0;
                decimal cota_tva = 0;
                decimal cant = Convert.ToDecimal( txt_cantitate.Value);
                decimal pret = Convert.ToDecimal(txt_pret_fara_tva.Text);
                cota_tva = Convert.ToDecimal(txt_cota_tva.Text);
                val_fara_tva = Math.Round(cant * pret, 2);
                decimal val_tva = Math.Round(val_fara_tva * cota_tva / 100, 2);
                dataGridView1.Rows[i].Cells[0].Value = dataGridView1.Rows.Count-1;
                dataGridView1.Rows[i].Cells[1].Value = comboBox4.Text.ToString();
                dataGridView1.Rows[i].Cells[2].Value = txt_um.Text;
                dataGridView1.Rows[i].Cells[3].Value = Math.Round( cant,2);
                dataGridView1.Rows[i].Cells[4].Value = txt_pret_fara_tva.Text;
                dataGridView1.Rows[i].Cells[5].Value = Math.Round( val_fara_tva, 2);
                dataGridView1.Rows[i].Cells[6].Value = Math.Round(val_tva, 2);
                dataGridView1.Rows[i].Cells[7].Value = Math.Round(cota_tva, 2);
                dataGridView1.Rows[i].Cells[8].Value = "Sterge";
                comboBox4.SelectedItem = null;
               
                subtotal_val = val_fara_tva;
                subtotal_val_tva = val_tva;
                t_val += subtotal_val;
                t_val_tva += subtotal_val_tva;
                txt_total_valoare.Text = t_val.ToString();
                txt_total_valoare_tva.Text = t_val_tva.ToString();
                subtotal_de_plata = Math.Round(subtotal_val + subtotal_val_tva, 2);
                t_de_plata = Math.Round(t_de_plata + subtotal_de_plata, 2);
                txt_total_de_plata.Text = t_de_plata.ToString();


                //SqlConnection connection = new SqlConnection(con);
                constring.Open();
                string command1 = "INSERT into fact_detalii(nr_doc, nr_crt, denumire, um, cant, pret_f_tva, valoare, val_tva, cota_tva ) VALUES( @nr_doc, @nr_crt, @denumire, @um, @cant, @pret_f_tva, @valoare, @val_tva, @cota_tva)";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.Parameters.AddWithValue("@nr_doc", textBox1.Text);
                sc.Parameters.AddWithValue("@nr_crt", dataGridView1.Rows[i].Cells[0].Value);
                sc.Parameters.AddWithValue("@denumire", dataGridView1.Rows[i].Cells[1].Value);
                sc.Parameters.AddWithValue("@um", dataGridView1.Rows[i].Cells[2].Value);
                sc.Parameters.AddWithValue("@cant", Math.Round(cant, 2));
                sc.Parameters.AddWithValue("@pret_f_tva", dataGridView1.Rows[i].Cells[4].Value);
                sc.Parameters.AddWithValue("@valoare", Math.Round(val_fara_tva, 2));
                sc.Parameters.AddWithValue("@val_tva", dataGridView1.Rows[i].Cells[6].Value);
                sc.Parameters.AddWithValue("@cota_tva", Math.Round( cota_tva,2));
                sc.ExecuteNonQuery();
                constring.Close();
                txt_um.Clear();
                txt_cantitate.Value = 0;
                txt_pret_fara_tva.Clear();
                txt_cota_tva.Clear();
                
            }
            else
            {
                MessageBox.Show("Trebuie sa selectezi un produs/serviciu si cantitatea sa fie mai mare decat 0 !");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal t_val_fara_tva = 0;
            decimal total_val_tva = 0;
            decimal subtotal_de_scazut = 0;
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Column9.Index)
                {
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    
                    t_val_fara_tva = Convert.ToDecimal( dataGridView1.Rows[rowindex].Cells[5].Value);
                    total_val_tva = Convert.ToDecimal(dataGridView1.Rows[rowindex].Cells[6].Value);
                    t_val = Math.Round(t_val - t_val_fara_tva, 2);
                    t_val_tva = Math.Round(t_val_tva - total_val_tva, 2);
                    subtotal_de_scazut = Math.Round( t_val_fara_tva + total_val_tva, 2);
                    t_de_plata = Math.Round(t_de_plata - subtotal_de_scazut, 2);
                    txt_total_valoare.Text = t_val.ToString();
                    txt_total_valoare_tva.Text = t_val_tva.ToString();
                    txt_total_de_plata.Text = t_de_plata.ToString();
                    sterge_produse_din_bazadate(rowindex);
                    dataGridView1.Rows.RemoveAt(rowindex);
                    
                }
                
            }
        }

        private void IFact_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                MessageBox.Show("Ai un document nefinalizat. Toate produsele/serviciile se vor anula automat !");
                sterge_factura_nefinalizata();
            }

        }
        private void sterge_factura_nefinalizata()
        {
           // SqlConnection constr = new SqlConnection(con);
            string command1 = "DELETE from fact_detalii where nr_doc=@nr_doc";
            SqlCommand com1 = new SqlCommand(command1, constring);
            com1.Parameters.AddWithValue("@nr_doc", textBox1.Text);
            constring.Open();
            com1.ExecuteNonQuery();
            constring.Close();
                
        }
        private void sterge_produse_din_bazadate(int index)
        {
            //SqlConnection constr = new SqlConnection(con);
            string command1 = "DELETE from fact_detalii where nr_crt=@nr_crt";
            SqlCommand com1 = new SqlCommand(command1, constring);
            com1.Parameters.AddWithValue("@nr_crt", dataGridView1.Rows[index].Cells[0].Value);
            constring.Open();
            com1.ExecuteNonQuery();
            constring.Close();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 3 || e.ColumnIndex == 7)
            {
                e.CellStyle.Format = "N2";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rapoarte rap = new Rapoarte();
            rap.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Incasari incasari = new Incasari();
            incasari.ShowDialog();
        }

        
    }
}
