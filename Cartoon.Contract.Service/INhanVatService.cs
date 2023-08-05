using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.NhanVat;

namespace Cartoon.Contract.Service
{
    public interface INhanVatService :
       Base.ICreateable<NhanVatModel, string>,
       Base.IUpdateable<NhanVatModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NhanVatEntity, string>
    {
    }
}
