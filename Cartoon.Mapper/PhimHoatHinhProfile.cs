using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.PhimHoatHinh;

namespace Cartoon.Mapper
{
    public class PhimHoatHinhProfile : Profile
    {
        public PhimHoatHinhProfile()
        {
            CreateMap<PhimHoatHinhModel, PhimHoatHinhEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}