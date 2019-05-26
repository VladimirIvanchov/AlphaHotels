﻿using System.Collections.Generic;
using System.Linq;

namespace AlphaHotel.Infrastructure.MappingProviders
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);
        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source);
    }
}
