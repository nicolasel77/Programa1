using System.Text.Json;

namespace Decidir.Model
{
    public class PartialRefund
    {
        public long amount { get; set; }

        public static string toJson(PartialRefund partialRefund)
        {
            return JsonSerializer.Serialize(partialRefund, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }
    }
}
