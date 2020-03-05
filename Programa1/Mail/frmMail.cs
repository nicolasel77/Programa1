using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Programa1.Mail
{
    public partial class frmMail : Form
    {
        private struct Prod
        {
            public int Cod;
            public string Descripcion;
            public Single Precio;
        }

        public frmMail()
        {
            InitializeComponent();
        }

        private void cmdActualizar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application outLookApp = new Microsoft.Office.Interop.Outlook.Application();
                NameSpace outlookNamespace = outLookApp.GetNamespace("MAPI");
                MAPIFolder inbox = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                Items mailsItems = inbox.Items;

                mailsItems.Sort("[ReceivedTime]", true);
                int n = 0;
                label1.Text = "Leyendo...";
                foreach (MailItem item in mailsItems)
                {
                    if (item.Subject == "BALANZA" && item.UnRead == true)
                    {
                        label1.Text = $"{label1.Text}\r{item.ReceivedTime.ToString()}  :  {item.Subject}";
                        StringReader strReader = new StringReader(item.Body);

                        //1) Fecha y Hora
                        int fe = item.Body.IndexOf("Fecha:");
                        if (fe > -1)
                        {
                            string ss = item.Body.Substring(fe + 6, 16);

                            DateTime fechaHora;
                            if (DateTime.TryParse(ss, out fechaHora) == true)
                            {
                                label1.Text = $"{label1.Text}\r  {fechaHora.ToString("dd/MM/yyy HH:mm")}";

                                List<string> sucs = new List<string>();
                                List<Prod> prods = new List<Prod>();
                                                                
                                while ((ss = strReader.ReadLine()) != null)
                                {
                                    fe = ss.IndexOf("Sucs:");
                                    if (fe > -1)
                                    {
                                        ss = ss.Substring(fe + 5);
                                        sucs = new List<string>(ss.Split(",".ToCharArray()).ToList());
                                    }

                                    fe = ss.IndexOf("@@");
                                    if (fe > -1)
                                    {
                                        int iSeparador = ss.IndexOf(" ");

                                        string temp = ss.Substring(fe + 2, iSeparador - (fe + 2));
                                        Prod pr;
                                        pr.Cod = Convert.ToInt32(temp);


                                        int iSignoPesos = ss.IndexOf("$");

                                        pr.Descripcion = ss.Substring(iSeparador + 1, iSignoPesos - (iSeparador + 2));
                                        temp = ss.Substring(iSignoPesos + 1);
                                        pr.Precio = Convert.ToSingle(temp);

                                        prods.Add(pr);
                                    }                                    
                                }                                

                                SqlConnection sql = new SqlConnection(Properties.Settings.Default.dbDatosConnectionString);

                                foreach (string nSuc in sucs)
                                {
                                    foreach (Prod prod in prods)
                                    {
                                        string vCadena = $"INSERT INTO dbM.dbo.Ofertas_Balanza" +
                                            $"(Fecha, CodProd, Descripcion, Grupo, Pesable, Precio, Multi, Final, Guardado, Suc)" +
                                            $" VALUES" +
                                            $"('{fechaHora.ToString("MM/dd/yyy H:mm")}', {prod.Cod}, '{prod.Descripcion}', " +
                                            $"ISNULL((SELECT ISNULL(Grupo, 0) FROM dbM.dbo.Productos WHERE CodDeProd={prod.Cod}), 0), " +
                                            $"ISNULL((SELECT ISNULL(Pesable, 1) FROM dbM.dbo.ProdAlias_Balanza WHERE Balanza={prod.Cod}), 1), " +
                                            $"{prod.Precio.ToString().Replace(",", ".")}, " +
                                            $"ISNULL((SELECT ISNULL(Multiplicador, 1) FROM dbM.dbo.ProdAlias_Balanza WHERE Balanza={prod.Cod}), 1), " +
                                            $"({prod.Precio.ToString().Replace(",", ".")}/" +
                                            $"ISNULL((SELECT ISNULL(Multiplicador, 1) FROM dbM.dbo.ProdAlias_Balanza WHERE Balanza={prod.Cod}), 1)), " +
                                            $"0, {nSuc})";
                                        SqlCommand command = new SqlCommand(vCadena, sql);
                                        command.CommandType = CommandType.Text;
                                        command.Connection = sql;
                                        sql.Open();

                                        try
                                        {
                                            var d = command.ExecuteNonQuery();
                                        }
                                        catch (SqlException er)
                                        {
                                            label1.Text = $"{label1.Text}\rException caught: {er.Message}";
                                        }

                                        sql.Close();
                                    }
                                }
                            }
                            else

                            {
                                //TODO: Avisar que hubo un error
                            }
                        }
                        //TODO: Responder para confirmar operación.
                        item.UnRead = false;
                    }
                    
                    if (n == 10)
                    {
                        break;
                    }
                    else
                    {
                        n++;
                    }
                }
                label1.Text = "Leido";
            }

            //Error handler.
            catch (System.Exception ex)
            {
                label1.Text = $"{label1.Text}\rException caught: {ex.Message}";
            }
        }

        private void tiMail_Tick(object sender, EventArgs e)
        {
            cmdActualizar.PerformClick();
        }
    }
}
