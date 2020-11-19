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

namespace Facturacion
{
    public partial class MaxxCreditoFiscal : Form
    {
        public MaxxCreditoFiscal()
        {
            InitializeComponent();
        }
        ConsultasSQL sql = new ConsultasSQL();

        private void MaxxCreditoFiscal_Load(object sender, EventArgs e)
        {
            data.DataSource = sql.MaxCreditoFi();
            dgv2.DataSource = sql.maxfecha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();

            }

            if (dgv2.Rows.Count == 0)
            {
                return;
            }
            else
            {

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
