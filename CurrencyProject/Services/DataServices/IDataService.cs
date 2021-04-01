using CurrencyProject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyProject.Services.DataService
{
    public interface IDataService
    {
        Task<IEnumerable<CurrencyData>> GetCurrencyBeetweenDatesAsync(string code, string startTime, string endTime);
    }
}
