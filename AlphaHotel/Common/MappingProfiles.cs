using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Common
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccountDetailsDTO, AccountViewModel>()
                .ForMember(d => d.LogBooks, src => src.Ignore()); ;

            //CreateMap<LogBookDTO, AccountViewModel>()
            //   .ForMember(d => d., src => src.Ignore);
        }
    }
}
