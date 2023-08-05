using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(INhanVatRepository))]
    public class NhanVatRepository : Repository<NhanVatEntity>, INhanVatRepository
    {
        public NhanVatRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

