using System.Collections.Generic;

namespace CurrencyProject.Services.MathFinanceService
{
    public interface IMathFinanceService
    {
        decimal GetAverage(IEnumerable<decimal?> data);
        decimal GetStandardDerivation(IEnumerable<decimal?> data);
    }
}