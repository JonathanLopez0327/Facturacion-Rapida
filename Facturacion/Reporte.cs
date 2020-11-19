using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Facturacion
{
    public partial class Reporte : Form
    {
        public List<report> datospri = new List<report>();
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datospri));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception error)
            {
                MessageBox.Show("Algo Va Mal..." + error);
            }
        }
    }
}
