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

namespace Facturacion
{
    public partial class comprobante : Form
    {
        public comprobante()
        {
            InitializeComponent();
        }
        VentanaPrincipal vp = new VentanaPrincipal();

        public static int con_filas = 0;
        public static int fl = 0;
        public static string fecha;

        public static double ITB;
        public static double PREF;
        public static double ttal;

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Lo Siento tiene que especifar el Producto que quiere Comprar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtcodigo.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtcantidad.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtpreciou.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                bool existe = false;
                int num_fila = 0;


                if (con_filas == 0)
                {
                    dgv.Rows.Add(txtcodigo.Text, txtcantidad.Text, txtpresentacion.Text, txtdescripcion.Text, txtpreciou.Text);

                    double subtotal = Convert.ToDouble(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDouble(dgv.Rows[con_filas].Cells[4].Value);
                    dgv.Rows[con_filas].Cells[5].Value = subtotal;

                    double itbiss = Convert.ToDouble(dgv.Rows[con_filas].Cells[5].Value) * Convert.ToDouble(dgv.Rows[con_filas].Cells[8].Value = 0.18);
                    dgv.Rows[con_filas].Cells[6].Value = itbiss;

                    double preciofinal = Convert.ToDouble(dgv.Rows[con_filas].Cells[5].Value) - Convert.ToDouble(dgv.Rows[con_filas].Cells[6].Value);
                    dgv.Rows[con_filas].Cells[7].Value = preciofinal;

                    con_filas++;


                }

                else
                { 
                    foreach(DataGridViewRow Fila in dgv.Rows)
                    {
                        if (Fila.Cells[0].Value.ToString() == txtcodigo.Text)
                        {
                            existe = true;
                            num_fila = Fila.Index;
                        }
                    }

                    if (existe == true)
                    {
                        dgv.Rows[num_fila].Cells[1].Value = (Convert.ToDouble(txtcantidad.Text) + Convert.ToDouble(dgv.Rows[num_fila].Cells[1].Value)).ToString();

                        double subtotal = Convert.ToDouble(dgv.Rows[num_fila].Cells[1].Value) * Convert.ToDouble(dgv.Rows[num_fila].Cells[4].Value);
                        dgv.Rows[num_fila].Cells[5].Value = subtotal;

                        double itbiss = Convert.ToDouble(dgv.Rows[num_fila].Cells[5].Value) * Convert.ToDouble(dgv.Rows[num_fila].Cells[8].Value = 0.18);
                        dgv.Rows[num_fila].Cells[6].Value = itbiss;

                        double preciofinal = Convert.ToDouble(dgv.Rows[num_fila].Cells[5].Value) - Convert.ToDouble(dgv.Rows[num_fila].Cells[6].Value);
                        dgv.Rows[num_fila].Cells[7].Value = preciofinal;


                    }

                    else

                    {

                        dgv.Rows.Add(txtcodigo.Text, txtcantidad.Text, txtpresentacion.Text, txtdescripcion.Text, txtpreciou.Text);

                        double subtotal = Convert.ToDouble(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDouble(dgv.Rows[con_filas].Cells[4].Value);
                        dgv.Rows[con_filas].Cells[5].Value = subtotal;

                        double itbiss = Convert.ToDouble(dgv.Rows[con_filas].Cells[5].Value) * Convert.ToDouble(dgv.Rows[con_filas].Cells[8].Value = 0.18);
                        dgv.Rows[con_filas].Cells[6].Value = itbiss;

                        double preciofinal = Convert.ToDouble(dgv.Rows[con_filas].Cells[5].Value) - Convert.ToDouble(dgv.Rows[con_filas].Cells[6].Value);
                        dgv.Rows[con_filas].Cells[7].Value = preciofinal;

                        con_filas++;
                    }
                }

                ttal = 0;
                ITB = 0;
                PREF = 0;

                foreach (DataGridViewRow Fila in dgv.Rows)
                {
                    ITB += Convert.ToDouble(Fila.Cells[6].Value);

                    ttal += Convert.ToDouble(Fila.Cells[5].Value);

                    PREF += Convert.ToDouble(Fila.Cells[7].Value);
                }

                //convercion;
                txtsub.Text = "RD$" + ttal.ToString();
                txtitbis.Text = "18% ITBIS:" + ITB.ToString();
                txttotal.Text = "RD$" + PREF.ToString();
            }



                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (con_filas > 0)
            {
                ttal = ttal - (Convert.ToDouble(dgv.Rows[dgv.CurrentRow.Index].Cells[5].Value));
                txtsub.Text = "RD$" + ttal.ToString();

                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);

                con_filas--;
            }
            




        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lblcliente.Text = ".";
            lblrnc.Text = ".";
            lbldirecc.Text = ".";
            lbltel.Text = ".";
            lblfax.Text = ".";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblhora.Text = DateTime.Now.ToLongTimeString();
            //lblfecha.Text = DateTime.Now.ToLongDateString();
            //lblfe.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Productos cli = new Productos();

            cli.ShowDialog();

            if (cli.DialogResult == DialogResult.OK)
            {

                txtcodigo.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[1].Value.ToString();
                txtdescripcion.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                txtpresentacion.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                lblcantidad.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                
            }

            txtcantidad.Focus();
        }

        private void comprobante_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet2.NewSelectCommand' Puede moverla o quitarla según sea necesario.
            //this.NewSelectCommandTableAdapter.Fill(this.DataSet2.NewSelectCommand);

