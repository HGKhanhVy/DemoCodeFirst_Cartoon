using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.TapPhim;

namespace Cartoon.Mapper
{
    public class TapPhimProfile : Profile
    {
        public TapPhimProfile()
        {
            CreateMap<TapPhimModel, TapPhimEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}