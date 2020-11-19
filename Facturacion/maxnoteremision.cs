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
    public partial class maxnoteremision : Form
    {
        public maxnoteremision()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();

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
        }

        private void maxnoteremision_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.maxnote();
        }
    }
}
