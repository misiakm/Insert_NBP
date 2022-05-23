using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.NbpApi.Models.Responses
{
    /// <summary>
    /// Kurs walut pobierany dla tabeli C - kursów wymiany walut
    /// </summary>
    public class BuyAndSellRate : CurrencyRateBase
    {
        [JsonProperty("bid")]
        public double? Bid { get; set; }

        [JsonProperty("ask")]
        public double? Ask { get; set; }
    }
}
