using CurrencyProject.Model;
using CurrencyProject.Services.DataService;
using CurrencyProject.Services.MathFinanceService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyProject.Services.CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IDataService _dataService;
        private readonly IMathFinanceService _mathFinanceService;

        public CurrencyService(
            IDataService dataService,
            IMathFinanceService mathFinanceService
            )
        {
            _dataService = dataService;
            _mathFinanceService = mathFinanceService;
        }

        public async Task<CurrencySummary> GetCurrencyBeetweenDatesAsync(string startTime, string endTime, string code)
        {
            var listOfCurrency = await _dataService.GetCurrencyBeetweenDatesAsync(startTime, endTime, code);

            var mids = listOfCurrency.Select(item => item.Mid);

            return new CurrencySummary
            {
                AveragePrice = _mathFinanceService.GetAverage(mids),
                StandardDerivation = _mathFinanceService.GetStandardDerivation(mids)
            };
        }
    }
}
