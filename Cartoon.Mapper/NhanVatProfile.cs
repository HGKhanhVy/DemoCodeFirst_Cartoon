using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.NhanVat;

namespace Cartoon.Mapper
{
    public class NhanVatProfile : Profile
    {
        public NhanVatProfile()
        {
            CreateMap<NhanVatModel, NhanVatEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}