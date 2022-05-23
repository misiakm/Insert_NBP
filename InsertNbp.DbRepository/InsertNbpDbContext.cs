using InsertNbp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsertNbp.DbRepository
{
    /// <summary>
    /// Context do łączenia się z bazą danych
    /// </summary>
    public class InsertNbpDbContext : DbContext
    {
        public InsertNbpDbContext(DbContextOptions<InsertNbpDbContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
    }
}