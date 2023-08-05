using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.DienVienLongTieng;

namespace Cartoon.Mapper
{
    public class DienVienLongTiengProfile : Profile
    {
        public DienVienLongTiengProfile()
        {
            CreateMap<DienVienLongTiengModel, DienVienLongTiengEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}