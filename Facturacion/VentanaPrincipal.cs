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
using System.Data.SqlClient;


namespace Facturacion
{
    public partial class VentanaPrincipal : Form
    {
        

        public VentanaPrincipal()
        {
            InitializeComponent();
        }
        ConsultasSQL sql = new ConsultasSQL();

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");

        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ShowNewForm(object sender, EventArgs e)
        {
        

          
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void administrarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void comprobanteGubernamentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comprobante con = new comprobante();
            con.MdiParent = this;
            con.Show();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuvertical.Width == 50)
            {
                pictureBox1.Image = Facturacion.Properties.Resources._3844436_hamburger_menu_more_navigation_vertical_110316;
                menuvertical.Width = 270;
                panel2.Height = 100;

            }
            else
            {
                pictureBox1.Image = Facturacion.Properties.Resources._3844438_hamburger_menu_more_navigation_110319;
                menuvertical.Width = 50;
                panel2.Height = 0;
            }
            
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
      
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 oo = new Form3();

            oo.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            

        }

        

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            Form1 fond = new Form1();
            fond.MdiParent = this;
            fond.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdmPro pro = new AdmPro();
            pro.MdiParent = this;
            pro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admcli cli = new Admcli();
            cli.MdiParent = this;
            cli.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Productos adpro = new Productos();
            adpro.MdiParent = this;
            adpro.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clientes adcli = new Clientes();
            adcli.MdiParent = this;
            adcli.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea cerrar todo?", "Atencion!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                Form1 fond = new Form1();
                fond.MdiParent = this;
                fond.Show();
            }

            else
            {

            }

            
        }

        private void btngees3_Click(object sender, EventArgs e)
        {
            controlventas po = new controlventas();
            po.Show();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AboutBox1 acer = new AboutBox1();
            acer.Show();
        }

        private void pictureBox6_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
           
               

         
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnadmin_MouseEnter(object sender, EventArgs e)
        {
            
        
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            

            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
               
            
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick_1(object sender, EventArgs e)
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

       
    }
}
