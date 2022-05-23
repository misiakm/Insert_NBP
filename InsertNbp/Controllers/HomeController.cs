using InsertNbp.Commands.Interfaces;
using InsertNbp.Commands.Services;
using InsertNbp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsertNbp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyRateService _currencyRateService;

        public HomeController(ILogger<HomeController> logger, ProxyCacheCurrencyRateService currencyRateService)
        {
            _logger = logger;
            _currencyRateService = currencyRateService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute]DateTime? date)
        {
            try
            {
                ViewBag.Date = date;
                List<Commands.Currency.CurrencyRate> currencyRates = await _currencyRateService.GetCurrencyRates(date);

                List<CurrencyRateModel> model = currencyRates
                    .Select(rate => new CurrencyRateModel()
                    {
                        Currency = rate.Name,
                        Ask = rate.Ask,
                        Bid = rate.Bid,
                        Code = rate.Code,
                        Mid = rate.Mid
                    })
                    .OrderBy(x => x.Currency)
                    .ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}