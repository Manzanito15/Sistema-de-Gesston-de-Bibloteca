using Capa_Negocios;
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

namespace Gestion_Bibloteca
{
    public partial class FormReportePrestamos : Form
    {
        public int ID_Prestamo = 0;
        public FormReportePrestamos()
        {
            InitializeComponent();
        }

        private void FormReportePrestamos_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            try
            {
                if (ID_Prestamo == 0)
                {
                    MessageBox.Show("No hay préstamo seleccionado");
                    return;
                }

                // 🔥 CREAR Y LLENAR DT
                N_Prestamos obj = new N_Prestamos();
                DataTable dt = obj.ReportePrestamo(ID_Prestamo);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar");
                    return;
                }

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.ReportEmbeddedResource = "Gestion_Bibloteca.Report1.rdlc";

                // 🔥 USAR DT (YA EXISTE)
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
