using InsertNbp.Commands.Currency;
using InsertNbp.Commands.Interfaces;
using NBP = InsertNbp.NbpApi;

namespace InsertNbp.Commands.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly NBP.NbpService _nbpService;

        public CurrencyRateService(NBP.NbpService nbpService)
        {
            _nbpService = nbpService;
        }
        public async Task<List<CurrencyRate>> GetCurrencyRates(DateTime? date)
        {
            List<NBP.Models.Rate> rates = await _nbpService.GetRatesAsync(date);
            return rates.Select(x => new CurrencyRate()
            {
                Ask = x.Ask,
                Bid = x.Bid,
                Code = x.Code,
                Mid = x.Mid,
                Name = x.Currency
            }).ToList();
        }
    }
}