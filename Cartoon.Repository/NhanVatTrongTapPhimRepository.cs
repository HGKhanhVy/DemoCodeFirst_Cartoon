using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(INhanVatTrongTapPhimRepository))]
    public class NhanVatTrongTapPhimRepository : Repository<NhanVatTrongTapPhimEntity>, INhanVatTrongTapPhimRepository
    {
        public NhanVatTrongTapPhimRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

