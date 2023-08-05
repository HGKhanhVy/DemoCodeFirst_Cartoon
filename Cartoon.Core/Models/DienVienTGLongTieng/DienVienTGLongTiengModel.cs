using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartoon.Core.Models.DienVienTGLongTieng
{
    public class DienVienTGLongTiengModel
    {
        public string KeyId { get; set; }
        public string MaPhim { get; set; }
        public string MaDienVien { get; set; }
    }
}
