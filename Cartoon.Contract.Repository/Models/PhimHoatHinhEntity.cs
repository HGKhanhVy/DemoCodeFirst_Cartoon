using System.ComponentModel.DataAnnotations.Schema;

namespace Cartoon.Contract.Repository.Models
{
    [Table("PhimHoatHinh")]
    public class PhimHoatHinhEntity : Entity
    {

        public string TenPhim { get; set; }
        public string NhaXuatBan { get; set; }
        public string DaoDien { get; set; }
        public int NamSanXuat { get; set; }

        public virtual ICollection<TapPhimEntity>? TapPhims { get; set; }
        public virtual ICollection<DienVienTGLongTiengEntity>? DienVienTGLongTiengs { get; set; }
    }
}
