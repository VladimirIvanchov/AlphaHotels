using AlphaHotel.Models;
using AlphaHotel.ViewModels;
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
            CreateMap<Business, BusinessViewModel>()
                .ForMember(d => d.BusinessId, src => src.MapFrom(s => s.Id))
                .ForMember(d => d.Name, src => src.MapFrom(s => s.Name));

            CreateMap<User, AccountViewModel>()
                //.ForMember(d => d.Id, src => src.MapFrom(s => s.Id))
                //.ForMember(d => d.UserName, src => src.MapFrom(s => s.UserName))
                //.ForMember(d => d.BusinessId, src => src.MapFrom(s => s.BusinessId))
                //.ForMember(d => d.Email, src => src.MapFrom(s => s.Email))
                .ForMember(d => d.LogBookId, src => src.MapFrom(s => s.UsersLogbooks
                                                            .Select(ul => ul.LogBookId)))
                .ForMember(d => d.LogBookName, src => src.MapFrom(s => s.UsersLogbooks
                                                            .Select(ul => ul.LogBook.Name)))
                .ForMember(d => d.BusinessName, src => src.MapFrom(s => s.Business.Name));
        }
    }
}
