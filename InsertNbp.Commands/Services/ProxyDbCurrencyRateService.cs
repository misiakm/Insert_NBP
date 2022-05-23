using InsertNbp.Commands.Currency;
using InsertNbp.Commands.Interfaces;
using InsertNbp.DbRepository.Repositories;
using InsertNbp.NbpApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.Commands.Services
{
    public class ProxyDbCurrencyRateService : ICurrencyRateService
    {
        private readonly CurrencyRateRepository _currencyRateRepository;
        private readonly ICurrencyRateService _currencyRateService;
        private readonly CurrencyService _currencyService;

        public ProxyDbCurrencyRateService(CurrencyRateRepository currencyRateRepository, CurrencyRateService currencyRateService, CurrencyService currencyService)
        {
            _currencyRateRepository = currencyRateRepository;
            _currencyRateService = currencyRateService;
            _currencyService = currencyService;
        }

        public async Task<List<CurrencyRate>> GetCurrencyRates(DateTime? date = null)
        {
            date ??= DateTime.Now.Date;
            List<Domain.Entities.CurrencyRate> currencyRates = _currencyRateRepository
                .GetQueryable()
                .Include(x => x.Currency)
                .Where(x => x.CurrencyDateRate == date)
                .ToList();

            if (currencyRates.Any())
            {
                return currencyRates.Select(x => new CurrencyRate()
                {
                    Name = x.Currency.Name,
                    Ask = x.Ask,
                    Bid = x.Bid,
                    Code = x.Currency.Code,
                    Mid = x.Mid
                }).ToList();
            }

            List<CurrencyRate> result = await _currencyRateService.GetCurrencyRates(date);
            List<Domain.Entities.Currency> currencies = result.Select(curr => new Domain.Entities.Currency()
            {
                Code = curr.Code,
                Name = curr.Name
            }).ToList();
            await _currencyService.AddRange(currencies);
            currencies = _currencyService.GetAll();
            await _currencyRateRepository.AddRangeAsync(result.Select(rate => new Domain.Entities.CurrencyRate()
            {
                Currency = currencies.FirstOrDefault(curr => curr.Code.Equals(rate.Code)),
                CurrencyDateRate = date.Value,
                Ask = rate.Ask,
                Bid = rate.Bid,
                Mid = rate.Mid
            }));

            return result;
        }
    }
}
