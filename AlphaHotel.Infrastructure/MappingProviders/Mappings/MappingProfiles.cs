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
               .ForMember(d => d.Feedbacks, src => src.MapFrom(s => s.Feedbacks));

            //CreateMap<UsersLogbooks, LogDTO>()
            //   .ForMember(d => d.Id, src => src.MapFrom(s => s.LogBook.Logs
            //                                               .FirstOrDefault().Id));
            //.ForMember(d => d.Description, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.Description)))
            //.ForMember(d => d.AuthorUsername, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.Author.UserName)));
            //.ForMember(d => d.Status, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.Status.Type)))
            //.ForMember(d => d.LogBookId, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.LogBookId)))
            //.ForMember(d => d.LogBook, src => src.MapFrom(s => s.LogBook.Name))
            //.ForMember(d => d.Category, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.Category.Name)))
            //.ForMember(d => d.CreatedOn, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.CreatedOn)))
            //.ForMember(d => d.IsDeleted, src => src.MapFrom(s => s.LogBook.Logs
            //                                            .Select(l => l.IsDeleted)));

            CreateMap<Log, LogDTO>()
              .ForMember(d => d.AuthorUsername, src => src.MapFrom(s => s.Author.UserName))
              .ForMember(d => d.Status, src => src.MapFrom(s => s.Status.Type))
              .ForMember(d => d.Category, src => src.MapFrom(s => s.Category.Name));
        }
    }
}
