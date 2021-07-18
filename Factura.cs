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
        private string cui, nr_reg_comert, adresa, cont, banca, nume_firma_client, tip_doc, nr_doc, data_emitere, nr_document, valoare, val_tva, total_de_plata;
        
        public Factura(string CUI, string Nr_Reg_Comert, string Adresa, string Cont, string Banca, string Nume_Firma_Client, string Tip_doc, string Data_emitere, string Nr_doc, string Nr_document, string Valoare, string Val_tva, string Total_de_plata)
        {
            InitializeComponent();
            this.cui = CUI;
            this.nr_reg_comert = Nr_Reg_Comert;
            this.adresa = Adresa;
            this.cont = Cont;
            this.banca = Banca;
            this.nume_firma_client = Nume_Firma_Client;

            this.tip_doc = Tip_doc;
            this.data_emitere = Data_emitere;
            this.nr_doc = Nr_doc;
            this.nr_document = Nr_document;

            this.valoare = Valoare;
            this.val_tva = Val_tva;
            this.total_de_plata = Total_de_plata;
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string command1 = "SELECT * from Date_firma ";
            string command2 = "SELECT * from fact_detalii where nr_doc = '"+nr_document+"'";
            SqlCommand sc = new SqlCommand(command1, connection);
            SqlCommand sc2 = new SqlCommand(command2, connection);
            SqlDataAdapter da = new SqlDataAdapter(sc);
            SqlDataAdapter da2 = new SqlDataAdapter(sc2);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            da.Fill(dt);
            da2.Fill(dt2);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);

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

            ReportParameterCollection p_tip_doc = new ReportParameterCollection();
            p_tip_doc.Add(new ReportParameter("tip_doc", tip_doc));
            this.reportViewer1.LocalReport.SetParameters(p_tip_doc);

            ReportParameterCollection p_data_emitere = new ReportParameterCollection();
            p_data_emitere.Add(new ReportParameter("data_emitere", data_emitere));
            this.reportViewer1.LocalReport.SetParameters(p_data_emitere);

            ReportParameterCollection p_nr_doc = new ReportParameterCollection();
            p_nr_doc.Add(new ReportParameter("nr_doc", nr_doc));
            this.reportViewer1.LocalReport.SetParameters(p_nr_doc);

            ReportParameterCollection p_valoare = new ReportParameterCollection();
            p_valoare.Add(new ReportParameter("valoare", valoare));
            this.reportViewer1.LocalReport.SetParameters(p_valoare);

            ReportParameterCollection p_valoare_tva = new ReportParameterCollection();
            p_valoare_tva.Add(new ReportParameter("val_tva", val_tva));
            this.reportViewer1.LocalReport.SetParameters(p_valoare_tva);

            ReportParameterCollection p_total_de_plata = new ReportParameterCollection();
            p_total_de_plata.Add(new ReportParameter("total_de_plata", total_de_plata));
            this.reportViewer1.LocalReport.SetParameters(p_total_de_plata);

            this.reportViewer1.RefreshReport();
        }
    }
}
