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
            usuario.Nombre = System.Environment.UserName;
            //usuario.Nombre = "Lorena";
            //usuario.Nombre = "Ale";
            //usuario.Nombre = "Edi";
            //usuario.Nombre = "Administrador"; //System.Environment.UserName;

            frmMain fr = new frmMain();
            fr.usuario = usuario;
            fr.ShowDialog();
        }
    }
}
