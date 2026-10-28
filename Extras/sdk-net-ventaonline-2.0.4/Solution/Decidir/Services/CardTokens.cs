using Decidir.Clients;
using Decidir.Exceptions;
using Decidir.Model;
using System.Text.Json;
using System;
using System.Collections.Generic;

namespace Decidir.Services
{
    internal class CardTokens : Service
    {
        public CardTokens(string endpoint, string privateApiKey, Dictionary<string, string> headers) : base(endpoint)
        {
            this.restClient = new RestClient(this.endpoint, headers, CONTENT_TYPE_APP_JSON);
        }

        public bool DeleteCardToken(string tokenizedCard)
        {
            bool deleted = false;
            RestResponse result = this.restClient.Delete(String.Format("cardtokens/{0}", tokenizedCard));

            if (result.StatusCode == STATUS_NOCONTENT)
            {
                deleted = true;
            }
            else
            {
                if (isErrorResponse(result.StatusCode))
                    throw new ResponseException(result.StatusCode.ToString(), JsonSerializer.Deserialize<ErrorResponse>(result.Response));
                else
                    throw new ResponseException(result.StatusCode + " - " + result.Response);
            }

            return deleted;
        }
    }
}
