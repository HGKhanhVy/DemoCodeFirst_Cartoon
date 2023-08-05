using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.DienVienTGLongTieng;

namespace Cartoon.Contract.Service
{
    public interface IDienVienTGLongTiengService :
       Base.ICreateable<DienVienTGLongTiengModel, string>,
       Base.IUpdateable<DienVienTGLongTiengModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DienVienTGLongTiengEntity, string>
    {
    }
}
