using System.ComponentModel.DataAnnotations.Schema;
namespace Cartoon.Contract.Repository.Models
{
    [Table("TapPhim")]
    public class TapPhimEntity : Entity
    {

        public string TenTapPhim { get; set; }


        [ForeignKey("PhimHoatHinh")]
        public string MaPhim { get; set; }

        public virtual PhimHoatHinhEntity? PhimHoatHinh { get; set; }
        public virtual ICollection<NhanVatTrongTapPhimEntity>? NhanVatTrongTapPhims { get; set; }

    }
}
