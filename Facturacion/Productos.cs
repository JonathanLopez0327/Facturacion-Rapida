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
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Facturacion
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        
        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");

        ConsultasSQL sql = new ConsultasSQL();

        public string F_Corta;

        //-----------------------------------------------------------------------------

        DateTime ahora = DateTime.Now;
        DateTime final;
        string[] fecha = new string[3];

        //-------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            F_Corta = DateTime.Now.ToShortDateString();
            label5.Text = DateTime.Now.ToLongDateString();
        }
       
        private void Productos_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.produc();

            foreach (DataGridViewRow Fila in dgv.Rows)
            {

                DateTime Fecha1 = DateTime.Now;
                DateTime Fecha2 = Convert.ToDateTime(Fila.Cells[10].Value.ToString());

                TimeSpan Diferencia;
                if (Fecha2 > Fecha1)
                {
                    Diferencia = Fecha2.Subtract(Fecha1);
                    Fila.Cells[0].Value = Diferencia.Days;
                }

                else
                {

                    Fila.Cells[0].Value = "0";
                }



            }
           
            
        }
        //Ventana Mobible
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtpro.Text != "") dgv.DataSource = sql.Buscar2(txtpro.Text);

            else dgv.DataSource = sql.produc();
        }

        private void txtpr_TextChanged(object sender, EventArgs e)
        {
            if (txtpr.Text != "") dgv.DataSource = sql.Buscarcodi(txtpr.Text);

            else dgv.DataSource = sql.produc();
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdmPro ac = new AdmPro();

            if (dgv.SelectedRows.Count > 0)
            {
                ac.txtid.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                ac.txtcodigo.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                ac.txtdescripc.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                ac.txtexistencia.Text = dgv.CurrentRow.Cells[4].Value.ToString();
                ac.txtcatiui.Text = dgv.CurrentRow.Cells[5].Value.ToString();
                ac.combouni.Text = dgv.CurrentRow.Cells[6].Value.ToString();
                ac.txtbodega.Text = dgv.CurrentRow.Cells[7].Value.ToString();
                ac.txtlote.Text = dgv.CurrentRow.Cells[8].Value.ToString();
                ac.txtprecon.Text = dgv.CurrentRow.Cells[9].Value.ToString();
                
                ac.date12.Text = dgv.CurrentRow.Cells[10].Value.ToString();
                ac.txtmarca.Text = dgv.CurrentRow.Cells[11].Value.ToString();




                ac.MdiParent = MdiParent;
                ac.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Debe de Seleccionar una Fila", "Atencion!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtlote_TextChanged(object sender, EventArgs e)
        {
            if (txtlote.Text != "") dgv.DataSource = sql.buscalote(txtlote.Text);

            else dgv.DataSource = sql.produc();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

      

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgv.Columns[e.ColumnIndex].Name == "DiasFaltan")
                {
                   
                    e.CellStyle.ForeColor = Color.Navy;
                    e.CellStyle.BackColor = Color.White;

                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Color.Gray;
                    }

                    if (Convert.ToInt32(e.Value) <= 30 && Convert.ToInt32(e.Value) != 0)
                    {
                        e.CellStyle.ForeColor = Color.Navy;
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }


                if (this.dgv.Columns[e.ColumnIndex].Name == "Existencia")
                {

                    if (DiasFaltan.Visible == true)
                    {
                        if (Convert.ToInt32(e.Value) == 0)
                        {
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.BackColor = Color.Gray;
                        }
                    }

                    else
                    {

                    }


                    if (Convert.ToInt32(e.Value) <= 10 && Convert.ToInt32(e.Value) != 0)
                    {

                        e.CellStyle.ForeColor = Color.Navy;
                        e.CellStyle.BackColor = Color.Yellow;
                    }


                }

            }
            catch (Exception em)
            {
                MessageBox.Show("" + em);
            }
            

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

      
    

        private void timer2_Tick(object sender, EventArgs e)
        {
          



        }

        private void label7_Click(object sender, EventArgs e)
        {
            //string fee = dateTimePicker1.Text;
            //DateTime Fecha1 = DateTime.Now;
            //DateTime Fecha2 = Convert.ToDateTime(fee);

            //TimeSpan Diferencia;

            //Diferencia = Fecha2.Subtract(Fecha1);

            //label7.Text = Diferencia.Days.ToString();
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked == true)
            {
                foreach (DataGridViewRow Fila in dgv.Rows)
                {
                    
                    DateTime Fecha1 = DateTime.Now;
                    DateTime Fecha2 = Convert.ToDateTime(Fila.Cells[10].Value.ToString());

                    TimeSpan Diferencia;
                    if (Fecha2 > Fecha1)
                    {
                        Diferencia = Fecha2.Subtract(Fecha1);
                        Fila.Cells[0].Value = Diferencia.Days;
                    }

                    else
                    {
                        
                        Fila.Cells[0].Value = "0";
                    }


                    
                }
                DiasFaltan.Visible = true;

            }

            else
            {

                dgv.DataSource = sql.produc();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                dgv.DataSource = sql.PruductosAgotados();
            }
            else
            {
                dgv.DataSource = sql.produc();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
    }
}
