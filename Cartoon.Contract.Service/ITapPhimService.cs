using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.TapPhim;

namespace Cartoon.Contract.Service
{
    public interface ITapPhimService :
       Base.ICreateable<TapPhimModel, string>,
       Base.IUpdateable<TapPhimModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<TapPhimEntity, string>
    {
    }
}
