using InsertNbp.Domain.Entities.Common;
using InsertNbp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Entities
{
    /// <summary>
    /// Słownik walut
    /// </summary>
    public class Currency : EntityDictionary, ICurrency<CurrencyRate>
    {
        public string Code { get; set; }
        public virtual IEnumerable<CurrencyRate> CurrencyRates { get; private set; }
    }
}
