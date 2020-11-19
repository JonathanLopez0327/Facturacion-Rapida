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
    public partial class Admcli : Form
    {
        public Admcli()
        {
            InitializeComponent();
        }

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");
        
        public  void Nuevo()
        {
            txtnombre.Clear();
            txtrnc.Clear();
            txtdirecc.Clear();
            txttel.Clear();
            
            txtid.Clear();

            txtnombre.Focus();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtrnc.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtdirecc.Text == "")

            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txttel.Text == "")

            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
           
            else
            {
                //primero buscame si el cliente existe
                try
                {
                    string CMD = string.Format("SELECT * FROM Clientes WHERE Nombre = '{0}'  AND RNC_No = '{1}'", txtnombre.Text.Trim(), txtrnc.Text.Trim());
                    DataSet ds = ConsultasSQL.Ejecutar(CMD);
                    string cli = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                    string rn = ds.Tables[0].Rows[0]["RNC_No"].ToString().Trim();

                    if (cli == txtnombre.Text.Trim() && rn == txtrnc.Text.Trim())
                    {
                        MessageBox.Show("EL Cliente ya esta registrado...", "Lo siento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    try
                    {
                    string cmd = "INSERT INTO Clientes VALUES ('" + txtnombre.Text + "', '" + txtrnc.Text + "', '" + txtdirecc.Text + "', '" + txttel.Text + "')";
                    DataSet ds = ConsultasSQL.Ejecutar(cmd);

                    MessageBox.Show("Cliente Registrado Con Exito", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Nuevo();
                         }
            catch (Exception llll)
            {
                MessageBox.Show("Algo va Mal..." + llll);
            }
                }
                

            
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nuevo();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Atencion Para eliminar un Cliente debe de selccionarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("delete from  Clientes where ID ='" + txtid.Text + "'", conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Borrados Correctamente", "Datos borrados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Nuevo();
                conexion.Close(); 
                     }
            catch (Exception llll)
            {
                MessageBox.Show("Algo va Mal..." + llll);
            }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             if (txtnombre.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtrnc.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtdirecc.Text == "")

            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txttel.Text == "")

            {
                MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
             else
             {
                try
                {
                 conexion.Open();
                 SqlCommand raro = new SqlCommand(@"update Clientes set Nombre = '" + txtnombre.Text + "', RNC_No = '" + txtrnc.Text + "', Direccion = '" + txtdirecc.Text + "', Telefono = '" + txttel.Text + "' where ID = @toma ", conexion);
                 raro.CommandType = CommandType.Text;
                 raro.Parameters.AddWithValue(@"toma", txtid.Text);
                 raro.ExecuteNonQuery();


                 MessageBox.Show("Se ha modificado un producto", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 Nuevo();
                 conexion.Close();
                     }
            catch (Exception llll)
            {
                MessageBox.Show("Algo va Mal..." + llll);
            }
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();

            cli.ShowDialog();

            if (cli.DialogResult == DialogResult.OK)
            {
                try
                {
                    txtid.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[0].Value.ToString();
                    txtnombre.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[1].Value.ToString();
                    txtrnc.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                    txtdirecc.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                    txttel.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                }
                 
            catch (Exception llll)
            {
                MessageBox.Show("Algo va Mal..." + llll);
            }
            }
        }

        private void Admcli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnombre.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtrnc.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (txtdirecc.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (txttel.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, Favor llenar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else
                {
                    //primero buscame si el cliente existe
                    try
                    {
                        string CMD = string.Format("SELECT * FROM Clientes WHERE Nombre = '{0}'  AND RNC_No = '{1}'", txtnombre.Text.Trim(), txtrnc.Text.Trim());
                        DataSet ds = ConsultasSQL.Ejecutar(CMD);
                        string cli = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                        string rn = ds.Tables[0].Rows[0]["RNC_No"].ToString().Trim();

                        if (cli == txtnombre.Text.Trim() && rn == txtrnc.Text.Trim())
                        {
                            MessageBox.Show("EL Cliente ya esta registrado...", "Lo siento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            string cmd = "INSERT INTO Clientes VALUES ('" + txtnombre.Text + "', '" + txtrnc.Text + "', '" + txtdirecc.Text + "', '" + txttel.Text + "')";
                            DataSet ds = ConsultasSQL.Ejecutar(cmd);

                            MessageBox.Show("Cliente Registrado Con Exito", "Datos Guardados",  MessageBoxButtons.OK, MessageBoxIcon.Information);


                            Nuevo();
                        }
                        catch (Exception llll)
                        {
                            MessageBox.Show("Algo va Mal..." + llll);
                        }
                    }



                }
            }
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Admcli_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
