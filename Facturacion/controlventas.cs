using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Facturacion
{
    public partial class controlventas : Form
    {
        public controlventas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuvertical.Width == 50)
            {
                pictureBox1.Image = Facturacion.Properties.Resources._3844436_hamburger_menu_more_navigation_vertical_110316;
                menuvertical.Width = 235;
                

            }
            else
            {
                pictureBox1.Image = Facturacion.Properties.Resources._3844438_hamburger_menu_more_navigation_110319;
                menuvertical.Width = 50;
                
            }
        }

        private void controlventas_Load(object sender, EventArgs e)
        {
            Form2 oooo = new Form2();
            oooo.MdiParent = this;
            oooo.Show();
        }

        //Ventana Mobible
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea Salir?", "Atencion!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Hide();
            }

            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea Volver?", "Atencion!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                this.Hide();
            }

            else
            {

            }

          
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            FacComprobanteFis oil = new FacComprobanteFis();
            oil.MdiParent = this;
            oil.Show();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            CreFiscal oil = new CreFiscal();
            oil.MdiParent = this;
            oil.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            NotaRemision nt = new NotaRemision();
            nt.MdiParent = this;
            nt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            ConsumidorFinalFaccccc csf = new ConsumidorFinalFaccccc();
            csf.MdiParent = this;
            csf.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea cerrar todo?", "Atencion!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                Form2 oooo = new Form2();
                oooo.MdiParent = this;
                oooo.Show();
            }

            else
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RegistrosFacturas rf = new RegistrosFacturas();
            rf.MdiParent = this;
            rf.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            RegimenesEspeciales re = new RegimenesEspeciales();
            re.MdiParent = this;
            re.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox7.Visible = true;
            pictureBox8.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
