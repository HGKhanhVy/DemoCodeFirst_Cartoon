using AutoMapper;
using Cartoon.Contract.Repository.Models;
using Cartoon.Core.Models.NhanVatTrongTapPhim;

namespace Cartoon.Mapper
{
    public class NhanVatTrongTapPhimProfile : Profile
    {
        public NhanVatTrongTapPhimProfile()
        {
            CreateMap<NhanVatTrongTapPhimModel, NhanVatTrongTapPhimEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}