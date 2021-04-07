using CurrencyProject.Model;
using CurrencyProject.Parameters;
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
      
        public CurrencyController(
            ICurrencyService infoService)
        {
            _infoService = infoService;          
        }

        [HttpGet("{Code}/{StartDate}/{EndDate}")]
        public async Task<CurrencySummary> Get([FromRoute] CurrencyQueryParameter query)
        {           
            return await _infoService.GetCurrencyBeetweenDatesAsync(query.Code, query.StartDate, query.EndDate);
        }
    }
}
