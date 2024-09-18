namespace Programa1.Carga.Tesoreria
{

    using Newtonsoft.Json.Linq;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    public partial class Prueba_MP : Form
    {
        private const string AccessToken = "APP_USR-4081926433567985-082312-761234bf819ecdcf6985026856bd974f-1926589115"; // Reemplaza con tu token
        //MOLLEDA //"APP_USR-4081926433567985-082312-761234bf819ecdcf6985026856bd974f-1926589115";
        //MEAT //"APP_USR-1511930950766458-081613-a6fb8b3c99d243e0de8cf6b578caf41d-1854218120";
        private Leer_Tarjetas leer;

        public Prueba_MP()
        {
            InitializeComponent();
            leer = new Leer_Tarjetas();
        }

        private async void btnObtenerVentas_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var today = DateTime.UtcNow.Date;
                string beginDate = Convert.ToDateTime("6/9/2024").ToString("yyyy-MM-ddTHH:mm:ssZ");
                string endDate = Convert.ToDateTime("9/9/2024").ToString("yyyy-MM-ddTHH:mm:ssZ");
                int offset = 0;

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process,cancelled,refunded,charged_back");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    JObject ventas = JObject.Parse(responseData);
                    StringBuilder sb = new StringBuilder();

                    foreach (var venta in ventas["results"])
                    {
                        string id = venta["id"]?.ToString();
                        string status = venta["pos_id"]?.ToString();
                        string statusDetail = venta["status_detail"]?.ToString();
                        string fechaHora = venta["date_created"]?.ToString();
                        string monto = venta["transaction_amount"]?.ToString();
                        string currency = venta["currency_id"]?.ToString();
                        string paymentMethod = venta["payment_method_id"]?.ToString();

                        var payer = venta["payer"];
                        string payerEmail = payer?["email"]?.ToString();
                        string payerFirstName = payer?["first_name"]?.ToString();
                        string payerLastName = payer?["last_name"]?.ToString();

                        var poi = venta["point_of_interaction"];
                        var device = poi["device"];

                        string serial_number;

                        if (device == null)
                        { serial_number = "N/A"; }
                        else { serial_number = device["serial_number"]?.ToString().Substring(8) ?? "N/A"; }

                        

                        sb.AppendLine($"ID: {id}");
                        sb.AppendLine($"pos_id: {status}");
                        sb.AppendLine($"Detalle del Estado: {statusDetail}");
                        sb.AppendLine($"Fecha y Hora: {fechaHora}");
                        sb.AppendLine($"Monto: {monto} {currency}");
                        sb.AppendLine($"serial_number: {serial_number}");
                        sb.AppendLine($"Método de Pago: {paymentMethod}");
                        sb.AppendLine($"Email del Comprador: {payerEmail}");
                        sb.AppendLine($"Nombre del Comprador: {payerFirstName} {payerLastName}");
                        sb.AppendLine($"Suc: {leer.suc_cuentas.buscar_suc(Convert.ToInt32(device["serial_number"]?.ToString().Substring(8) ?? "N/A"))}");
                        sb.AppendLine("-----------");
                    }
                    var paging = ventas["paging"];
                    paging = paging["total"];


                    textBox1.Text = sb.ToString();
                }
                else
                {
                    MessageBox.Show("Error al obtener las ventas: " + response.StatusCode);
                }
            }
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            btnObtenerVentas_Click((object) sender, e);
        }
    }
}