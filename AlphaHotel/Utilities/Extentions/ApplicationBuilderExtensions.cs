using AlphaHotel.Utilities.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AlphaHotel.Utilities.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseNotFoundExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<NotFoundMiddleware>();
        }
    }
}
