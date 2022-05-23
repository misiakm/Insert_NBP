using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Interfaces
{
    public interface ICurrencyMidRate : ICurrencyRate
    {
        double Mid { get; set; }
    }
}
