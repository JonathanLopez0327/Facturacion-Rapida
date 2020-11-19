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
    public partial class maxregimenesesp : Form
    {
        public maxregimenesesp()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea Salir?", "Atencion!!!!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.Close();
            }

            else
            {

            }
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

        private void maxregimenesesp_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.Maxregi();
            dgv2.DataSource = sql.maxfecha();
        }
    }
}
