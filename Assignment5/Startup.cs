using Assignment5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //added a set here
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BooklistDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BooklistConnection"]);
            });

            //Each request will get its own repository request
            services.AddScoped<iBooklistRepository, EFBooklistRepository>();

            services.AddRazorPages();
            //Need add in services in order to maintain the cashe so that you can add things to cart and retain that info
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            //When user clicks on this site it will set up a session so that the stuff in the cart will sit there while going around the site
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    "page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    "category",
                    "{category}",
                    new { Controller = "Home", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    "pagination",
                    "Books/P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //need to add this to make sure that razor pages can work in the project
                endpoints.MapRazorPages();
                    
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
