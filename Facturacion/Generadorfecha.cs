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
    public partial class Generadorfecha : Form
    {
        public Generadorfecha()
        {
            InitializeComponent();
        }

        public static string fecha = "31/12/2019";
        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void Generadorfecha_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fecha VALUES('"+textBox1.Text+"')", conexion);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexion.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
