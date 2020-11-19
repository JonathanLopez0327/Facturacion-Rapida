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
using System.Globalization;
using System.Runtime.InteropServices;

namespace Facturacion
{
    public partial class NotaRemision : Form
    {
        public NotaRemision()
        {
            InitializeComponent();
        }
        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");

        public static int con_filas = 0;
        public static int fl = 0;
        public static string fecha;

        public static double ITB;
        public static double PREF;
        public static double ttal;
        public string fechaa3;

        public string LOTEee;
        public decimal Ganancia;
        public decimal Ganancia0;
        public decimal costfinal;

        private void txtcodigofac_TextChanged(object sender, EventArgs e)
        {

        }

        private void NotaRemision_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void txtcodigofac_MouseClick(object sender, MouseEventArgs e)
        {
            txtcodigofac.Clear();
        }

        private void txtcanti_MouseClick(object sender, MouseEventArgs e)
        {
            txtcanti.Clear();
        }

        private void txtpre_MouseClick(object sender, MouseEventArgs e)
        {
            txtpre.Clear();
        }

        private void txtdes_MouseClick(object sender, MouseEventArgs e)
        {
            txtdes.Clear();
        }

        private void txtprecioo_MouseClick(object sender, MouseEventArgs e)
        {
            txtprecioo.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();

            cli.ShowDialog();

            if (cli.DialogResult == DialogResult.OK)
            {
                try
                {
                    txtcliente.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[1].Value.ToString();
                    txtRNC.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                    txtdireccion.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                    txttelefono.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                }
                catch (Exception eoo)
                {
                    MessageBox.Show("Algo Va Mal..." + eoo);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admcli lololo = new Admcli();
            
            lololo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Productos cli = new Productos();

            cli.ShowDialog();

            if (cli.DialogResult == DialogResult.OK)
            {
                try
                {
                    if (cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString() == "0")
                    {
                        MessageBox.Show("Lo Siento Producto Agotado", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[0].Value.ToString() == "0")
                    {
                        MessageBox.Show("Lo Siento Producto Vencido", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        txtcodigofac.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[2].Value.ToString();
                        txtdes.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[3].Value.ToString();
                        txtpre.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[6].Value.ToString();
                        lblcant.Text = cli.dgv.Rows[cli.dgv.CurrentRow.Index].Cells[4].Value.ToString();
                    }
                }
                catch (Exception lppp)
                {
                    MessageBox.Show("Algo Va Mal..." + lppp);
                }
            }

            txtcanti.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtdes.Text == "Descripcion")
            {
                MessageBox.Show("Lo Siento tiene que especifar el Producto que quiere Comprar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtdes.Text == "")
            {
                MessageBox.Show("Lo Siento tiene que especifar el Producto que quiere Comprar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtcodigofac.Text == "Codigo")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtcodigofac.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            else if (txtcanti.Text == "0")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtcanti.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtpre.Text == "Presentacion")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtpre.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtprecioo.Text == "RD$")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else if (txtprecioo.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            else if (lblcant.Text == "Existencia")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                try
                {
                    int cntoma = 0;
                    int cantexis = 0;

                    cntoma = Convert.ToInt32(txtcanti.Text);
                    cantexis = Convert.ToInt32(lblcant.Text);

                    if (cntoma > cantexis)
                    {
                        MessageBox.Show("La Cantidad que ha tomado no esta disponible", "Lo Siento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {




                        bool existe = false;
                        int num_fila = 0;


                        if (con_filas == 0)
                        {
                            dgv.Rows.Add(txtcodigofac.Text, txtcanti.Text, txtpre.Text, txtdes.Text, txtprecioo.Text);

                            decimal subtotal = Convert.ToDecimal(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[con_filas].Cells[4].Value);
                            dgv.Rows[con_filas].Cells[5].Value = subtotal.ToString("N0");



                            con_filas++;


                        }

                        else
                        {
                            foreach (DataGridViewRow Fila in dgv.Rows)
                            {
                                if (Fila.Cells[0].Value.ToString() == txtcodigofac.Text)
                                {
                                    existe = true;
                                    num_fila = Fila.Index;
                                }
                            }

                            if (existe == true)
                            {
                                dgv.Rows[num_fila].Cells[1].Value = (Convert.ToDecimal(txtcanti.Text) + Convert.ToDecimal(dgv.Rows[num_fila].Cells[1].Value)).ToString();

                                decimal subtotal = Convert.ToDecimal(dgv.Rows[num_fila].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[num_fila].Cells[4].Value);
                                dgv.Rows[num_fila].Cells[5].Value = subtotal.ToString("N0");




                            }

                            else
                            {

                                dgv.Rows.Add(txtcodigofac.Text, txtcanti.Text, txtpre.Text, txtdes.Text, txtprecioo.Text);

                                decimal subtotal = Convert.ToDecimal(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[con_filas].Cells[4].Value);
                                dgv.Rows[con_filas].Cells[5].Value = subtotal.ToString("N0");



                                con_filas++;
                            }
                        }

                        ttal = 0;
                        ITB = 0;
                        PREF = 0;




                        foreach (DataGridViewRow Fila in dgv.Rows)
                        {


                            ttal += Convert.ToDouble(Fila.Cells[5].Value);


                        }

                        //convercion;
                        txtsubt.Text = "RD$: " + ttal.ToString("N2", new CultureInfo("en-US"));



                        ITB = ttal * 0.18;
                        txtitbiss.Text = ITB.ToString("N2", new CultureInfo("en-US"));


                        PREF = ttal + ITB;
                        txttotalll.Text = "RD$: " + PREF.ToString("N2", new CultureInfo("en-US"));


                    }
                }
                //aqui va el catch
                catch (Exception o)
                {
                    MessageBox.Show("" + o.Message);
                }



            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (con_filas > 0)
            {
                try
                {
                    ttal = ttal - (Convert.ToDouble(dgv.Rows[dgv.CurrentRow.Index].Cells[5].Value));
                    txtsubt.Text = "RD$: " + ttal.ToString("N2", new CultureInfo("en-US"));


                    ITB = ttal * 0.18;
                    txtitbiss.Text = ITB.ToString("N2", new CultureInfo("en-US"));


                    PREF = ttal + ITB;
                    txttotalll.Text = "RD$" + PREF.ToString("N2", new CultureInfo("en-US"));

                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);

                    con_filas--;
                }
                catch (Exception lppp)
                {
                    MessageBox.Show("Algo Va Mal..." + lppp);
                }
            }
        }


        private void Nuevo()
        {
            txtcliente.Clear();
            txtRNC.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            

            txtno.Text = "B";
           

            txtcodigofac.Text = "Codigo";
            txtcanti.Text = "0";
            txtpre.Text = "Presentacion";
            txtdes.Text = "Descripcion";
            txtprecioo.Text = "RD$";
            lblpreventa.Text = "0";

            lblcant.Text = "Existencia";
            dgv.Rows.Clear();
            txtsubt.Text = "RD$ 0";
            txtitbiss.Text = "0";
            txttotalll.Text = "RD$ 0";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (con_filas == 0)
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtcliente.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtRNC.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtdireccion.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txttelefono.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            //dtalles
            else if (txtno.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

         

            else if (lblcant.Text == "Existencia")
            {
                MessageBox.Show("Debe de llenar todos los Campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                try
                {
                    //generame el ret
                    conexion.Open();
                    SqlCommand lopo = new SqlCommand("INSERT INTO note values('" + txtno.Text + "')", conexion);
                    lopo.ExecuteNonQuery();
                    conexion.Close();

                    maxnoteremision lp = new maxnoteremision();


                    lp.ShowDialog();

                    if (lp.DialogResult == DialogResult.OK)
                    {

                        txtno.Text = "0" + lp.dgv.Rows[lp.dgv.CurrentRow.Index].Cells[0].Value.ToString();


                    }
                }
                catch (Exception mmnn)
                {
                    MessageBox.Show("Algo Va Mal..." + mmnn);
                }








                if (con_filas != 0)
                {

                    try
                    {




                        //llenar reistros
                        string cmd = "INSERT INTO Fac VALUES ('null', 'null', 'null', 'null', 'null')";
                        DataSet ds = ConsultasSQL.Ejecutar(cmd);







                        //fin llenar registro




                        Ganancia = 0;
                        Ganancia0 = 0;
                        decimal precio_c;
                        decimal precio_v;
                        int Cant_Tomada;

                        //llenar fac && fin llenar registro
                        foreach (DataGridViewRow Fila in dgv.Rows)
                        {

                            cmd = "INSERT INTO DEfac VALUES  ( '" + txtno.Text + "','" + Fila.Cells[0].Value.ToString() + "', '" + Fila.Cells[1].Value.ToString() + "', '" + Fila.Cells[2].Value.ToString() + "', '" + Fila.Cells[3].Value.ToString() + "', '" + Fila.Cells[4].Value.ToString() + "', '" + txtsubt.Text + "', '" + txtitbiss.Text + "', '" + txttotalll.Text + "' )";
                            ds = ConsultasSQL.Ejecutar(cmd);

                            //Buscame algunos campos necesarios PARA EL RPORTE

                            SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE Codigo = @Cod", conexion);
                            comando.Parameters.AddWithValue("@Cod", Fila.Cells[0].Value.ToString());
                            conexion.Open();


                            SqlDataReader regsitro = comando.ExecuteReader();
                            if (regsitro.Read())
                            {
                                LOTEee = regsitro["Lote"].ToString();
                                lblpreventa.Text = regsitro["Precio_Compra"].ToString();


                            }
                            conexion.Close();

                            //primer calculo de cantidad por precio

                            precio_c = Convert.ToDecimal(lblpreventa.Text);
                            Cant_Tomada = Convert.ToInt32(Fila.Cells[1].Value.ToString());




                            Ganancia0 = precio_c * Cant_Tomada;//ya tengo mi ganancia 0


                            //calcular utilidad


                            precio_c = Convert.ToDecimal(lblpreventa.Text);
                            precio_v = Convert.ToDecimal(Fila.Cells[5].Value.ToString());
                            if (precio_v < Ganancia0)
                            {
                                Ganancia = 0;
                            }
                            else if (precio_v == Ganancia0)
                            {
                                Ganancia = 0;
                            }
                            else
                            {


                                Ganancia = precio_v - Ganancia0;
                            }


                            //actualiza cantidad
                            double exi;
                            double to;
                            int cant;

                            exi = Convert.ToInt32(lblcant.Text);
                            cant = Convert.ToInt32(Fila.Cells[1].Value.ToString());

                            to = exi - cant;

                            conexion.Open();
                            SqlCommand raro = new SqlCommand(@"update Productos set Existencia = '" + to.ToString() + "' where Codigo = @toma ", conexion);
                            raro.CommandType = CommandType.Text;
                            raro.Parameters.AddWithValue(@"toma", Fila.Cells[0].Value.ToString());
                            raro.ExecuteNonQuery();
                            to = 0;
                            conexion.Close();



                            //actualizar cantidad


                            //registrame la factura
                            conexion.Open();                                                           //Fecha_Factura          //Num_Fac                 //Codigo_Producto                         //Descripcion                           //Lote_Producto                     //presentacion                                //Cant_Tomada                           //Costo                     //CostoTotal                   //Precio                                   //Precio_Total
                            SqlCommand comand = new SqlCommand("INSERT INTO Registros VALUES ('" + fechaa3.ToString() + "', '" + txtno.Text + "', '" + Fila.Cells[0].Value.ToString() + "', '" + Fila.Cells[3].Value.ToString() + "', '" + LOTEee.ToString() + "', '" + Fila.Cells[2].Value.ToString() + "' ,'" + Fila.Cells[1].Value.ToString() + "', '" + lblpreventa.Text + "', '" + Ganancia0.ToString("N2", new CultureInfo("en-US")) + "', '" + Fila.Cells[4].Value.ToString() + "', '" + Fila.Cells[5].Value.ToString() + "', '" + Ganancia.ToString("N2", new CultureInfo("en-US")) + "' )", conexion);
                            comand.ExecuteNonQuery();
                            conexion.Close();
                        }





                        //calculame la Utilidad








                        



                        //continua

                        NOTTTT rp = new NOTTTT();







                        //detalles fac


                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            report datos = new report();

                            datos.Cliente = txtcliente.Text;
                            datos.RNC = txtRNC.Text;
                            datos.direccion = txtdireccion.Text;
                            datos.telefono = txttelefono.Text;

                            //datos del tipo fac

                            datos.RET = txtno.Text;
                            datos.FECHA = txtfechaa.Text;

                            datos.CODIGO = (string)this.dgv.Rows[i].Cells[0].Value;
                            datos.CANTIDAD = (string)this.dgv.Rows[i].Cells[1].Value;
                            datos.PRESENTACION = (string)this.dgv.Rows[i].Cells[2].Value;
                            datos.DESCRPP = (string)this.dgv.Rows[i].Cells[3].Value;
                            datos.PRECIOU = (string)this.dgv.Rows[i].Cells[4].Value;

                            datos.SUB = txtsubt.Text;
                            datos.ITBIS = txtitbiss.Text;
                            datos.PRECIOT = txttotalll.Text;


                            rp.nou.Add(datos);
                        }




                        rp.ShowDialog();
                        Nuevo();
                    }




                    catch (Exception error)
                    {
                        MessageBox.Show("Algo Va mal...  " + error);
                    }




                }
            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtfechaa.Text = DateTime.Now.ToLongDateString();
            fechaa3 = DateTime.Now.ToShortDateString();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtcanti_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeroos(e);
        }

        private void txtprecioo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void NotaRemision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
            if (txtdes.Text == "Descripcion")
            {
                MessageBox.Show("Lo Siento tiene que especifar el Producto que quiere Comprar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtdes.Text == "")
            {
                MessageBox.Show("Lo Siento tiene que especifar el Producto que quiere Comprar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtcodigofac.Text == "Codigo")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtcodigofac.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            else if (txtcanti.Text == "RD$")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtcanti.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtpre.Text == "Presentacion")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtpre.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtprecioo.Text == "0")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else if (txtprecioo.Text == "")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            else if (lblcant.Text == "Existencia")
            {
                MessageBox.Show("Los Campos no pueden estar vacios", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                try
                {
                    int cntoma = 0;
                    int cantexis = 0;

                    cntoma = Convert.ToInt32(txtcanti.Text);
                    cantexis = Convert.ToInt32(lblcant.Text);

                    if (cntoma > cantexis)
                    {
                        MessageBox.Show("La Cantidad que ha tomado no esta disponible", "Lo Siento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {




                        bool existe = false;
                        int num_fila = 0;


                        if (con_filas == 0)
                        {
                            dgv.Rows.Add(txtcodigofac.Text, txtcanti.Text, txtpre.Text, txtdes.Text, txtprecioo.Text);

                            decimal subtotal = Convert.ToDecimal(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[con_filas].Cells[4].Value);
                            dgv.Rows[con_filas].Cells[5].Value = subtotal.ToString("N0");



                            con_filas++;


                        }

                        else
                        {
                            foreach (DataGridViewRow Fila in dgv.Rows)
                            {
                                if (Fila.Cells[0].Value.ToString() == txtcodigofac.Text)
                                {
                                    existe = true;
                                    num_fila = Fila.Index;
                                }
                            }

                            if (existe == true)
                            {
                                dgv.Rows[num_fila].Cells[1].Value = (Convert.ToDecimal(txtcanti.Text) + Convert.ToDecimal(dgv.Rows[num_fila].Cells[1].Value)).ToString();

                                decimal subtotal = Convert.ToDecimal(dgv.Rows[num_fila].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[num_fila].Cells[4].Value);
                                dgv.Rows[num_fila].Cells[5].Value = subtotal.ToString("N0");




                            }

                            else
                            {

                                dgv.Rows.Add(txtcodigofac.Text, txtcanti.Text, txtpre.Text, txtdes.Text, txtprecioo.Text);

                                decimal subtotal = Convert.ToDecimal(dgv.Rows[con_filas].Cells[1].Value) * Convert.ToDecimal(dgv.Rows[con_filas].Cells[4].Value);
                                dgv.Rows[con_filas].Cells[5].Value = subtotal.ToString("N0");



                                con_filas++;
                            }
                        }

                        ttal = 0;
                        ITB = 0;
                        PREF = 0;




                        foreach (DataGridViewRow Fila in dgv.Rows)
                        {


                            ttal += Convert.ToDouble(Fila.Cells[5].Value);


                        }

                        //convercion;
                        txtsubt.Text = "RD$: " + ttal.ToString("N2", new CultureInfo("en-US"));



                        ITB = ttal * 0.18;
                        txtitbiss.Text = ITB.ToString("N2", new CultureInfo("en-US"));


                        PREF = ttal + ITB;
                        txttotalll.Text = "RD$: " + PREF.ToString("N2", new CultureInfo("en-US"));


                    }
                }
                //aqui va el catch
                catch (Exception o)
                {
                    MessageBox.Show("" + o.Message);
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
