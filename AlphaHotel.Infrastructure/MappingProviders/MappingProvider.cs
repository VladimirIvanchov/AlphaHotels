using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Infrastructure.MappingProviders
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }
    }
}
