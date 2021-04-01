using CurrencyProject.Model;
using System.Threading.Tasks;

namespace CurrencyProject.Services.CurrencyService
{
    public interface ICurrencyService
    {
        Task<CurrencySummary> GetCurrencyBeetweenDatesAsync(string startTime, string endTime, string code);
    }
}
