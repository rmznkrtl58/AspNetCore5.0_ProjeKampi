using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjeKamp
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


            services.AddControllersWithViews();




            //Identity i�in gerekli i�lemler a�a��dad�r
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser,AppRole>(x=>
            {   //�ifre i�in kurallar� belirledi�imiz yerdir.
                x.Password.RequireUppercase = false;
                //en az bir b�y�k harf zorunlulu�unu kald�r�r
                x.Password.RequireNonAlphanumeric = false;
                //en az bir bir sembol olmas� zorunlulu�unu kald�r�r
            }
            ).AddEntityFrameworkStores<Context>();
            //--------------------------------------------------------------------------

            


            //SESS�ON ��LEMLER�N� KULLANMAM ���N
            services.AddSession();

            //PROJE SEV�YES�NDE AUTHOR�ZE ��LEM�
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()//Yetkilendirme Politikas� Olu�turucu
                .RequireAuthenticatedUser()//Sisteme Giri� Yapan Kullan�c� Gerekli
                .Build();//Olu�tur
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //proje bazl� authorize yapt���m�z i�in millet kafas�na g�re
            // /blog/Index/ yaz�p sayfaya gidemez onu yazd�klar� an login sayfama y�n-
            //lendirmem gerek a�a��daki bile�enleri kullanaca��m
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/";
                });


            //maalesef bu yap�n�n kurulu olmas� gerekiyor yoktu oyuzden di�er projelerde dikkat et
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly= true;
                options.ExpireTimeSpan= TimeSpan.FromMinutes(5);
                //sisteme rollemede yetkilendirilmi� ki�i harici girdi�i an ��kaca�� hata sayfas�n�n yolu
                options.AccessDeniedPath = new PathString("/ErrorPage/AccessDenied/");
                options.LoginPath= "/Login/Index/";
                options.SlidingExpiration = true;
            });
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //AUTHONT�CE ��LEM� ���N 
            app.UseAuthentication();

            //HATA SAYFALARINDA NE G�STER�LECEK
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");


            //SESS�ON ��LEMLER�N� KULLANMAM ���N
            app.UseSession();

			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {  
                //Program�ma arealar�n kullan�lmas� i�in ve arealar�n nerden ba�lamas� 
                //i�in tan�mlama yapt�m
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
