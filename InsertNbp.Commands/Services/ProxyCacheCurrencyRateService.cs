using InsertNbp.Commands.Currency;
using InsertNbp.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Commands.Services
{
    public class ProxyCacheCurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRateService _currencyRateService;
        private static List<CurrencyRate> _currencyRates;
        private static DateTime? _lastUpdate;
        

        public ProxyCacheCurrencyRateService(ProxyDbCurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        public async Task<List<CurrencyRate>> GetCurrencyRates(DateTime? date = null)
        {
            DateTime today = DateTime.Now.Date;
            date = date?.Date ?? today;

            if (date == _lastUpdate && _currencyRates.Any())
            {
                return _currencyRates;
            }

            List<CurrencyRate> currencyRates = await _currencyRateService.GetCurrencyRates(date);

            if (date == today)
            {
                _currencyRates = currencyRates;
                _lastUpdate = date;
            }

            return currencyRates;
        }

    }
}
