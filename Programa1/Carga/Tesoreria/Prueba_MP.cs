namespace Programa1.Carga.Tesoreria
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Net.Http;
    using System.Security.Policy;
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
            var url = "https://prod.emea.api.fiservapps.com/sandbox/exp/v1/transactions?limit=20&offset=0";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("Api-Key", "cIRaBpiUMlmivNuB0TZuYkqijWD2GGLo");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseData = await response.Content.ReadAsStringAsync();

                    var parsedJson = JToken.Parse(responseData);
                    string formattedJson = parsedJson.ToString(Formatting.Indented);

                    textBox1.Text = formattedJson;
                }
                catch (Exception ex)
                {
                    textBox1.Text = $"Error: {ex.Message}";
                }
            }

        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            btnObtenerVentas_Click((object)sender, e);
        }
    }
}