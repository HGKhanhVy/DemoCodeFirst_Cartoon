using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.PhimHoatHinh;

namespace Cartoon.Contract.Service
{
    public interface IPhimHoatHinhService :
       Base.ICreateable<PhimHoatHinhModel, string>,
       Base.IUpdateable<PhimHoatHinhModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<PhimHoatHinhEntity, string>
    {
    }
}
