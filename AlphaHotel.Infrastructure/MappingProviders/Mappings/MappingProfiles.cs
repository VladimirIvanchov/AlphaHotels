using AlphaHotel.Models;
using AlphaHotel.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlphaHotel.Infrastructure.MappingProviders.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Business, BusinessDTO>()
                .ForMember(d => d.BusinessId, src => src.MapFrom(s => s.Id))
                .ForMember(d => d.Name, src => src.MapFrom(s => s.Name));

            CreateMap<User, AccountDTO>()
                .ForMember(d => d.LogBookId, src => src.MapFrom(s => s.UsersLogbooks
                                                            .Select(ul => ul.LogBookId)))
                .ForMember(d => d.LogBookName, src => src.MapFrom(s => s.UsersLogbooks
                                                            .Select(ul => ul.LogBook.Name)))
                .ForMember(d => d.BusinessName, src => src.MapFrom(s => s.Business.Name));

            CreateMap<User, AccountDetailsDTO>()
               .ForMember(d => d.LogBookId, src => src.MapFrom(s => s.UsersLogbooks
                                                           .Select(ul => ul.LogBookId)))
               .ForMember(d => d.BusinessName, src => src.MapFrom(s => s.Business.Name));
        }
    }
}
