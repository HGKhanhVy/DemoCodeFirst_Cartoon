using Cartoon.Contract.Repository.IBase;
using Cartoon.Contract.Repository.Infrastructure;
using Cartoon.Contract.Repository.Models;
using Cartoon.Repository.Base;

namespace Cartoon.Repository.Infrastructure
{
    public abstract class Repository<T> : BaseRepository<T>, IRepository<T> ,IBaseRepository<T> where T : Entity, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
