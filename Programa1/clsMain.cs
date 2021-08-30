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
            //System.Windows.Forms.MessageBox.Show(usuario.Nombre);
            //usuario.Nombre = "Hacienda";

            frmMain fr = new frmMain();
            fr.usuario = usuario;
            fr.ShowDialog();
        }
    }
}
