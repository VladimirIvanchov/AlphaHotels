using AlphaHotel.Models;
using AlphaHotel.ViewModels;
using AutoMapper;

namespace AlphaHotel.Infrastructure.MappingProviders.Mappings
{
    public class BusinessToBusinessViewModel : Profile
    {
        public BusinessToBusinessViewModel()
        {
            CreateMap<Business, BusinessViewModel>()
                .ForMember(d => d.BusinessId, src => src.MapFrom(s => s.Id));

            CreateMap<Business, BusinessViewModel>()
                .ForMember(d => d.Name, src => src.MapFrom(s => s.Name));
        }
    }
}
