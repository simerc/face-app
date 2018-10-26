using AutoMapper;
using FaceImage.Api.Infrastructure.Automapper;
using FaceImage.Api.Infrastructure.StartupExtensions;
using FaceImage.Api.Security;
using FaceImage.Api.Services;
using FaceImage.Api.Services.Interfaces;
using FaceImage.DataAccess;
using FaceImage.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            //setup db access
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("FaceImage.Api")));

            //identity pipeline
            services.AddIdentity<AppUser, AppUserRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            //setup services / factories
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IImageStorageService, LocalImageStorageService>();

            services.AddJwtAuthentication(Configuration);

            //add identity
            var builder = services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<UserDbContext>();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            //TODO - update Cors to the correct domains
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    b =>
                    {
                        b
                            .WithOrigins("*")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            //Automapper profiles
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            //setup image storage based on settings
            services.ConfigureImageUploadOptions(Configuration);

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

            app.UseAuthentication();

            app.UseMvc();

        }
    }
}
