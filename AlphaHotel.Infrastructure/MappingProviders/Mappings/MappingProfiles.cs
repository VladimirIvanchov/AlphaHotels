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

            CreateMap<Business, BusinessDetailsDTO>()
               .ForMember(d => d.Pictures, src => src.MapFrom(s => s.Pictures
                                                           .Select(p => p.Location)))
               .ForMember(d => d.Feedbacks, src => src.MapFrom(s => s.Feedbacks))
               .ForMember(d => d.Facilities, src => src.MapFrom(s => s.BusinessesFacilities
                                                           .Select(p => p.Facility)));    
            CreateMap<Log, LogDTO>()
              .ForMember(d => d.AuthorUsername, src => src.MapFrom(s => s.Author.UserName))
              .ForMember(d => d.Status, src => src.MapFrom(s => s.Status.Type))
              .ForMember(d => d.Category, src => src.MapFrom(s => s.Category.Name));
        }
    }
}
