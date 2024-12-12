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




            //Identity için gerekli iþlemler aþaðýdadýr
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser,AppRole>(x=>
            {   //þifre için kurallarý belirlediðimiz yerdir.
                x.Password.RequireUppercase = false;
                //en az bir büyük harf zorunluluðunu kaldýrýr
                x.Password.RequireNonAlphanumeric = false;
                //en az bir bir sembol olmasý zorunluluðunu kaldýrýr
            }
            ).AddEntityFrameworkStores<Context>();
            //--------------------------------------------------------------------------

            


            //SESSÝON ÝÞLEMLERÝNÝ KULLANMAM ÝÇÝN
            services.AddSession();

            //PROJE SEVÝYESÝNDE AUTHORÝZE ÝÞLEMÝ
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()//Yetkilendirme Politikasý Oluþturucu
                .RequireAuthenticatedUser()//Sisteme Giriþ Yapan Kullanýcý Gerekli
                .Build();//Oluþtur
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //proje bazlý authorize yaptýðýmýz için millet kafasýna göre
            // /blog/Index/ yazýp sayfaya gidemez onu yazdýklarý an login sayfama yön-
            //lendirmem gerek aþaðýdaki bileþenleri kullanacaðým
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/";
                });


            //maalesef bu yapýnýn kurulu olmasý gerekiyor yoktu oyuzden diðer projelerde dikkat et
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly= true;
                options.ExpireTimeSpan= TimeSpan.FromMinutes(5);
                //sisteme rollemede yetkilendirilmiþ kiþi harici girdiði an çýkacaðý hata sayfasýnýn yolu
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

            //AUTHONTÝCE ÝÞLEMÝ ÝÇÝN 
            app.UseAuthentication();

            //HATA SAYFALARINDA NE GÖSTERÝLECEK
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");


            //SESSÝON ÝÞLEMLERÝNÝ KULLANMAM ÝÇÝN
            app.UseSession();

			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {  
                //Programýma arealarýn kullanýlmasý için ve arealarýn nerden baþlamasý 
                //için tanýmlama yaptým
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
