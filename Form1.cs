using PPAI_IVR_2023.Entidades;
using PPAI_IVR_2023.Gestores;

namespace PPAI_IVR_2023
{
    public partial class Form1 : Form
    {
        private GestorRtaOperador gestorRtaOperador;
        private Cliente[] clientes;

        public Form1(GestorRtaOperador gestor, Cliente[] listaClientes)
        {
            InitializeComponent();
            gestorRtaOperador = gestor;
            clientes = listaClientes;
            button1.Text = listaClientes[0].GetNombre();
            button2.Text = listaClientes[1].GetNombre();
            button3.Text = listaClientes[2].GetNombre();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestorRtaOperador.OpOperador(clientes[0]);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestorRtaOperador.OpOperador(clientes[1]);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gestorRtaOperador.OpOperador(clientes[2]);
            this.Hide();
        }
    }
}