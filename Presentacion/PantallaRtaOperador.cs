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
        public PantallaRtaOperador()
        {
            InitializeComponent();
        }

        public void PasarDatosLlamada(string[] datosLlamada)
        {
            txtCliente.Text = datosLlamada[0];
            txtCategoria.Text = datosLlamada[1];
            txtOpcion.Text = datosLlamada[2];
            txtSubOp.Text = datosLlamada[3];
        }
    }
}
