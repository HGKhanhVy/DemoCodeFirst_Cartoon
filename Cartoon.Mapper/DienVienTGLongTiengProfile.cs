using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.DienVienTGLongTieng;

namespace Cartoon.Mapper
{
    public class DienVienTGLongTiengProfile : Profile
    {
        public DienVienTGLongTiengProfile()
        {
            CreateMap<DienVienTGLongTiengModel, DienVienTGLongTiengEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}