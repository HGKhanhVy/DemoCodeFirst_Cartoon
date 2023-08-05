using System.ComponentModel.DataAnnotations.Schema;
using Cartoon.Core.EnumCore;

namespace Cartoon.Contract.Repository.Models
{
    [Table("NhanVat")]

    public class NhanVatEntity : Entity
    {
        public string tenNhanVat { get; set; }

        public ICollection<NhanVatTrongTapPhimEntity> NhanVatTrongTapPhims { get; set; }
    }
}
