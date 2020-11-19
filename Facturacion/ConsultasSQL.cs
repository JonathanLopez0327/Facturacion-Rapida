using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Facturacion
{
    class ConsultasSQL
    {

        public SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");
        private DataSet ds;


        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\Bdata;Initial Catalog=RGHgroup;Integrated Security=True");
            Con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, Con);

            DP.Fill(DS);
            Con.Close();

            return DS;
        }

        public DataTable Mostradatos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Clientes", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable MuestraRegsitros()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Registros", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable PruductosAgotados()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Productos WHERE Existencia = '0'", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable BuscaRegistro(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT  * FROM Registros WHERE Descripcion LIKE '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable BuscaRegistro3(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT  * FROM Registros WHERE No_Factura LIKE '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable BuscaRegistro2(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT  * FROM Registros WHERE Fecha LIKE '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }



        public DataTable Buscar(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Clientes where Nombre like'%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable Buscarrnc(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Clientes where RNC_No like'%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable produc()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Productos", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        //;
        public DataTable Buscar2(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Descripcion like'%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable buscalote(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Lote like'%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable Buscarcodi(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Codigo like'%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        

        public DataTable maxcomprobante()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select MAX(Cad) From Comprobante", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable maxnote()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select MAX(Rets) From note", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable MaxCreditoFi()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(Cade) FROM CreditoFi", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable maxfecha()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select MAX(fecha) From Fecha", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }


        public DataTable MaxConsumi()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select MAX(Cade) From ConsumidorFi", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable Maxregi()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select MAX(Cad) From Regimenes", conexion);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable realizainfor1(string desde, string hasta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Registros WHERE   Fecha BETWEEN '{0}' AND '{1}' ORDER BY Fecha ASC", desde, hasta), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

        public DataTable realizainfor(string desde, string hasta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Registros WHERE No_Factura  LIKE '%B%' AND Fecha BETWEEN '{0}' AND '{1}' ORDER BY Fecha ASC", desde, hasta), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];

        }

     


        
    }
}

