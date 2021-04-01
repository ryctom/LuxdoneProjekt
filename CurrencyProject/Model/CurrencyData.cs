using System;

namespace CurrencyProject.Model
{
    public class CurrencyData
    {
        public string Code { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public decimal? Bid { get; set; }

        public decimal? Ask { get; set; }
    }
}