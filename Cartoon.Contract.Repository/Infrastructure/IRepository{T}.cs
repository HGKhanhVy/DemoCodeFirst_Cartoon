using Cartoon.Contract.Repository.IBase;
using Cartoon.Contract.Repository.Models;

namespace Cartoon.Contract.Repository.Infrastructure
{
    public interface IRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
    }
}
