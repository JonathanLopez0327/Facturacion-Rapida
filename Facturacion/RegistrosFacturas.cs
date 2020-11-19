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
using System.Runtime.InteropServices;
namespace Facturacion
{
    public partial class RegistrosFacturas : Form
    {
        public RegistrosFacturas()
        {
            InitializeComponent();
        }

       
            
        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");

        ConsultasSQL sql = new ConsultasSQL();


        private void RegistrosFacturas_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.MuestraRegsitros();

            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void txtnombrecli_TextChanged(object sender, EventArgs e)
        {
            if (txtnombrecli.Text != "") dgv.DataSource = sql.BuscaRegistro(txtnombrecli.Text);

            else dgv.DataSource = sql.MuestraRegsitros();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtfecha_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txttipofacc_TextChanged(object sender, EventArgs e)
        {
            if (txttipofacc.Text != "") dgv.DataSource = sql.BuscaRegistro3(txttipofacc.Text);

            else dgv.DataSource = sql.MuestraRegsitros();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (desde.Text != "" && hasta.Text != "") dgv.DataSource = sql.realizainfor(desde.Text, hasta.Text);

                else dgv.DataSource = sql.MuestraRegsitros();

                ExportWithExel rp = new ExportWithExel();


                //datos del cliente




                //detalles fac


                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    report datos = new report();



                    datos.FECHA = (string)this.dgv.Rows[i].Cells[0].Value;//fecha
                    datos.RET = (string)this.dgv.Rows[i].Cells[1].Value;//no fac
                    datos.CODIGO = (string)this.dgv.Rows[i].Cells[2].Value;//codigo fac
                    datos.DESCRPP =  (string)this.dgv.Rows[i].Cells[3].Value;//descripcion fac
                    datos.fax = (string)this.dgv.Rows[i].Cells[4].Value;//lote
                    datos.PRESENTACION = (string)this.dgv.Rows[i].Cells[5].Value;//presentacion
                    datos.CANTIDAD = (string)this.dgv.Rows[i].Cells[6].Value.ToString();//catidad
                    datos.PRECIOU = (string)this.dgv.Rows[i].Cells[7].Value;//costo
                    datos.SUB = (string)this.dgv.Rows[i].Cells[8].Value;//costo total
                    datos.ITBIS = (string)this.dgv.Rows[i].Cells[9].Value;//precio
                    datos.PRECIOT = (string)this.dgv.Rows[i].Cells[10].Value;//precio total
                    datos.telefono = (string)this.dgv.Rows[i].Cells[11].Value;//utilidad






                    datos.ORDEN = desde.Text;
                    datos.VALID = hasta.Text;



                    rp.Inf.Add(datos);
                }




                rp.ShowDialog();
                dgv.DataSource = sql.MuestraRegsitros();
            }
            catch (Exception loer)
            {
                MessageBox.Show("Algo Va Mal..." + loer);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv.DataSource = sql.MuestraRegsitros();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (desde.Text != "" && hasta.Text != "") dgv.DataSource = sql.realizainfor1(desde.Text, hasta.Text);

            //    else dgv.DataSource = sql.MuestraRegsitros();
            //}
            //catch (Exception klk)
            //{
            //    MessageBox.Show("Algo Va Mal..." + klk);
            //}
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportWithExel rp = new ExportWithExel();


                //datos del cliente




                //detalles fac

            try{
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    report datos = new report();




                    datos.FECHA = (string)this.dgv.Rows[i].Cells[0].Value;//fecha
                    datos.RET = (string)this.dgv.Rows[i].Cells[1].Value;//no fac
                    datos.CODIGO = (string)this.dgv.Rows[i].Cells[2].Value;//codigo fac
                    datos.DESCRPP = (string)this.dgv.Rows[i].Cells[3].Value;//descripcion fac
                    datos.fax = (string)this.dgv.Rows[i].Cells[4].Value;//lote
                    datos.PRESENTACION = (string)this.dgv.Rows[i].Cells[5].Value;//presentacion
                    datos.CANTIDAD = (string)this.dgv.Rows[i].Cells[6].Value.ToString();//catidad
                    datos.PRECIOU = (string)this.dgv.Rows[i].Cells[7].Value;//costo
                    datos.SUB = (string)this.dgv.Rows[i].Cells[8].Value;//costo total
                    datos.ITBIS = (string)this.dgv.Rows[i].Cells[9].Value;//precio
                    datos.PRECIOT = (string)this.dgv.Rows[i].Cells[10].Value;//precio total
                    datos.telefono = (string)this.dgv.Rows[i].Cells[11].Value;//utilidad

                    datos.ORDEN = "";
                    datos.VALID = "";



                    rp.Inf.Add(datos);
                }




                rp.ShowDialog();
                dgv.DataSource = sql.MuestraRegsitros();
            }
            catch (Exception loer)
            {
                MessageBox.Show("Algo Va Mal..." + loer);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    if (desde.Text != "" && hasta.Text != "") dgv.DataSource = sql.realizainfor1(desde.Text, hasta.Text);

                    else dgv.DataSource = sql.MuestraRegsitros();
                }
                catch (Exception klk)
                {
                    MessageBox.Show("Algo Va Mal..." + klk);
                }
            }
            else {
                dgv.DataSource = sql.MuestraRegsitros();
            }
        }
    }
}
