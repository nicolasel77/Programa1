using Programa1.DB;
using Programa1.DB.Sucursales;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmPromedios : Form
    {
        public frmPromedios()
        {
            InitializeComponent();
        }

        Precios_Sucursales pr = new Precios_Sucursales();
        Promedios Promedios = new Promedios();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmPromedios_Load(object sender, EventArgs e)
        {
            h.Llenar_List(lstPromedios, Promedios.Listado());

            //    .Texto(1, 3) = 21
            //    .Texto(1, 4) = 0

            //    .Columnas(6).Format = "#0.00"

            //    ' Total
            //    ' Precio * Kilos
            //    .Texto(1, 7) = 0
            //    .Texto(2, 7) = 0
            //    .Texto(3, 7) = 0
            //    .Texto(4, 7) = 0
            //    .Texto(5, 7) = 0
            //    .Texto(6, 7) = 0
            //    .Texto(8, 7) = 0
            //    .Texto(9, 7) = 0
            //    .Texto(12, 7) = 0
            //    .Texto(13, 7) = 0
            //    .Columnas(4).Format = "$ #0.0"

            //    .AutosizeAll()
            //    .Columnas(2).DataType = GetType(Single)
            //End With
            grdPromedios.set_Texto(0, 2, "Precio");
            grdPromedios.set_Texto(0, 3, "Cant");
            grdPromedios.set_Texto(0, 6, "Kilos");
            grdPromedios.set_Texto(0, 7, "Total");
            grdPromedios.set_Texto(0, 8, "%");
            grdPromedios.set_Texto(0, 9, "Kg");
            grdPromedios.set_Texto(0, 10, "$");

            grdPromedios.set_Texto(1, 3, "21");
            grdPromedios.set_Texto(1, 4, "0");

            grdPromedios.Columnas[2].Format = "$ #0.00";
            grdPromedios.Columnas[6].Format = "#0.00";

        }

        private void lstPromedios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prod = 0;
            double kilos = 0;
            double kprom = 0;

            grdPromedios.Rows = 1;
            grdPromedios.Rows = 8;
            if (lstPromedios.SelectedIndex > -1)
            {
                DataTable dt = Promedios.Listado(h.Codigo_Seleccionado(lstPromedios.Text));

                grdPromedios.set_Texto(1, 0, dt.Rows[0]["Prod"]);
                grdPromedios.set_Texto(1, 1, dt.Rows[0]["Descripcion"]);
                grdPromedios.set_Texto(1, 3, dt.Rows[0]["Cant"]);
                grdPromedios.set_Texto(1, 5, dt.Rows[0]["KProm"]);
                grdPromedios.set_Texto(1, 4, Convert.ToDouble(dt.Rows[0]["KProm"]) * Convert.ToDouble(grdPromedios.get_Texto(1, 2)));
                grdPromedios.set_Texto(1, 6, dt.Rows[0]["Kilos"]);
                grdPromedios.set_Texto(1, 7, Convert.ToDouble(dt.Rows[0]["Kilos"]) * Convert.ToDouble(grdPromedios.get_Texto(1, 2)));

                prod = Convert.ToInt32(dt.Rows[0]["Prod"]);
                kilos = Convert.ToDouble(dt.Rows[0]["Kilos"]);
                kprom = Convert.ToDouble(dt.Rows[0]["KProm"]);
            }
            lstFechas.Items.Clear();
            pr.Producto.Id = prod;

            //Esto es solo para que se cargen los datos
            //Mas que nada el Tipo
            if (pr.Producto.Existe() == true) { }

            DataTable dtP = pr.Fechas(pr.Producto.Tipo.Id, prod);
            foreach (DataRow dr in dtP.Rows)
            {
                lstFechas.Items.Add($"{dr["Fecha"]:dd/MM/yyy}");
            }
            //    Dim sp As String = "SELECT TOP 50 Fecha FROM Precios WHERE CodProd={0} {1} ORDER BY Fecha DESC"
            //    If PreciosSuc.ValorActual <> 0 Then
            //        sp = String.Format(sp, dt.Rows(0).Item("Prod"), " AND CodSuc=" & PreciosSuc.ValorActual)
            //    Else
            //        sp = String.Format(sp, dt.Rows(0).Item("Prod"), "")
            //    End If
            //    Dim dtP As DataTable = dbPrecios.Datos(sp)
            //    If dtP.Rows.Count Then
            //        For Each dr As DataRow In dtP.Rows
            //            lstPromFechas.Items.Add(Format(dr.Item(0), "dd/MM/yy"))
            //        Next
            //    End If

            dtP = Promedios.Detalle_Promedio(h.Codigo_Seleccionado(lstPromedios.Text));
            int f = 2;
            foreach (DataRow dr in dtP.Rows)
            {
                grdPromedios.set_Texto(f, 0, dr["Prod"]);
                grdPromedios.set_Texto(f, 1, dr["Nombre"]);
                grdPromedios.set_Texto(f, 6, dr["Kilos"]);
                grdPromedios.set_Texto(f, 7, dr["Kilos"]);
                grdPromedios.set_Texto(f, 8, Convert.ToDouble(dr["Kilos"]) / kilos * 100);

                grdPromedios.Rows++;
                f++;
            }
            double tK = 0, tI = 0;
            for (int i = 2; i < f - 1; i++)
            {
                tK += Convert.ToDouble(grdPromedios.get_Texto(i, 6));
                tI += Convert.ToDouble(grdPromedios.get_Texto(i, 7));
            }

            f++;

            grdPromedios.set_Texto(f, 6, tK);
            grdPromedios.set_Texto(f, 7, tI);
            grdPromedios.set_Texto(f, 8, tK / kilos * 100);
            grdPromedios.set_Texto(f + 1, 7, tI - Convert.ToDouble(grdPromedios.get_Texto(1, 2)) * kprom);

            f += 3;

            double prom = 0;
            if (kprom != 0) { prom = tI / kprom; }

            grdPromedios.set_Texto(f, 1, "Promedio");
            grdPromedios.set_Texto(f + 1, 1, "Dif");
            grdPromedios.set_Texto(f, 7, prom);
            grdPromedios.set_Texto(f + 1, 7, prom - Convert.ToDouble(grdPromedios.get_Texto(1, 2)));

            //    If.Texto(f + 1, 7) < 0 Then
            //       .ColorCelda(f + 1, 7) = Color.LightCoral
            //    Else
            //        .ColorCelda(f + 1, 7) = Color.LightGreen
            //    End If
            //    .Columnas(4).Format = "####,###.0"
            //    .Columnas(7).Format = "$ ####,###.00"
            //    .Columnas(8).Format = "####,###.00"
            //    .AutosizeAll()
            //End If
            //End With

        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFechas.SelectedIndex > -1)
            {
                DateTime fe = Convert.ToDateTime(lstFechas.Text);
                int s = cSucs.Valor_Actual;
                
                pr.Fecha = fe;
                pr.Sucursal.Id = s;

                int f = 0;
                int i = 0;


                for (i = 1; i < grdPromedios.Rows - 7; i++)
                {
                    if (Convert.ToInt32(grdPromedios.get_Texto(i, 0)) != 0)
                    {
                        
                        pr.Producto.Id = Convert.ToInt32(grdPromedios.get_Texto(i, 0));

                        Single precio = pr.Buscar();
                        grdPromedios.set_Texto(i, 2, precio);
                        grdPromedios.set_Texto(i, 7, precio * Convert.ToDouble(grdPromedios.get_Texto(i, 6)));
                    }
                }
                f = i;
                for (i = 2; i < f - 1; i++)
                {

                }
            }

            //        Dim tK, tI As Single
            //        For i = 2 To F -1
            //            tK += .Texto(i, 6)
            //            tI += .Texto(i, 7)
            //        Next

            //        F += 1

            //        .Texto(F, 6) = tK
            //        .Texto(F, 7) = tI
            //        .Texto(f, 8) = tK / .Texto(1, 6) * 100
            //        .Texto(f + 1, 7) = tI - .Texto(1, 2) * .Texto(1, 5)

            //        f += 3
            //        Dim prom As Single

            //        If.Texto(1, 5) <> 0 Then
            //           prom = tI / .Texto(1, 5)
            //        Else
            //            If.Texto(1, 6) <> 0 Then prom = tI / .Texto(1, 6)
            //        End If

            //        .Texto(F, 1) = "Promedio"
            //        .Texto(F + 1, 1) = "Dif"
            //        .Texto(F, 7) = prom
            //        .Texto(F + 1, 7) = prom - .Texto(1, 2)

            //        If.Texto(F + 1, 7) < 0 Then
            //           .ColorCelda(f + 1, 7) = Color.LightCoral
            //            If.Texto(1, 5) <> 0 Then
            //               .ColorCelda(1, 5) = Color.LightCoral
            //               .ColorCelda(1, 6) = Color.White
            //            Else
            //                .ColorCelda(1, 6) = Color.LightCoral
            //                .ColorCelda(1, 5) = Color.White
            //            End If
            //        Else
            //            .ColorCelda(f + 1, 7) = Color.LightGreen
            //            If.Texto(1, 5) <> 0 Then
            //               .ColorCelda(1, 5) = Color.LightGreen
            //               .ColorCelda(1, 6) = Color.White
            //            Else
            //                .ColorCelda(1, 6) = Color.LightGreen
            //                .ColorCelda(1, 5) = Color.White
            //            End If
            //        End If



            //        .AutosizeAll()
            //    End With
            //End If
        }
    }
}
