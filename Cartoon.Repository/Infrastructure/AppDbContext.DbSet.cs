using Microsoft.EntityFrameworkCore;
using Cartoon.Contract.Repository.Models;

namespace Cartoon.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<PhimHoatHinhEntity> PhimHoatHinh { get; set; }
        public DbSet<TapPhimEntity> TapPhim { get; set; }
        public DbSet<NhanVatTrongTapPhimEntity> NhanVatTrongTapPhim { get; set; }
        public DbSet<NhanVatEntity> NhanVat { get; set; }
        public DbSet<DienVienTGLongTiengEntity> DienVienTGLongTieng { get; set; }
        public DbSet<DienVienLongTiengEntity> DienVienLongTieng { get; set; }
    }
}
