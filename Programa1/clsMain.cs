namespace Programa1
{
    using Programa1.DB.Varios;
    using System;

    class clsMain
    {
        [STAThread]
        static public void Main()
        {
            Usuarios usuario = new Usuarios();
            //usuario.Nombre = System.Environment.UserName;
            //usuario.Nombre = "Edi"; //System.Environment.UserName;
            usuario.Nombre = "Administrador"; //System.Environment.UserName;

            frmMain fr = new frmMain();
            fr.usuario = usuario;
            fr.ShowDialog();
        }
    }
}
