using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion
{
    public partial class Massx : Form
    {
        public Massx()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();

        private void Massx_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.maxcomprobante();
            dgv2.DataSource = sql.maxfecha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
