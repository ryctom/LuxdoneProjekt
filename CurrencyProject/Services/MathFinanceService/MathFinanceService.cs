using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyProject.Services.MathFinanceService
{
    public class MathFinanceService : IMathFinanceService
    {
        public decimal GetAverage(IEnumerable<decimal?> data)
        {
            return data.Average().GetValueOrDefault();
        }

        public decimal GetStandardDerivation(IEnumerable<decimal?> data)
        {
            var average = data.Average().GetValueOrDefault();

            var sumOfSquaresOfDifferences = data.Select(val => (val - average) * (val - average)).Sum();

            return (decimal)Math.Sqrt((double)sumOfSquaresOfDifferences / data.Count());
        }
    }
}
