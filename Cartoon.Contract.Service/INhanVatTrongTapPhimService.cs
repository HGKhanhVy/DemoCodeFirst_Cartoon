using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.NhanVatTrongTapPhim;

namespace Cartoon.Contract.Service
{
    public interface INhanVatTrongTapPhimService :
       Base.ICreateable<NhanVatTrongTapPhimModel, string>,
       Base.IUpdateable<NhanVatTrongTapPhimModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NhanVatTrongTapPhimEntity, string>
    {
    }
}
