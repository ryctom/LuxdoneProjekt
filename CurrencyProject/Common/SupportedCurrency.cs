using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyProject.Common
{
    public static class SupportedCurrency
    {
        private static List<string> AllowedCurrency = new List<string>()
        {
            "USD",
            "EUR",
            "CHR",
            "GBP"
        };

        public static bool IsCurrencySupported (string currency)
        {
           return AllowedCurrency
                .FirstOrDefault(curr => curr.Equals(currency, StringComparison.InvariantCultureIgnoreCase)) != null;
        }
    }
}
