using Microsoft.Reporting.WinForms;
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
    public partial class Factura : Form
    {
        string con = "Data Source=DESKTOP-7HMM0LA;Initial Catalog=master;Integrated Security=True";
        private string cui, nr_reg_comert, adresa, cont, banca, nume_firma_client;
        
        public Factura(string CUI, string Nr_Reg_Comert, string Adresa, string Cont, string Banca, string Nume_Firma_Client)
        {
            InitializeComponent();
            this.cui = CUI;
            this.nr_reg_comert = Nr_Reg_Comert;
            this.adresa = Adresa;
            this.cont = Cont;
            this.banca = Banca;
            this.nume_firma_client = Nume_Firma_Client;
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string command1 = "SELECT * from Date_firma ";
            SqlCommand sc = new SqlCommand(command1, connection);
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.ReportPath = @"C:\Users\Iulian\source\repos\Program_Facturat\fact.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameterCollection p_nume_firma_client = new ReportParameterCollection();
            p_nume_firma_client.Add(new ReportParameter("nume_firma_client", nume_firma_client));
            this.reportViewer1.LocalReport.SetParameters(p_nume_firma_client);

            ReportParameterCollection p_cui = new ReportParameterCollection();
            p_cui.Add(new ReportParameter("cui", cui));
            this.reportViewer1.LocalReport.SetParameters(p_cui);

            ReportParameterCollection p_nr_reg_com = new ReportParameterCollection();
            p_nr_reg_com.Add(new ReportParameter("nr_reg_com", nr_reg_comert));
            this.reportViewer1.LocalReport.SetParameters(p_nr_reg_com);

            ReportParameterCollection p_adresa = new ReportParameterCollection();
            p_adresa.Add(new ReportParameter("adresa", adresa));
            this.reportViewer1.LocalReport.SetParameters(p_adresa);

            ReportParameterCollection p_cont = new ReportParameterCollection();
            p_cont.Add(new ReportParameter("cont", cont));
            this.reportViewer1.LocalReport.SetParameters(p_cont);

            ReportParameterCollection p_banca = new ReportParameterCollection();
            p_banca.Add(new ReportParameter("banca", banca));
            this.reportViewer1.LocalReport.SetParameters(p_banca);

            this.reportViewer1.RefreshReport();
        }
    }
}
