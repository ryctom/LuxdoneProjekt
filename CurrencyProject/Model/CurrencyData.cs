using System;

namespace CurrencyProject.Model
{
    public class CurrencyData
    {
        public string Code { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal? Mid { get; set; }
    }
}