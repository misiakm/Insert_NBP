using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.NbpApi.Models.Responses
{
    public abstract class CurrencyRateBase
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
