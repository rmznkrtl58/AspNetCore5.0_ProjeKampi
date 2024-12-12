using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt_Core_Kamp
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jwt_Core_Kamp", Version = "v1" });
            });

            //JWT ÝÇÝN GEREKLÝ DEÐERLERÝ AÞAÐIYA YAZACAÐIM
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;//ilk baþta api katmanýný oluþturduðum an configure for https 
                //seçeneðini kaldýrdýðýmýz için burda false atýyoruz
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "http://localhost",//TOKEN KÝM TARAFINDAN OLUÞTURULUYOR
                    ValidAudience = "http://localhost",//TOKEN KÝM TARAFINDAN KULLANILACAK
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreprojekampi")),
                    //IssuerSigningKey->ANAHTAR KELÝMEM ÇOK ÖNEMLÝ 
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jwt_Core_Kamp v1"));
            }

            app.UseRouting();

            //jwt için gerekli useauthorization'dan önce gelmesi lazým
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
