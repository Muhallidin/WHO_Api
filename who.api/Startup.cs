
using who.api.Class;
using who.api.Options;
using System;
using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using who.application.Common;
using Microsoft.Extensions.Hosting;

namespace who.api
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
            services.AddControllers();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.Configure<ConnectionSetting>(Configuration.GetSection("ConnectionStrings"));

            //services.AddSingleton<IConnectionSetting, ConnectionSetting>();

            //services.AddSingleton<IApplicationSettings, ApplicationSettings>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WHO API", Version = "v1.0" });
            });

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());



            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //    options.AddDefaultPolicy(builder =>
            //         builder.SetIsOriginAllowed(_ => true)
            //                .AllowAnyMethod()
            //                .AllowAnyHeader()
            //                .AllowCredentials());
            //});


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseCorsMiddleware();

            app.UseCors(builder =>
                 builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
             );

            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Desription);
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
