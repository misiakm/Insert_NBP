using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Commands.Currency
{
    public class CurrencyRate
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }
    }
}
