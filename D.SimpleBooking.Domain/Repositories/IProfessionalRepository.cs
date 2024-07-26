using D.SimpleBooking.Domain.Entities;

namespace D.SimpleBooking.Domain.Repositories;
public interface IProfessionalRepository
{
    Task CreateAsync(Professional professional);
    Task UpdateAsync(Professional professional);
    Task<Professional?> GetByIdAsync(int id);
    Task DeleteAsync(int id);

    Task<bool> HasProfessionalAsync(string email, string phone);


}
