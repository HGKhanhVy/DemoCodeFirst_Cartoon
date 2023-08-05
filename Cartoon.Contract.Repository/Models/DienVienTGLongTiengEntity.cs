using Cartoon.Contract.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartoon.Contract.Repository.Models
{
    public class DienVienTGLongTiengEntity : Entity
    {
        [ForeignKey("PhimHoatHinh")]
        public string MaPhim { get; set; }

        public virtual PhimHoatHinhEntity? PhimHoatHinh { get; set; }

        [ForeignKey("DienVienLongTieng")]
        public string MaDienVien { get; set; }

        public virtual DienVienLongTiengEntity? DienVien { get; set; }
    }
}
