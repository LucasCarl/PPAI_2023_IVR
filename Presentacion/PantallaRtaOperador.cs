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

        public void HabilitarPantalla()
        {
            this.Show();
        }

        public void MostrarDatosLlamada(string nombreCliente, string[] datosOpciones)
        {
            txtCliente.Text = nombreCliente;
            txtCategoria.Text = datosOpciones[0];
            txtOpcion.Text = datosOpciones[1];
            txtSubOp.Text = datosOpciones[2];
        }

        public void MostrarValidacion(int validacion)
        {
            GroupBox gboxValidacion;
            switch (validacion)
            {
                case 1:
                    gboxValidacion = gbxFechaNacimiento;
                    break;

                case 2:
                    gboxValidacion = gbxHijos;
                    break;

                case 3:
                    gboxValidacion = gbxCodigoPostal;
                    break;

                default:
                    return;
            }

            gboxValidacion.Visible = true;
        }

        public void SolicitarValidacion(int validacion)
        {
            GroupBox gboxValidacion;
            switch (validacion)
            {
                case 1:
                    gboxValidacion = gbxFechaNacimiento;
                    break;

                case 2:
                    gboxValidacion = gbxHijos;
                    break;

                case 3:
                    gboxValidacion = gbxCodigoPostal;
                    break;

                default:
                    return;
            }

            gboxValidacion.Enabled = true;
        }

        public void TomarValidacion(int validacion, string dato)
        {
            gestorRta.ControlarValidacion(validacion, dato);
        }

        public void ValidacionBuena(int validacion)
        {
            GroupBox gboxValidacion;
            switch (validacion)
            {
                case 1:
                    gboxValidacion = gbxFechaNacimiento;
                    break;

                case 2:
                    gboxValidacion = gbxHijos;
                    break;

                case 3:
                    gboxValidacion = gbxCodigoPostal;
                    break;

                default:
                    return;
            }

            gboxValidacion.Enabled = false;
            gboxValidacion.BackColor = Color.GreenYellow;
        }

        public void ErrorValidacion()
        {
            MessageBox.Show("La validacion ingresada no es correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void MostrarAcciones(string[] nombreAcciones)
        {
            cbxAcciones.DataSource = nombreAcciones;
        }

        public void SolicitarAccion()
        {
            txtDescripcion.Enabled = true;
            btnRegistrarAccion.Enabled = true;
            cbxAcciones.Enabled = true;
        }

        public void TomarAccion()
        {
            string descr = txtDescripcion.Text;
            int accion = cbxAcciones.SelectedIndex;
            gestorRta.TomarAccion(accion, descr);
        }

        private void btnRegistrarAccion_Click(object sender, EventArgs e)
        {
            TomarAccion();
        }

        public void SolicitarConfirmacion()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere confirmar esta acción?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            gestorRta.TomarConfirmacion(respuesta == DialogResult.Yes);
        }

        public void TomarConfirmacion()
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere terminar la llamada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == respuesta)
            {
                this.Close();
            }
        }

        public void AvisoFinRegistro()
        {
            MessageBox.Show("La llamada y su accion fueron registradas con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnFechaNacimiento_Click(object sender, EventArgs e)
        {
            TomarValidacion(1, dtpFechaNacimiento.Text.ToString());
        }

        private void btnHijos_Click(object sender, EventArgs e)
        {
            TomarValidacion(2, numHijos.Text.ToString());
        }

        private void btnCodigoPostal_Click(object sender, EventArgs e)
        {
            TomarValidacion(3, numCodigoPostal.Text.ToString());
        }
    }
}
