using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Interfaces
{
    public interface ICurrency<T> : IDictionary where T : ICurrencyRate
    {
        string Code { get; set; }
        IEnumerable<T> CurrencyRates { get; }
    }
}
