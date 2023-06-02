using PPAI_IVR_2023.Entidades;
using PPAI_IVR_2023.DataAccessObjects;
using PPAI_IVR_2023.Gestores;
using PPAI_IVR_2023.Presentacion;

namespace PPAI_IVR_2023
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new Form1(new GestorRtaOperador(), ClientesDao.Instancia().GetClientes()));
        }
    }
}