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
    public partial class MasConsimiFi : Form
    {
        public MasConsimiFi()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();

        private void MasConsimiFi_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.MaxConsumi();
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
    }
}
