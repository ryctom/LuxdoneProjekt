using CurrencyProject.Model;
using CurrencyProject.Services.CurrencyService;
using CurrencyProject.Services.Validaton;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _infoService;
        private readonly IValidation _validation;

        public CurrencyController(
            ICurrencyService infoService,
            IValidation validation
            )
        {
            _infoService = infoService;
            _validation = validation;
        }

        [HttpGet("{code}/{startDate}/{endDate}")]
        public async Task<CurrencySummary> Get(string code, string startDate, string endDate)
        {
            _validation.Validate(code, startDate, endDate);

            return await _infoService.GetCurrencyBeetweenDatesAsync(code, startDate, endDate);
        }
    }
}
