using InsertNbp.NbpApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.NbpApi.Models.Responses
{
    /// <summary>
    /// Kurs waluty dla tabel kursów średnich A oraz B
    /// </summary>
    public class MidExchangeRate : CurrencyRateBase, IRateForTablesAB
    {        

        [JsonProperty("mid")]
        public double Mid { get; set; }
    }
}
