﻿
using CMSDemo.Data;
using CMSDemo.Models;
using CMSDemo.Models.Handlers;
using CMSDemo.Models.Interfaces;
using CMSDemo.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CMSDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
            Environment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var dataCon = Environment.IsDevelopment()
                ? Configuration.GetConnectionString("DefaultConnection")
                : Configuration.GetConnectionString("ProductionConnection");

            var identityDB = Environment.IsDevelopment()
                ? Configuration.GetConnectionString("UserConnection")
                : Configuration.GetConnectionString("ProductionUser");

            // register the database for non user related items
            services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(dataCon));

            // register the database for non user related items
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(identityDB));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
          
                options.AddPolicy("Over21Only", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
                options.AddPolicy("CFEmail", policy => policy.Requirements.Add(new RequiredEmailRequirement()));

            });

            services.AddScoped<IAuthorizationHandler, CodefellowsEmailHandler>();
            services.AddScoped<IPostManagement, PostService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IPayment, AuthNetPayment>();
            services.AddScoped<IImageManager, BlobStorage>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // required for the login/logout to work
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
