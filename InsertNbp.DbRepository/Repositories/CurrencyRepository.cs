using InsertNbp.DbRepository.Repositories.Common;
using InsertNbp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.DbRepository.Repositories
{
    public class CurrencyRepository : DictionaryRepositoryBase<Currency>
    {
        public CurrencyRepository(InsertNbpDbContext dbContext) : base(dbContext)
        {
        }
    }
}
