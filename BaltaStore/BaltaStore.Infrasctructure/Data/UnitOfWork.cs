using BaltaStore.Domain.Abstractions;

namespace BaltaStore.Infrasctructure.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
