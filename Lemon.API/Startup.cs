using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Lemon.API.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Lemon.API.Filter;
using Lemon.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

namespace Lemon.API
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
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options => {
                    options.AccessDeniedPath = "/login.html";
                    options.LoginPath = "/login.html";
                    options.LogoutPath = "/logout";
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(t => 
            {
                t.SwaggerDoc("v1",new Info
                {
                    Version = "v1",
                    Title = "LemonAPI",
                    Description = "API for Lemon's Web",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "柠檬的个人网站", Email = "", Url = "https://lemonxin.club" },
                });
                t.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Lemon.API.xml"));
                t.OperationFilter<AuthTokenHeaderParameter>();
                t.DocumentFilter<AuthApplyTagDescriptions>();
            });
            services.AddDbContext<CoreDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("Lemon"))
            );

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lemon.API V1");
            });
        }
    }
}
