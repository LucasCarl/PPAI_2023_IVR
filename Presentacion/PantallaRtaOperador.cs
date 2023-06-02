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

        /// <summary>  Muestra la pantalla </summary>
        public void HabilitarPantalla()
        {
            this.Show();
        }

        /// <summary> Muestra los datos de la llamada </summary>
        /// <param name="nombreCliente"> Nombre del cliente </param>
        /// <param name="datosOpciones"> Nombres de las opciones </param>
        public void MostrarDatosLlamada(string nombreCliente, string[] datosOpciones)
        {
            txtCliente.Text = nombreCliente;
            txtCategoria.Text = datosOpciones[0];
            txtOpcion.Text = datosOpciones[1];
            txtSubOp.Text = datosOpciones[2];
        }

        /// <summary> Muestra el groupbox de la validacion indicada </summary>
        /// <param name="validacion"> Numero de orden de la validacion que se quiere mostrar </param>
        public void MostrarValidacion(int validacion)
        {
            // Selecciona el groupbox
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
            // Lo hace visible
            gboxValidacion.Visible = true;
        }

        /// <summary> Habilita el groupbox de la validacion indicada </summary>
        /// <param name="validacion"> Numero de orden de la validacion que se quiere mostrar </param>
        public void SolicitarValidacion(int validacion)
        {
            // Selecciona el groupbox
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
            // Lo habilita
            gboxValidacion.Enabled = true;
        }
        /// <summary> Toma los datos de la validacion indicada </summary>
        /// <param name="validacion"> Numero de orden de la validacion que se quiere comprobar </param>
        /// <param name="dato"> Informacion que se quiere comprobar </param>
        public void TomarValidacion(int validacion, string dato)
        {
            gestorRta.ControlarValidacion(validacion, dato);
        }

        /// <summary> Marca el groupbox de la validacion indicada y lo deshabilita </summary>
        /// <param name="validacion"> Numero de orden de la validacion que se quiere mostrar </param>
        public void ValidacionBuena(int validacion)
        {
            // Selecciona el groupbox
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
            // Lo deshabilita y le cambia el color
            gboxValidacion.Enabled = false;
            gboxValidacion.BackColor = Color.GreenYellow;
        }

        /// <summary> Avisa al usuario que la validacion no fue correcta </summary>
        public void ErrorValidacion()
        {
            MessageBox.Show("La validacion ingresada no es correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary> Muestra los nombres de las acciones en el combobox </summary>
        public void MostrarAcciones(string[] nombreAcciones)
        {
            cbxAcciones.DataSource = nombreAcciones;
        }

        /// <summary> Habilita los componentes para que el operador pueda elegir una acicon </summary>
        public void SolicitarAccion()
        {
            txtDescripcion.Enabled = true;
            btnRegistrarAccion.Enabled = true;
            cbxAcciones.Enabled = true;
        }

        /// <summary> Toma los datos de la accion seleccionada </summary>
        public void TomarAccion()
        {
            string descr = txtDescripcion.Text;
            int accion = cbxAcciones.SelectedIndex;
            gestorRta.TomarAccion(accion, descr);
        }

        /// <summary> Muestra una pantalla para que el operador confirme su seleccion </summary>
        public void SolicitarConfirmacion()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere confirmar esta acción?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            TomarConfirmacion(respuesta == DialogResult.Yes);
        }

        /// <summary> Toma la confirmacion del operador </summary> 
        public void TomarConfirmacion(bool respuesta)
        {
            gestorRta.TomarConfirmacion(respuesta);
        }

        /// <summary> Avisa al operador que la operacion fue exitosa </summary>
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

        private void btnRegistrarAccion_Click(object sender, EventArgs e)
        {
            TomarAccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere terminar la llamada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == respuesta)
            {
                Application.Exit();
            }
        }
    }
}
