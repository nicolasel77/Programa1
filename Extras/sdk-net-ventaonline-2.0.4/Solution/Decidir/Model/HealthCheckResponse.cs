using System.Text.Json;
using System;

namespace Decidir.Model
{
    public class HealthCheckResponse
    {
        public string name { get; set; }
        public string version { get; set; }
        public string buildTime { get; set; }

        public static string toJson(HealthCheckResponse response)
        {
            return JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        public static HealthCheckResponse toHealthCheckResponse(string json)
        {
            HealthCheckResponse data;

            try
            {
                data = JsonSerializer.Deserialize<HealthCheckResponse>(json);
            }
            catch (Exception)
            {
                data = null;
            }

            return data;
        }
    }
}
