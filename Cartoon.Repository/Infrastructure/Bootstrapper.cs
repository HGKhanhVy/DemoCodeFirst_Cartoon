using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Cartoon.Contract.Repository.Infrastructure;

namespace Cartoon.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IBootstrapper))]
    public class Bootstrapper : IBootstrapper
    {
        private readonly IDbContext _dbContext;

        public Bootstrapper(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
