using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AlphaHotel.Models;
using Microsoft.AspNetCore.Mvc;
using AlphaHotel.Data;
using AlphaHotel.Services.Contracts;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.MappingProviders;
using AutoMapper;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Common;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Infrastructure.Wrappers.Contracts;
using AlphaHotel.Infrastructure.Wrappers;
using AlphaHotel.Utilities.Extentions;
using Microsoft.Extensions.Logging;
using AlphaHotel.Infrastructure.Censorship;
using AlphaHotel.Infrastructure.ReaderProvider;
using AlphaHotel.Areas.Manager.Hubs;
using NLog.Web;
using NLog.Extensions.Logging;

namespace AlphaHotel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AlphaHotelDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILogBookService, LogBookService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IDateTimeWrapper, DateTimeWrapper>();
            services.AddScoped<IMappingProvider, MappingProvider>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IPictureHelper, PictureHelper>();
            services.AddScoped(typeof(IPaginatedList<>), typeof(PaginatedList<>));
            services.AddScoped(typeof(IUserManagerWrapper<>), typeof(UserManagerWrapper<>));
            services.AddScoped(typeof(ISingInManagerWrapper<>), typeof(SingInManagerWrapper<>));
            services.AddSingleton<ICensor, Censor>();
            services.AddSingleton<IFileReader, FileReader>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AlphaHotelDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();
            Mapper.Initialize(cfg => { cfg.AddProfile<MappingProfiles>(); cfg.AddProfile<MappingProfile>(); });

            services.AddMemoryCache();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error/Error");
            }

            app.UseNotFoundExceptionHandler();

            app.UseStaticFiles();

            app.UseAuthentication();

            env.ConfigureNLog("nlog.config");
            loggerFactory.AddNLog();
            app.AddNLogWeb();


            app.UseSignalR(
                routes =>
                {
                    routes.MapHub<LogHub>("/alllogbooklogs");
                });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
