using System;
using System.Collections.Generic;
using Decidir.Model.CyberSource;
using   System.Text.Json;

namespace Decidir.Model
{
    public class ValidateData
    {
        public SiteInfo site { get; set; }
        public ValidateCustomer customer { get; set; }
        public ValidatePayment payment { get; set; }
        public string success_url { get; set; }
        public string redirect_url { get; set; }
        public string cancel_url { get; set; }
        public FraudDetection fraud_detection { get; set; }
        public static string toJson(ValidateData validateData)
        {
            return JsonSerializer.Serialize(validateData, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }
    }
}