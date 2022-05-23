using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.NbpApi.Models.Responses
{
    public class Response<T> where T : CurrencyRateBase
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public string EffectiveDate { get; set; }

        [JsonProperty("rates")]
        public List<T> Rates { get; set; }
    }
}
