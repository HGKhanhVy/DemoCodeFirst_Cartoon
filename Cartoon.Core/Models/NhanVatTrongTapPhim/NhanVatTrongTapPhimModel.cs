using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartoon.Core.Models.NhanVatTrongTapPhim
{
    public class NhanVatTrongTapPhimModel
    {
        public string KeyId { get; set; }
        public string? tinhTrangNhanVat { get; set; }
        public string? trangThaiNhanVat { get; set; }
        public string MaNhanVat { get; set; }
        public string MaTapPhim { get; set; }
    }
}
