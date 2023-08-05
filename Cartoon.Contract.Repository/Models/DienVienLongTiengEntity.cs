using Cartoon.Contract.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartoon.Contract.Repository.Models
{
    public class DienVienLongTiengEntity : Entity
    {
        public string TenDienVien { get; set; }
        public ICollection<DienVienTGLongTiengEntity> DienVienTGLongTiengs { get; set; }
    }
}
