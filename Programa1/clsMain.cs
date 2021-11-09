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
            //usuario.Nombre = "Edi"; //System.Environment.UserName;
            //System.Windows.Forms.MessageBox.Show(usuario.Nombre);
                        
            frmMain fr = new frmMain();
            fr.usuario = usuario;
            fr.ShowDialog();
        }
    }
}
