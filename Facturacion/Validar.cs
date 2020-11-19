using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Facturacion
{
    class Validar
    {

        public static void SoloNumeroos(KeyPressEventArgs h)
        {
            if (Char.IsDigit(h.KeyChar))
            {
                h.Handled = false;
            }

            else if (Char.IsSeparator(h.KeyChar))
            {
                h.Handled = false;
             }
            else if (char.IsControl(h.KeyChar))
            {
                h.Handled = false;
            }
            else
            {
                h.Handled = true;
                MessageBox.Show("No se Permiten Letras", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
