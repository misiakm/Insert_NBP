using InsertNbp.Commands.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Commands.Interfaces
{
    public interface ICurrencyRateService
    {
        Task<List<CurrencyRate>> GetCurrencyRates(DateTime? date = null);
    }
}
