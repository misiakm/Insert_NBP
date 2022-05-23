using InsertNbp.DbRepository.Repositories;
using Entites = InsertNbp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsertNbp.Commands.Interfaces;

namespace InsertNbp.Commands.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencyRepository _currencyRepository;

        public CurrencyService(CurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
        }

        public async Task AddRange(List<Entites.Currency> currencies)
        {
            List<Entites.Currency> currenciesFromDb = _currencyRepository.GetQueryable().ToList();
            List<Entites.Currency> toAdded = currencies.Where(x => !currenciesFromDb.Select(y => y.Name).Contains(x.Name)).ToList();
            await _currencyRepository.AddRangeAsync(toAdded);
        }

        public List<Entites.Currency> GetAll()
        {
            return _currencyRepository.GetAll();
        }
    }
}
