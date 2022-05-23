namespace InsertNbp.Commands.Interfaces
{
    public interface ICurrencyService
    {
        Task AddRange(List<Domain.Entities.Currency> currencies);

        List<Domain.Entities.Currency> GetAll();
    }
}