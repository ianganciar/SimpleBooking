using D.SimpleBooking.Domain.Entities;

namespace D.SimpleBooking.Domain.Repositories;
public interface IServiceRepository
{
    Task CreateAsync(Service service);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, Service service);
    Task<Service> GetByIdAsync(int id);
    Task<List<Service>> GetAllAsync();
      
}
