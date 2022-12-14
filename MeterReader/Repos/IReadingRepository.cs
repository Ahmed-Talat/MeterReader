using MeterReader.Entities;

namespace MeterReader.Repos;

public interface IReadingRepository
{
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<IEnumerable<Customer>> GetCustomersWithReadingsAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<Customer> GetCustomerWithReadingsAsync(int id);

    void AddEntity<T>(T model);
    void DeleteEntity<T>(T model);
    Task<bool> SaveAllAsync();
}