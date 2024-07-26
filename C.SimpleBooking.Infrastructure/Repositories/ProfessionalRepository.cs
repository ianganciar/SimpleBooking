using C.SimpleBooking.Infrastructure.Persistence;
using D.SimpleBooking.Domain.Entities;
using D.SimpleBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace C.SimpleBooking.Infrastructure.Repositories;
public class ProfessionalRepository : IProfessionalRepository
{
    private readonly SimpleBookingDbContext _dbContext;

    public ProfessionalRepository(SimpleBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Professional professional)
    {
        await _dbContext.Professionals.AddAsync(professional);
    }

    public async Task DeleteAsync(int id)
    {
        var professional = await _dbContext.Professionals.FindAsync(id);

        professional?.Delete();
    }

    public async Task<Professional?> GetByIdAsync(int id)
    {
        return await _dbContext.Professionals.FindAsync(id);

    }

    public async Task<bool> HasProfessionalAsync(string email, string phone)
    {
        var hasProfessional = await _dbContext.Professionals.AnyAsync(p => p.Email.Value == email || p.Phone == phone);

        return hasProfessional;
    }

    public async Task UpdateAsync(Professional professional)
    {
        var professionalOld = await _dbContext.Professionals.FindAsync(professional.Id);

        professionalOld?.Update(professional.Name, professional.Description, professional.Address);
    }
}
