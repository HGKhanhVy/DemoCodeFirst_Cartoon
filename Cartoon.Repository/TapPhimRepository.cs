using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(ITapPhimRepository))]
    public class TapPhimRepository : Repository<TapPhimEntity>, ITapPhimRepository
    {
        public TapPhimRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

