using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.DienVienLongTieng;

namespace Cartoon.Contract.Service
{
    public interface IDienVienLongTiengService :
       Base.ICreateable<DienVienLongTiengModel, string>,
       Base.IUpdateable<DienVienLongTiengModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DienVienLongTiengEntity, string>
    {
    }
}
