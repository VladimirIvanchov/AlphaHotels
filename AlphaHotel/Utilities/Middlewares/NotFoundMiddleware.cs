using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AlphaHotel.Utilities.Middlewares
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);

                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/Error/PageNotFound");
                }
            }
            catch (Exception ex)
            {
                context.Response.Redirect("/Error/PageNotFound");
            }
        }
    }
}
