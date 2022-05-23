using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Interfaces
{
    public interface ICurrencyBidAskRate : ICurrencyRate
    {
        double? Bid { get; set; }

        double? Ask { get; set; }
    }
}
