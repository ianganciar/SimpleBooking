namespace D.SimpleBooking.Domain.Repositories;
public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
