using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(IDienVienLongTiengRepository))]
    public class DienVienLongTiengRepository : Repository<DienVienLongTiengEntity>, IDienVienLongTiengRepository
    {
        public DienVienLongTiengRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

