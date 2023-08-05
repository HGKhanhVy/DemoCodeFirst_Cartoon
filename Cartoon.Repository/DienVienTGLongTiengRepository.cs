using Invedia.DI.Attributes;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Infrastructure;

namespace Cartoon.Repository
{
    [ScopedDependency(ServiceType = typeof(IDienVienTGLongTiengRepository))]
    public class DienVienTGLongTiengRepository : Repository<DienVienTGLongTiengEntity>, IDienVienTGLongTiengRepository
    {
        public DienVienTGLongTiengRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

