using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Runtime.InteropServices;

namespace Facturacion
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        


        public SqlCeConnection conexion = new SqlCeConnection("Data Source=|DataDirectory|\\BDRGH.sdf");

        ConsultasSQL sql = new ConsultasSQL();



        private void Clientes_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.Mostradatos();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


      
                
            
        }

        private void btnselec_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            else {

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtbuscN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbuscN.Text != "") dgv.DataSource = sql.Buscar(txtbuscN.Text);

                else dgv.DataSource = sql.Mostradatos();
            }
            catch (Exception llll)
            {
                MessageBox.Show("Algo va Mal..." + llll);
            }
        }

      
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            Admcli ac = new Admcli();

            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                ac.txtid.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                ac.txtnombre.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                ac.txtrnc.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                ac.txtdirecc.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                ac.txttel.Text = dgv.CurrentRow.Cells[4].Value.ToString();
                


                ac.MdiParent = MdiParent;
                ac.Show();
                this.Close();
                }
                catch (Exception llll)
                {
                    MessageBox.Show("Algo va Mal..." + llll);
                }


            }
            else
            {
                MessageBox.Show("Debe de Seleccionar una Fila", "Atencion!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea Salir?", "Atencion!!!!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.Close();
            }

            else
            {

            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      
    }
}
