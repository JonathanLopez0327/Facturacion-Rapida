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
    public partial class NOTTTT : Form
    {
        public List<report> nou = new List<report>();
        public NOTTTT()
        {
            InitializeComponent();
        }

        private void NOTTTT_Load(object sender, EventArgs e)
        {

            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet7", nou));
                this.reportViewer1.RefreshReport();

            }
            catch (Exception error)
            {
                MessageBox.Show("Algo Va Mal..." + error);
            }
        }
    }
}