            //this.reportViewer1.RefreshReport();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (con_filas != 0)
            {
                try
                {
                    double exi = 0;
                    double to = 0;
                    int cant;

                    exi = Convert.ToInt32(lblcantidad.Text);
                    cant = Convert.ToInt32(txtcantidad.Text);

                    to = exi - cant;

                    



                    //actualizar cantidad
                    conexion.Open();
                    SqlCommand raro = new SqlCommand(@"update Productos set Existencia = '"+to.ToString()+"' where Codigo = @toma ", conexion);
                    raro.CommandType = CommandType.Text;
                    raro.Parameters.AddWithValue(@"toma", txtcodigo.Text);
                    raro.ExecuteNonQuery();
                    to = 0;


                    //llenar reistros
                    string cmd = "INSERT INTO Fac VALUES ('" + lblfe.Text + "', '" + lblvalid.Text + "', '" + txtorden.Text + "', '" + txtforma.Text + "')";
                    DataSet ds = ConsultasSQL.Ejecutar(cmd);


                    cmd = string.Format("EXEC actcli '{0}', '{1}', '{2}', '{3}', '{4}'", lblcliente.Text.Trim(), lblrnc.Text.Trim(), lbldirecc.Text.Trim(), lbltel.Text.Trim(), lblfax.Text.Trim());

                    ds = ConsultasSQL.Ejecutar(cmd);

                    string NumFac = ds.Tables[0].Rows[0]["Cad"].ToString().Trim();



                    //fin llenar registro


                    lblret.Text = NumFac;





                    //llenar fac && fin llenar registro
                    foreach (DataGridViewRow Fila in dgv.Rows)
                    {

                        cmd = "INSERT INTO DEfac VALUES  ('" + Fila.Cells[0].Value.ToString() + "', '" + Fila.Cells[1].Value.ToString() + "', '" + Fila.Cells[2].Value.ToString() + "', '" + Fila.Cells[3].Value.ToString() + "', '" + Fila.Cells[4].Value.ToString() + "', '" + txtsub.Text + "', '" + txtitbis.Text + "', '" + txttotal.Text + "' )";
                        ds = ConsultasSQL.Ejecutar(cmd);


                    }

                    Reporte rp = new Reporte();
                    

                    //datos del cliente

                    

                    
                    //detalles fac


                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        report datos = new report();

                        datos.Cliente = lblcliente.Text;
                        datos.RNC = lblrnc.Text;
                        datos.direccion = lbldirecc.Text;
                        datos.telefono = lbltel.Text;
                        datos.fax = lblfax.Text;
                        //datos del tipo fac

                        datos.RET = lblret.Text;
                        datos.VALID = lblvalid.Text;
                        datos.FECHA = lblfe.Text;
                        datos.ORDEN = txtorden.Text;
                        datos.FORMA = txtforma.Text;

                        datos.CODIGO = (string)this.dgv.Rows[i].Cells[0].Value;
                        datos.CANTIDAD = (string)this.dgv.Rows[i].Cells[1].Value;
                        datos.PRESENTACION = (string)this.dgv.Rows[i].Cells[2].Value;
                        datos.DESCRPP = (string)this.dgv.Rows[i].Cells[3].Value;
                        datos.PRECIOU = (string)this.dgv.Rows[i].Cells[4].Value;
                        
                        datos.SUB = txtsub.Text;
                        datos.ITBIS = txtitbis.Text;
                        datos.PRECIOT = txttotal.Text;


                        rp.datospri.Add(datos);
                    }

                  

                   
                    rp.ShowDialog();





                }
                catch (Exception error)
                {
                    MessageBox.Show("Los Siento Ha Ocurrido un Error... " + error.Message);
                }




                

               



            }
        }

        private void lblfe_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Generadorfecha fee = new Generadorfecha();

            fee.ShowDialog();

            if (fee.DialogResult == DialogResult.OK)
            {

               
            }
        }

        private void lblorden_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reporte rt = new Reporte();
            rt.Show();
        }

        private void lblvalid_Click(object sender, EventArgs e)
        {
            fecha = vp.lblfecha.Text.ToString();
            lblfe.Text = fecha.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();

            cli.ShowDialog();

            if (cli.DialogResult == DialogResult.OK)
            {

                lblcliente.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[1].Value.ToString();
                lblrnc.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                lbldirecc.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                lbltel.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                lblfax.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[5].Value.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de que desea Salir?", "Atencion!!!!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.Close();
            }

            else
            {

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Nuevo();
        }



        private void Nuevo()
        {
            lblcantidad.Text = "Existencia";
            lblcliente.Text = ".";
            lblret.Text = ".";
            lblrnc.Text = ".";
            lbldirecc.Text = ".";
            lbltel.Text = ".";
            lblfax.Text = ".";

            lblfe.Text = ".";
            txtorden.Clear();
            txtforma.Clear();
            lblvalid.Text = ".";
            

            txtcantidad.Clear();
            txtcodigo.Clear();
            txtdescripcion.Clear();
            txtpreciou.Clear();
            txtpresentacion.Clear();

            txttotal.Text = "RD$";
            txtsub.Text = "RD$";
            txtitbis.Text = "18%";

            dgv.Rows.Clear();
            con_filas = 0;
            ttal = 0;
            ITB = 0;
            PREF = 0;
            button2.Focus();
        }
    }
}
