using Cartoon.Mapper;

namespace Cartoon.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new PhimHoatHinhProfile());
                cfg.AddProfile(new TapPhimProfile());
                cfg.AddProfile(new NhanVatTrongTapPhimProfile());
                cfg.AddProfile(new NhanVatProfile());
                cfg.AddProfile(new DienVienTGLongTiengProfile());
                cfg.AddProfile(new DienVienLongTiengProfile());
            });
            return services;
        }
    }
}
