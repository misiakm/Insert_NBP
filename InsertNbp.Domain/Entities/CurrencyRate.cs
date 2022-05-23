using InsertNbp.Domain.Entities.Common;
using InsertNbp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Domain.Entities
{
    /// <summary>
    /// Klasa przechowująca waluty
    /// </summary>
    public class CurrencyRate : Entity, ICurrencyMidRate, ICurrencyBidAskRate, ICurrencyRate
    {
        public virtual Currency Currency { get; set; }

        [Column(TypeName = "date")]
        public DateTime CurrencyDateRate { get; set; }
        public double Mid { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }
    }
}
