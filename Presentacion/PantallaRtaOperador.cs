using PPAI_IVR_2023.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR_2023.Presentacion
{
    public partial class PantallaRtaOperador : Form
    {
        GestorRtaOperador gestorRta;

        public PantallaRtaOperador(GestorRtaOperador gestor)
        {
            InitializeComponent();
            this.gestorRta = gestor;
        }

        public void PasarDatosLlamada(string[] datosLlamada)
        {
            txtCliente.Text = datosLlamada[0];
            txtCategoria.Text = datosLlamada[1];
            txtOpcion.Text = datosLlamada[2];
            txtSubOp.Text = datosLlamada[3];
        }

        public void TomarValidaciones()
        {
            string fechaNacimiento = dtpFechaNacimiento.Text.ToString();
            string hijos = numHijos.Text.ToString();
            string codigoPostal = numCodigoPostal.Text.ToString();

            gestorRta.ControlarValidaciones(fechaNacimiento, hijos, codigoPostal);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            TomarValidaciones();
        }

        public void ErrorValidacion()
        {
            MessageBox.Show("Una de las validaciones ingresadas no es correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void TomarDescripcion()
        {
            txtDescripcion.Enabled = true;
            btnRegistrarAccion.Enabled = true;
        }
    }
}
