using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sp_Medical_Group
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                    .AddAuthentication(a =>
                    {
                        a.DefaultAuthenticateScheme = "JwtBearer";
                        a.DefaultChallengeScheme = "JwtBearer";
                    })

                    .AddJwtBearer("JwtBearer", a =>
                    {
                        a.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,

                            ValidateAudience = true,

                            ValidateLifetime = true,

                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sp_medical_group_autenticacao")),


                            ClockSkew = TimeSpan.FromMinutes(30),

                            ValidIssuer = "Sp_Medical_Group.webApi",

                            ValidAudience = "Sp_Medical_Group.webApi"

                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SP MEDICAL GROUP", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", 
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });

            services
                .AddControllers()
                
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
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
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();

            app.UseCors("CorsPolicy");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
