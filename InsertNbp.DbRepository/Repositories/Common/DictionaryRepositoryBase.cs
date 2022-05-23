using InsertNbp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.DbRepository.Repositories.Common
{
    public class DictionaryRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : EntityDictionary
    {
        public DictionaryRepositoryBase(InsertNbpDbContext dbContext) : base(dbContext)
        {
        }

        public TEntity FindForKey(string key)
        {
            ArgumentNullException.ThrowIfNull(key);

            return GetQueryable().Where(x => x.Key.Contains(key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}
