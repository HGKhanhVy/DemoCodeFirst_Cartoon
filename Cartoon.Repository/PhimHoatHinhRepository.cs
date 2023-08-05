using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(IPhimHoatHinhRepository))]
    public class PhimHoatHinhRepository : Repository<PhimHoatHinhEntity>, IPhimHoatHinhRepository
    {
        public PhimHoatHinhRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

