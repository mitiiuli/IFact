using Microsoft.Reporting.WinForms;
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
    public partial class Raport : Form
    {
        SqlConnection constring = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        //string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private string nume_firma, cui, nr_reg_comert, adresa, cont, banca, suma_totala, tip_raport, stare_facturi;
        private DateTime data_curenta = DateTime.Now;
        private DateTime data_inceput, data_sfarsit;
       
        public Raport(string Nume_firma, string Tip_raport, DateTime Data_inceput, string Stare_facturi, DateTime Data_sfarsit)
        {
            InitializeComponent();
            this.nume_firma = Nume_firma;
            this.tip_raport = Tip_raport;
            this.data_inceput = Data_inceput;
            this.stare_facturi = Stare_facturi;
            this.data_sfarsit = Data_sfarsit;
        }
        private void Raport_Load(object sender, EventArgs e)
        {
            this.documenteTableAdapter.Fill(this.masterDataSet.Documente);
            // SqlConnection connection = new SqlConnection(con);
            constring.Open();
            
            if (nume_firma != null && data_inceput != null && stare_facturi != null && data_sfarsit != null)
            {
               // MessageBox.Show(""+data_inceput+"");
                string command1 = "SELECT * from Documente where nume_firma='" + nume_firma + "' AND data_emitere BETWEEN '" + data_inceput + "'AND '"+data_sfarsit+"' AND incasata = '" + stare_facturi + "'";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameterCollection p_data_curenta = new ReportParameterCollection();
                p_data_curenta.Add(new ReportParameter("p_data_curenta", Convert.ToString(data_curenta)));
                this.reportViewer1.LocalReport.SetParameters(p_data_curenta);

                ReportParameterCollection p_tip_raport = new ReportParameterCollection();
                p_tip_raport.Add(new ReportParameter("p_tip_raport", tip_raport));
                this.reportViewer1.LocalReport.SetParameters(p_tip_raport);

                this.reportViewer1.RefreshReport();
            }
            else if ( data_inceput != null && stare_facturi != null && data_sfarsit != null)
            {
               
                string command1 = "SELECT * from Documente where incasata = '" + stare_facturi + "' AND data_emitere BETWEEN '" + data_inceput + "'AND '" + data_sfarsit + "' ";
                SqlCommand sc = new SqlCommand(command1, constring);
                sc.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameterCollection p_data_curenta = new ReportParameterCollection();
                p_data_curenta.Add(new ReportParameter("p_data_curenta", Convert.ToString(data_curenta)));
                this.reportViewer1.LocalReport.SetParameters(p_data_curenta);

                ReportParameterCollection p_tip_raport = new ReportParameterCollection();
                p_tip_raport.Add(new ReportParameter("p_tip_raport", tip_raport));
                this.reportViewer1.LocalReport.SetParameters(p_tip_raport);

                this.reportViewer1.RefreshReport();
            }

            constring.Close();
        }
    }
}
