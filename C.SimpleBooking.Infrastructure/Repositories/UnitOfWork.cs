using C.SimpleBooking.Infrastructure.Persistence;
using D.SimpleBooking.Domain.Repositories;

namespace C.SimpleBooking.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SimpleBookingDbContext _dbContext;
    private readonly bool _disposed;

    public UnitOfWork(SimpleBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
      return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _dbContext.Dispose();
        }

    }
}
