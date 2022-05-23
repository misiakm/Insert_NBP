using InsertNbp.NbpApi.Interfaces;
using InsertNbp.NbpApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.NbpApi.Models
{
    public class Rate : CurrencyRateBase, IRateForTableC, IRateForTablesAB
    {
        public double Mid { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }
    }
}
