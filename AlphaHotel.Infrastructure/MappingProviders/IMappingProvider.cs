namespace AlphaHotel.Infrastructure.MappingProviders
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);
    }
}
