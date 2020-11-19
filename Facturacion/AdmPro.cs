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
    public partial class AdmPro : Form
    {
        public AdmPro()
        {
            InitializeComponent();
        }

        public string unidadd;

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Productos cli = new Productos();


                cli.ShowDialog();

                if (cli.DialogResult == DialogResult.OK)
                {
                    txtid.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[1].Value.ToString();
                    txtcodigo.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                    txtdescripc.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                    txtexistencia.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                    txtcatiui.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[5].Value.ToString();
                    combouni.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[6].Value.ToString();
                    txtbodega.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[7].Value.ToString();
                    txtlote.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[8].Value.ToString();
                    txtprecon.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[9].Value.ToString();
                    date12.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[10].Value.ToString();
                    txtmarca.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[11].Value.ToString();
                }
            }
            catch (Exception em)
            {
                MessageBox.Show("" + em.Message);
            }
        }

        public void Nuevo()
        {
            txtid.Clear();

            txtcodigo.Clear();
            txtdescripc.Clear();
            txtexistencia.Clear();
            combouni.Text = "Seleccione una Unidad";
            txtbodega.Clear();
            txtlote.Clear();
            
            txtmarca.Clear();
            txtcatiui.Clear();
            txtex.Clear();
            txtprecon.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtdescripc.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtexistencia.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else if (txtprecon.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                

            else if (txtcatiui.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (combouni.Text == "Seleccione una Unidad")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtbodega.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtlote.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            else if (txtmarca.Text == "")
            {
                MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                try
                {
                    //verificame si existe la descrpcion y el lote

                    string CMD = string.Format("Select * FROM Productos WHERE Descripcion = '{0}' AND Lote='{1}'", txtdescripc.Text.Trim(), txtlote.Text.Trim());

                    DataSet ds = ConsultasSQL.Ejecutar(CMD);
                    string descri = ds.Tables[0].Rows[0]["Descripcion"].ToString().Trim();
                    string lote = ds.Tables[0].Rows[0]["Lote"].ToString().Trim();


                    if (descri == txtdescripc.Text.Trim() && lote == txtlote.Text.Trim())
                    {
                        //YA QUE EXISTE JALAME LA CANTIDAD EXISTENTE

                        SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE Descripcion = @Cod", conexion);
                        comando.Parameters.AddWithValue("@Cod", txtdescripc.Text);
                        conexion.Open();

                        SqlDataReader regsitro = comando.ExecuteReader();
                        if (regsitro.Read())
                        {
                            txtid.Text = regsitro["ID"].ToString();
                            txtex.Text = regsitro["Existencia"].ToString();

                        }
                        conexion.Close();

                        //ya que tengo la cantidad hago el calculo

                        int CantiExi = 0;
                        int CantToma = 0;
                        int CantFinal = 0;

                        CantToma = Convert.ToInt32(txtexistencia.Text);
                        CantiExi = Convert.ToInt32(txtex.Text);

                        CantFinal = CantiExi + CantToma;

                        //ya que tengo en calculo procedo a modificar

                        conexion.Open();
                        SqlCommand raro = new SqlCommand(@"UPDATE Productos SET Existencia = '" + CantFinal + "' WHERE ID = @toma ", conexion);
                        raro.CommandType = CommandType.Text;
                        raro.Parameters.AddWithValue(@"toma", txtid.Text);
                        raro.ExecuteNonQuery();


                        MessageBox.Show("Registo Existoso", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nuevo();
                        conexion.Close();


                        CantFinal = 0;

                    }

                }
                catch (Exception)
                {
                    //si no existe insertame normalmente
                    




                    string agregar = "Insert into Productos  Values('" + txtcodigo.Text + "','" + txtdescripc.Text + "','" + txtexistencia.Text + "',  '" + txtcatiui.Text + "','" + combouni.Text + "', '" + txtbodega.Text + "' , '" + txtlote.Text + "', '" + txtprecon.Text + "', '" + date12.Text + "', '" + txtmarca.Text + "')";

                    DataSet ds = ConsultasSQL.Ejecutar(agregar);
                    MessageBox.Show("Se Ha agregado un Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevo();
                }


            }
        }
        


               
            
         

        private void button4_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtdescripc.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtexistencia.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

                else if(txtbodega.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtcatiui.Text == "")
            {
                MessageBox.Show("Favor de seleccionar un Unidad...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (combouni.Text == "Seleccione una Unidad")
            {
                MessageBox.Show("Favor de seleccionar un Unidad...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtlote.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
            else if (txtprecon.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

           

            else if (txtmarca.Text == "")
            {
                MessageBox.Show("Favor llenar los Campos...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                

                    conexion.Open();
                    SqlCommand raro = new SqlCommand(@"update Productos set Codigo = '" + txtcodigo.Text + "', Descripcion = '" + txtdescripc.Text + "', Existencia = '" + txtexistencia.Text + "',C_Unidades = '" + txtcatiui.Text + "' ,Unidad = '" + combouni.Text + "', Bodega = '" + txtbodega.Text + "', Lote = '" + txtlote.Text + "', Precio_Compra = '" + txtprecon.Text + "', Vencimiento = '" + date12.Text + "', Marca = '" + txtmarca.Text + "' where ID = @toma ", conexion);
                    raro.CommandType = CommandType.Text;
                    raro.Parameters.AddWithValue(@"toma", txtid.Text);
                    raro.ExecuteNonQuery();


                    MessageBox.Show("Se ha modificado un producto", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevo();
                    conexion.Close();
                }
                catch (Exception es)
                {
                    MessageBox.Show("Algo va Mal..." + es);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Favo llnar el campo codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("delete from  Productos where ID='" + txtid.Text + "'", conexion);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos Borrados Correctamente", "Datos borrados", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    conexion.Close();
                    Nuevo();
                }
                catch (Exception es)
                {
                    MessageBox.Show("Algo va Mal..." + es);
                }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtpreven_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtgananc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtexistencia_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtexistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeroos(e);
        }

        private void txtprecon_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtpreven_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtgananc_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtcatiui_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeroos(e);
        }

        private void AdmPro_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void AdmPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcodigo.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txtdescripc.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txtexistencia.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txtprecon.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else if (txtcatiui.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (combouni.Text == "Seleccione una Unidad")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txtbodega.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txtlote.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                else if (txtmarca.Text == "")
                {
                    MessageBox.Show("Debe de Llenar los Campos Faltantes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    try
                    {
                        //verificame si existe la descrpcion y el lote

                        string CMD = string.Format("Select * FROM Productos WHERE Descripcion = '{0}' AND Lote='{1}'", txtdescripc.Text.Trim(), txtlote.Text.Trim());

                        DataSet ds = ConsultasSQL.Ejecutar(CMD);
                        string descri = ds.Tables[0].Rows[0]["Descripcion"].ToString().Trim();
                        string lote = ds.Tables[0].Rows[0]["Lote"].ToString().Trim();


                        if (descri == txtdescripc.Text.Trim() && lote == txtlote.Text.Trim())
                        {
                            //YA QUE EXISTE JALAME LA CANTIDAD EXISTENTE

                            SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE Descripcion = @Cod", conexion);
                            comando.Parameters.AddWithValue("@Cod", txtdescripc.Text);
                            conexion.Open();

                            SqlDataReader regsitro = comando.ExecuteReader();
                            if (regsitro.Read())
                            {
                                txtid.Text = regsitro["ID"].ToString();
                                txtex.Text = regsitro["Existencia"].ToString();

                            }
                            conexion.Close();

                            //ya que tengo la cantidad hago el calculo

                            int CantiExi = 0;
                            int CantToma = 0;
                            int CantFinal = 0;

                            CantToma = Convert.ToInt32(txtexistencia.Text);
                            CantiExi = Convert.ToInt32(txtex.Text);

                            CantFinal = CantiExi + CantToma;

                            //ya que tengo en calculo procedo a modificar

                            conexion.Open();
                            SqlCommand raro = new SqlCommand(@"UPDATE Productos SET Existencia = '" + CantFinal + "' WHERE ID = @toma ", conexion);
                            raro.CommandType = CommandType.Text;
                            raro.Parameters.AddWithValue(@"toma", txtid.Text);
                            raro.ExecuteNonQuery();


                            MessageBox.Show("Registo Existoso", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Nuevo();
                            conexion.Close();


                            CantFinal = 0;

                        }

                    }
                    catch (Exception)
                    {
                        //si no existe insertame normalmente





                        string agregar = "Insert into Productos  Values('" + txtcodigo.Text + "','" + txtdescripc.Text + "','" + txtexistencia.Text + "',  '" + txtcatiui.Text + "','" + combouni.Text + "', '" + txtbodega.Text + "' , '" + txtlote.Text + "', '" + txtprecon.Text + "', '" + date12.Text + "', '" + txtmarca.Text + "')";

                        DataSet ds = ConsultasSQL.Ejecutar(agregar);
                        MessageBox.Show("Se Ha agregado un Producto", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nuevo();
                    }


                }
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      
    }
}
