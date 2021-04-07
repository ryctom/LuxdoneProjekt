﻿using CurrencyProject.Model;
using CurrencyProject.Services.DataService;
using CurrencyProject.Services.MathFinanceService;
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

        public async Task<CurrencySummary> GetCurrencyBeetweenDatesAsync(string code, string startTime, string endTime)
        {
            var listOfCurrency = await _dataService.GetCurrencyBeetweenDatesAsync(code, startTime, endTime);

            var bids = listOfCurrency.Select(item => item.Bid);
            var asks = listOfCurrency.Select(item => item.Ask);

            return new CurrencySummary
            {
                AveragePrice = _mathFinanceService.GetAverage(bids),
                StandardDerivation = _mathFinanceService.GetStandardDerivation(asks)
            };
        }
    }
}
