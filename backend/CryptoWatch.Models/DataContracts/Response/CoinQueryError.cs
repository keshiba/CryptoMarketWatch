using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoWatch.Models.DataContracts.Response
{
    public class CoinQueryError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        public CoinQueryError(string error)
        {
            this.Error = error;
        }
    }
}
