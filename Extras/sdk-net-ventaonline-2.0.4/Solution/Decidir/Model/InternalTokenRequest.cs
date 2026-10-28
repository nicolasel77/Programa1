



using System.Text.Json;

namespace Decidir.Model
{
    public class InternalTokenRequest
    {
        public CardDataInternalToken card_data { get; set; }
        public string entry_mode { get; set; }
        public string establishment_number { get; set; }

        public static string toJson(InternalTokenRequest token)
        {
            return JsonSerializer.Serialize(token, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }
    }
}
