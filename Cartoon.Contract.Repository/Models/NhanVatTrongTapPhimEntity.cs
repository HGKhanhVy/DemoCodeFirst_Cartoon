using System.ComponentModel.DataAnnotations.Schema;
using Cartoon.Core.EnumCore;

namespace Cartoon.Contract.Repository.Models
{
    [Table("NhanVatTrongTapPhim")]

    public class NhanVatTrongTapPhimEntity : Entity
    {
        public string? tinhTrangNhanVat { get; set; }
        public string? trangThaiNhanVat { get; set; }

        [ForeignKey("NhanVat")]
        public string MaNhanVat { get; set; }
        public virtual NhanVatEntity NhanVat { get; set; }

        [ForeignKey("TapPhim")]
        public string MaTapPhim { get; set; }
        public virtual TapPhimEntity TapPhim { get; set; }

    }
}
