using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cohort8CMSProject.Data;
using Cohort8CMSProject.Models;
using Cohort8CMSProject.Models.Handlers;
using Cohort8CMSProject.Models.Interfaces;
using Cohort8CMSProject.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cohort8CMSProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                policy.RequireRole(ApplicationRoles.Admin));
                options.AddPolicy("Color", policy =>
                policy.RequireClaim("FavoriteColor", "red"));
                options.AddPolicy("Over18Only", policy =>
                policy.Requirements.Add(new MinimumAgeRequirement(18)));
                options.AddPolicy("CodefellowsEmail", policy =>
                policy.Requirements.Add(new RequiredEmailRequirement()));
            });

            services.AddScoped<IPostManagement, PostService>();
            services.AddScoped<IAuthorizationHandler, CodefellowsEmailHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
