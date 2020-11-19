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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");


        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
         
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Realizar la Copia de Seguridad
            string NombreCopia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + "Backup RHG");
            string Comando_Consulta = @"BACKUP DATABASE [RGHgroup] TO  DISK = N'C:\Users\Admin\ " + NombreCopia + "' WITH NOFORMAT, NOINIT,  NAME = N'RGHgroup-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            SqlCommand cmd = new SqlCommand(Comando_Consulta, conexion);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Procedimiento Guardados Correctamente...", " ¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception o)
            {
                MessageBox.Show("Si desea realizar otra copia cierre e intentelo de nuevo");
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
