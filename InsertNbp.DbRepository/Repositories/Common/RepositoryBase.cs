using InsertNbp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNbp.DbRepository.Repositories.Common
{
    public abstract class RepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly InsertNbpDbContext _dbContext;

        public RepositoryBase(InsertNbpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Dodaje nowy rekord do bazy danych
        /// </summary>
        /// <param name="value">Nowe obiekt, który zostanie dodany do bazy danych</param>
        /// <param name="skipSave">Ustawienie True powoduje, że dane nie zostaną zapisane w bazie danych</param>
        /// <returns></returns>
        public async Task<EntityEntry<TEntity>> AddAsync(TEntity value, bool skipSave = false)
        {
            ArgumentNullException.ThrowIfNull(value);
            EntityEntry<TEntity> result = await _dbContext.AddAsync(value);
            await SaveChangesAsync(skipSave);
            return result;
        }

        /// <summary>
        /// Dodaje zakres nowych rekordów do bazy danych
        /// </summary>
        /// <param name="values"></param>
        /// <param name="skipSave"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TEntity> values, bool skipSave = false)
        {
            await _dbContext.AddRangeAsync(values);
            await SaveChangesAsync(skipSave);
        }

        /// <summary>
        /// Aktualizuje rekord w bazie danych
        /// </summary>
        /// <param name="value">Obiekt, który zostanie zaktualizowany w bazie danych</param>
        /// <param name="skipSave">Ustawienie True powoduje, że dane nie zostaną zapisane w bazie danych</param>
        /// <returns></returns>
        public async Task<EntityEntry<TEntity>> UpdateAsync(TEntity value, bool skipSave = false)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            value.Updated = DateTime.UtcNow;
            EntityEntry<TEntity> result = _dbContext.Update(value);
            await SaveChangesAsync(skipSave);
            return result;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Pobiera wszystkie rekordy z bazy
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Zapisuje zmiany w bazie danych
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


        private async Task<int> SaveChangesAsync(bool skipSave)
        {
            if (!skipSave)
            {
                return await SaveChangesAsync();
            }

            return 0;
        }
    }
}
