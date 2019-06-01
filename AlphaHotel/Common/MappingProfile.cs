using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Areas.Manager.Models;
using AlphaHotel.DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace AlphaHotel.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDetailsDTO, AccountViewModel>()
                .ForMember(d => d.LogBooks, src => src.Ignore());

            CreateMap<ICollection<BusinessDTO>, CreateLogBookViewModel>()
               .ForMember(d => d.Businesses, src => src.MapFrom(s => s))
               .ForMember(d => d.BusinessId, src => src.Ignore())
               .ForMember(d => d.LogBookName, src => src.Ignore());

            CreateMap<ICollection<CategoryDTO>, CreateCategoryViewModel>()
               .ForMember(d => d.Categories, src => src.MapFrom(s => s))
               .ForMember(d => d.CategoryName, src => src.Ignore());

            CreateMap<ICollection<StatusDTO>, StatusForLogViewModel>()
               .ForMember(d => d.Statuses, src => src.MapFrom(s => s))
               .ForMember(d => d.LogId, src => src.Ignore());
        }
    }
}
