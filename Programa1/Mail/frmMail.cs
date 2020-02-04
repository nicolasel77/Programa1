﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Windows.Forms;

namespace Programa1.Mail
{
    public partial class frmMail : Form
    {

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
                label1.Text = "";
                foreach (MailItem item in mailsItems)
                {
                    if (item.Subject == "BALANZA")
                    {
                        label1.Text = $"{label1.Text}\r{item.ReceivedTime.ToString()}  :  {item.Subject}";

                        //1) Fecha y Hora
                        int fe = item.Body.IndexOf("Fecha:");
                        if (fe != 0)
                        {
                            
                            //string ss = item.Body.Substring(fe + 6, 16);
                            //DateTime fecha;

                        }


                        //TODO: Responder para confirmar operación.
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
            }

            //Error handler.
            catch (System.Exception ex)
            {
                label1.Text = $"{label1.Text}\rException caught: {ex.Message}";
            }
        }


    }
}
