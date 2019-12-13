namespace Programa1.Carga.Empleados
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    public partial class frmRetiros : Form
    {
        private Retiros retiros = new Retiros();
        private Sueldos sueldos = new Sueldos();

        private Byte c_Mes, c_IdEmp, c_IdSuc, c_SaldoAnt, c_Sueldo, c_Adelanto, c_D7, c_D14, c_D21, c_Resto, c_Franco, c_Bono, c_Vacas, c_Desc, c_Ajustes
            , c_Saldo, c_SaldoVacas, c_Dia, c_Aguinaldo, c_SaldoAg;

        private void CmdExcel_Click(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F2}");
        }

        private DateTime v_Mes;

        public frmRetiros()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 113, 123 };
            grdRetiros.TeclasManejadas = n;

            DateTime d = new DateTime(2000, 1, 1);
            grdRetiros.MostrarDatos(retiros.Datos_Mes(d, 0), true, false);
            c_Mes = Convert.ToByte(grdRetiros.get_ColIndex("Mes"));
            c_IdEmp = Convert.ToByte(grdRetiros.get_ColIndex("Id_Empleados"));
            c_IdSuc = Convert.ToByte(grdRetiros.get_ColIndex("Id_Sucursales"));
            c_SaldoAnt = Convert.ToByte(grdRetiros.get_ColIndex("Saldo_Ant"));
            c_Sueldo = Convert.ToByte(grdRetiros.get_ColIndex("Sueldo_Mes"));
            c_Adelanto = Convert.ToByte(grdRetiros.get_ColIndex("Adelanto"));
            c_D7 = Convert.ToByte(grdRetiros.get_ColIndex("D7"));
            c_D14 = Convert.ToByte(grdRetiros.get_ColIndex("D14"));
            c_D21 = Convert.ToByte(grdRetiros.get_ColIndex("D21"));
            c_Resto = Convert.ToByte(grdRetiros.get_ColIndex("Resto"));
            c_Franco = Convert.ToByte(grdRetiros.get_ColIndex("Franco"));
            c_Bono = Convert.ToByte(grdRetiros.get_ColIndex("Bono"));
            c_Vacas = Convert.ToByte(grdRetiros.get_ColIndex("Vacas"));
            c_Desc = Convert.ToByte(grdRetiros.get_ColIndex("Descuento"));
            c_Ajustes = Convert.ToByte(grdRetiros.get_ColIndex("Ajustes"));
            c_Saldo = Convert.ToByte(grdRetiros.get_ColIndex("Saldo"));
            c_SaldoVacas = Convert.ToByte(grdRetiros.get_ColIndex("Saldo_Vc"));
            c_Dia = Convert.ToByte(grdRetiros.get_ColIndex("Dia"));
            c_Aguinaldo = Convert.ToByte(grdRetiros.get_ColIndex("Aguinaldo"));
            c_SaldoAg = Convert.ToByte(grdRetiros.get_ColIndex("Saldo_Ag"));

            grdRetiros.set_ColW(c_Mes, 0);
            grdRetiros.set_ColW(c_IdEmp, 0);
            grdRetiros.set_ColW(c_IdEmp + 1, 120);
            grdRetiros.set_ColW(c_IdSuc, 40);
            grdRetiros.set_ColW(c_SaldoAnt, 50);
            grdRetiros.set_ColW(c_Aguinaldo, 60);
            grdRetiros.set_ColW(c_SaldoAg, 60);

            for (int i = c_SaldoAnt; i < c_SaldoAg; i++)
            {
                grdRetiros.Columnas[i].Format = "#,###.#";
                grdRetiros.set_ColW(i, 60);
            }
            grdRetiros.Columnas[c_Aguinaldo].Format = "N1";
            grdRetiros.Columnas[c_SaldoAg].Format = "N1";
            grdRetiros.Columnas[c_Dia].Format = "N0";
            grdRetiros.set_ColW(c_SaldoVacas, 50);
            grdRetiros.set_ColW(c_Dia, 50);

            grdRetiros.Columnas[c_Adelanto].Style.ForeColor = Color.DarkBlue;
            grdRetiros.Columnas[c_Adelanto].Style.Font = new Font("Arial", 8, FontStyle.Bold);

            d = DateTime.Now;
            for (int i = 1; i < 30; i++)
            {
                if (d.Date > DateTime.Parse("1/12/2018"))
                {
                    lstMes.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(d.ToString("MMM yy")));
                    d = d.AddMonths(-1);
                }
            }
        }


        private void GrdRetiros_CambioFila(short Fila)
        {
            retiros.Empleado.Id = Convert.ToInt32(grdRetiros.get_Texto(Fila, c_IdEmp));
            retiros.Sucursal.Id = Convert.ToInt32(grdRetiros.get_Texto(Fila, c_IdSuc));
            retiros.Fecha = v_Mes;
            sueldos.Empleado = retiros.Empleado;
            sueldos.Fecha = v_Mes;

        }
        private void GrdRetiros_Editado(short f, short c, object a)
        {
            if (Convert.ToInt32(grdRetiros.get_Texto(f, c_IdEmp)) != retiros.Empleado.Id) { retiros.Empleado.Id = Convert.ToInt32(grdRetiros.get_Texto(f, c_IdEmp)); }
            if (c == c_IdSuc)
            {
                retiros.Empleado.Existe();
                retiros.Empleado.Sucursal.Id = Convert.ToInt32(a);
                if (retiros.Empleado.Sucursal.Existe() == false)
                {
                    MessageBox.Show("No se encontró la sucursal Nº " + a);
                    grdRetiros.ErrorEnTxt();
                }
                else
                {
                    retiros.Empleado.Actualizar();
                    grdRetiros.set_Texto(f, c, a);
                    grdRetiros.ActivarCelda(f, c + 1);
                }

            }
            if (c == c_Sueldo)
            {
                sueldos.Sueldo = Convert.ToSingle(a);
                sueldos.Tipo.Id = 1;
                sueldos.Actualizar();

                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
            if (c == c_Adelanto)
            {
                sueldos.Sueldo = Convert.ToSingle(a);
                sueldos.Tipo.Id = 2;
                sueldos.Actualizar();

                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
            if (c == c_D7)
            {
                retiros.Fecha = v_Mes.AddDays(6);
                retiros.Importe = Convert.ToSingle(a);
                retiros.Tipo.Id = 100;
                retiros.Borrar();
                retiros.Actualizar();
                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
            if (c == c_D14)
            {
                retiros.Fecha = v_Mes.AddDays(13);
                retiros.Importe = Convert.ToSingle(a);
                retiros.Tipo.Id = 100;
                retiros.Borrar();
                retiros.Actualizar();
                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
            if (c == c_D21)
            {
                retiros.Fecha = v_Mes.AddDays(20);
                retiros.Importe = Convert.ToSingle(a);
                retiros.Tipo.Id = 100;
                retiros.Borrar();
                retiros.Actualizar();
                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
            if (c == c_Resto)
            {
                retiros.Fecha = dtResto.Value;
                retiros.Importe = Convert.ToSingle(a);
                retiros.Tipo.Id = 1;
                retiros.Borrar();
                retiros.Actualizar();
                grdRetiros.set_Texto(f, c, a);
                Saldo(f);

                grdRetiros.ActivarCelda(f + 1, c);
            }
        }

        private void grdRetiros_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt16(Keys.F2))
            {
                if (grdRetiros.Col == c_IdEmp + 1)
                {
                    frmEmpleado fr = new frmEmpleado();
                    fr.Cargar(retiros.Empleado);
                    fr.ShowDialog();
                    this.Focus();
                }
                else
                {
                    if (grdRetiros.Col == c_D7)
                    {
                        frmRetiros_Detalle fr = new frmRetiros_Detalle();
                        fr.grdRetiros = grdRetiros;
                        fr.retiros = this.retiros;
                        fr.retiros.Fecha = v_Mes.AddDays(6);
                        fr.retiros.Tipo.Id = 100;
                        fr.Cargar();
                        fr.ShowDialog();
                        this.Focus();
                    }
                    else
                    {
                        if (grdRetiros.Col == c_D14)
                        {
                            frmRetiros_Detalle fr = new frmRetiros_Detalle();
                            fr.grdRetiros = grdRetiros;
                            fr.retiros = this.retiros;
                            fr.retiros.Fecha = v_Mes.AddDays(13);
                            fr.retiros.Tipo.Id = 100;
                            fr.Cargar();
                            fr.ShowDialog();
                            this.Focus();
                        }
                        else
                        {
                            if (grdRetiros.Col == c_D21)
                            {
                                frmRetiros_Detalle fr = new frmRetiros_Detalle();
                                fr.grdRetiros = grdRetiros;
                                fr.retiros = this.retiros;
                                fr.retiros.Fecha = v_Mes.AddDays(20);
                                fr.retiros.Tipo.Id = 100;
                                fr.Cargar();
                                fr.ShowDialog();
                                this.Focus();
                            }
                            else
                            {
                                if (grdRetiros.Col == c_Resto)
                                {
                                    frmRetiros_Detalle fr = new frmRetiros_Detalle();
                                    fr.grdRetiros = grdRetiros;
                                    fr.retiros = this.retiros;
                                    fr.retiros.Fecha = v_Mes.AddDays(26);
                                    fr.retiros.Tipo.Id = 1;
                                    fr.Cargar();
                                    fr.ShowDialog();
                                    this.Focus();
                                }
                                else
                                {
                                    if (grdRetiros.Col == c_Franco)
                                    {
                                        frmDetalle_Varios fr = new frmDetalle_Varios();
                                        fr.grdRetiros = grdRetiros;
                                        fr.retiros = this.retiros;
                                        fr.retiros.Fecha = v_Mes;
                                        fr.retiros.Tipo.Id = 2;
                                        fr.Cargar();
                                        fr.ShowDialog();
                                        this.Focus();
                                    }
                                    else
                                    {
                                        if (grdRetiros.Col == c_Desc)
                                        {
                                            frmDetalle_Varios fr = new frmDetalle_Varios();
                                            fr.grdRetiros = grdRetiros;
                                            fr.retiros = this.retiros;
                                            fr.retiros.Fecha = v_Mes;
                                            fr.retiros.Tipo.Id = 6;
                                            fr.Cargar();
                                            fr.ShowDialog();
                                            this.Focus();
                                        }
                                        else
                                        {
                                            if (grdRetiros.Col == c_Bono)
                                            {
                                                frmDetalle_Varios fr = new frmDetalle_Varios();
                                                fr.grdRetiros = grdRetiros;
                                                fr.retiros = this.retiros;
                                                fr.retiros.Fecha = v_Mes;
                                                fr.retiros.Tipo.Id = 11;
                                                fr.Cargar();
                                                fr.ShowDialog();
                                                this.Focus();
                                            }
                                            else
                                            {
                                                if (grdRetiros.Col == c_Aguinaldo)
                                                {
                                                    frmRetiros_Aguinaldo fr = new frmRetiros_Aguinaldo();
                                                    fr.grdRetiros = grdRetiros;
                                                    fr.retiros = this.retiros;
                                                    fr.retiros.Fecha = v_Mes;
                                                    fr.Cargar();
                                                    fr.ShowDialog();
                                                    this.Focus();
                                                }
                                                else
                                                {
                                                    if (grdRetiros.Col == c_Vacas)
                                                    {
                                                        frmRetiros_Vacaciones fr = new frmRetiros_Vacaciones();
                                                        fr.grdRetiros = grdRetiros;
                                                        fr.retiros = this.retiros;
                                                        fr.retiros.Fecha = v_Mes;
                                                        fr.Cargar();
                                                        fr.ShowDialog();
                                                        this.Focus();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (e == Convert.ToInt16(Keys.Delete))
                {
                    if (grdRetiros.Col == c_Sueldo)
                    {
                        sueldos.Fecha = v_Mes;
                        sueldos.Tipo.Id = 1;
                        sueldos.Borrar();
                        grdRetiros.set_Texto(-1, -1, 0);
                        Saldo(grdRetiros.Row);
                    }
                    else
                    {
                        if (grdRetiros.Col == c_Adelanto)
                        {
                            sueldos.Fecha = v_Mes;
                            sueldos.Tipo.Id = 2;
                            sueldos.Borrar();
                            grdRetiros.set_Texto(-1, -1, 0);
                            Saldo(grdRetiros.Row);
                        }
                        else
                        {
                            if (grdRetiros.Col == c_D7)
                            {
                                retiros.Fecha = v_Mes.AddDays(6);
                                retiros.Tipo.Id = 100;
                                retiros.Borrar();
                                grdRetiros.set_Texto(-1, -1, 0);
                                Saldo(grdRetiros.Row);
                            }
                            else
                            {
                                if (grdRetiros.Col == c_D14)
                                {
                                    retiros.Fecha = v_Mes.AddDays(13);
                                    retiros.Tipo.Id = 100;
                                    retiros.Borrar();
                                    grdRetiros.set_Texto(-1, -1, 0);
                                    Saldo(grdRetiros.Row);
                                }
                                else
                                {
                                    if (grdRetiros.Col == c_D21)
                                    {
                                        retiros.Fecha = v_Mes.AddDays(20);
                                        retiros.Tipo.Id = 100;
                                        retiros.Borrar();
                                        grdRetiros.set_Texto(-1, -1, 0);
                                        Saldo(grdRetiros.Row);
                                    }
                                    else
                                    {
                                        if (grdRetiros.Col == c_Resto)
                                        {
                                            retiros.Fecha = v_Mes.AddDays(28);
                                            retiros.Tipo.Id = 1;
                                            retiros.Borrar();
                                            grdRetiros.set_Texto(-1, -1, 0);
                                            Saldo(grdRetiros.Row);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;

            v_Mes = DateTime.Parse($"1/{DateTime.Today.Month}/{DateTime.Today.Year}");
            v_Mes = v_Mes.AddMonths(lstMes.SelectedIndex * -1);
            dtResto.Value = v_Mes.AddMonths(1).AddDays(3);

            this.Text = v_Mes.ToString("MMMM yyy");
            this.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.Text);
            grdRetiros.MostrarDatos(retiros.Datos_Mes(v_Mes, cSuc.Valor_Actual));

            for (int i = 1; i < grdRetiros.Rows; i++)
            {
                Saldo(i);
            }
            this.Cursor = Cursors.Default;
        }

        private void Saldo(int fila)
        {
            //Calcular
            Single saldo = Convert.ToSingle(grdRetiros.get_Texto(fila, c_SaldoAnt));
            saldo += Convert.ToSingle(grdRetiros.get_Texto(fila, c_Sueldo));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_D7));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_D14));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_D21));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_Resto));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_Desc));
            saldo += Convert.ToSingle(grdRetiros.get_Texto(fila, c_Franco));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_Ajustes));
            saldo -= Convert.ToSingle(grdRetiros.get_Texto(fila, c_Vacas));

            grdRetiros.set_Texto(fila, c_Saldo, saldo);


            //Guardar
            retiros.Actualizar_Saldo(saldo);

            //Pintar
            grdRetiros.set_ColorLetraCelda(fila, c_D7, Color.Black);
            grdRetiros.set_ColorLetraCelda(fila, c_D14, Color.Black);
            grdRetiros.set_ColorLetraCelda(fila, c_D21, Color.Black);

            Single va = Convert.ToSingle(grdRetiros.get_Texto(fila, c_Adelanto));
            Single dn = Convert.ToSingle(grdRetiros.get_Texto(fila, c_D7));
            if (dn < va)
            {
                grdRetiros.set_ColorLetraCelda(fila, c_D7, Color.Blue);
            }
            else
            {
                if (dn > va)
                {
                    grdRetiros.set_ColorLetraCelda(fila, c_D7, Color.Red);
                }
            }
            dn = Convert.ToSingle(grdRetiros.get_Texto(fila, c_D14));
            if (dn < va)
            {
                grdRetiros.set_ColorLetraCelda(fila, c_D14, Color.Blue);
            }
            else
            {
                if (dn > va)
                {
                    grdRetiros.set_ColorLetraCelda(fila, c_D14, Color.Red);
                }
            }
            dn = Convert.ToSingle(grdRetiros.get_Texto(fila, c_D21));
            if (dn < va)
            {
                grdRetiros.set_ColorLetraCelda(fila, c_D21, Color.Blue);
            }
            else
            {
                if (dn > va)
                {
                    grdRetiros.set_ColorLetraCelda(fila, c_D21, Color.Red);
                }
            }
            dn = Convert.ToSingle(grdRetiros.get_Texto(fila, c_Saldo));
            if (dn > 0)
            {
                grdRetiros.set_ColorLetraCelda(fila, c_Saldo, Color.Blue);
            }
            else
            {
                if (dn < 0)
                {
                    grdRetiros.set_ColorLetraCelda(fila, c_Saldo, Color.Red);
                }
            }


        }

        private void LstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void CSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
