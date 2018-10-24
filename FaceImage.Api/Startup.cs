using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FaceImage.Api.Infrastructure.Automapper;
using FaceImage.DataAccess;
using FaceImage.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FaceImage.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            //setup db access
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("FaceImage.Api")));
             
            //identity pipeline
            services.AddIdentity<AppUser, AppUserRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            //Automapper profiles
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
           


            //Configure password option specifics
            //most basic possible password for test purposes
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/account/login";
            //    options.LogoutPath = "/account/logout";
            //    options.AccessDeniedPath = "/account/denied";
            //    options.SlidingExpiration = true;
            //    options.Cookie = new CookieBuilder
            //    {
            //        HttpOnly = true,
            //        Name = ".Fiver.Security.Cookie",
            //        Path = "/",
            //        SameSite = SameSiteMode.Lax,
            //        SecurePolicy = CookieSecurePolicy.SameAsRequest
            //    };
            //});



            // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            //services.AddAuthentication()
            //    .AddFacebook(options =>
            //    {
            //        options.AppId = Configuration["auth:facebook:appid"];
            //        options.AppSecret = Configuration["auth:facebook:appsecret"];
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseMvc();

            app.UseAuthentication();
        }
    }
}
