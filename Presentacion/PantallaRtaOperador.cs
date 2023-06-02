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
            Application.Run(this);
        }

        public void MostrarDatosLlamada(string nombreCliente, string[] datosOpciones)
        {
            txtCliente.Text = nombreCliente;
            txtCategoria.Text = datosOpciones[0];
            txtOpcion.Text = datosOpciones[1];
            txtSubOp.Text = datosOpciones[2];
        }

        public void MostrarValidacion()
        {

        }

        public void SolicitarValidacion()
        {

        }

        public void TomarValidacion()
        {

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

        public void MostrarAccion(string[] nombreAcciones)
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

        }

        private void btnRegistrarAccion_Click(object sender, EventArgs e)
        {
            string descr = txtDescripcion.Text;
            int accion = cbxAcciones.SelectedIndex;
            if(accion == 0)
            {
                DialogResult respuesta = MessageBox.Show("No se selecciono ninguna acción.\nDesea registrar la llamada sin ninguna accion asignada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.No)
                {
                    return;
                }
            }
            gestorRta.TomarAccion(accion, descr);
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
    }
}
