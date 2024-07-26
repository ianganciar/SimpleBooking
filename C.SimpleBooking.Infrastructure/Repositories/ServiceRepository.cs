using D.SimpleBooking.Domain.Entities;
using D.SimpleBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.SimpleBooking.Infrastructure.Repositories;
public class ServiceRepository : IServiceRepository
{
    public Task CreateAsync(Service service)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Service>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Service> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Service service)
    {
        throw new NotImplementedException();
    }
}
