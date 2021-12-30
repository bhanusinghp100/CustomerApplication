using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Routing;
using CustomerApplication.DAl;
using CustomerApplication.Models;

namespace CustomerApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; //constructor 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IDAL,AdoDAl>();
            // create factory for dynamic DI
            // 
            services.AddScoped<Customer>((ctx) =>
            {
                IHttpContextAccessor con =
                ctx.GetService<IHttpContextAccessor>();
                double amt = Convert.ToDouble(con.HttpContext.Request.Form["CustomerAmount"]);
                if (amt > 100) {
                    return new GoldCustomer(); 
                } else {
                    return new DiscountCustomer();

                }


            });




            services.AddMvcCore(option => option.EnableEndpointRouting = false);
        }

        //public void LoadRoutes(IRouteBuilder Builder)
        //{
        //    Builder.MapRoute("route1", "Customer/Add", new
        //    {
        //        Controller = "Customer",
        //        Action = "Add"

        //    });
        //    Builder.MapRoute("route2", "Cutomer/New", new
        //    {
        //        Controller="Customer",
        //        Action="New"
        //    });



        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           // app.UseStaticFiles();//for static files 
            app.UseMvc(); // for mVC
            app.UseMvcWithDefaultRoute();// MVC with Defalut routes 
            //app.UseMvc(route => ApplicationRouting.LoadRoutes(route) // Call Customer Routes    

            //    );// routing 



            //app.Map("/Home", Execute);
            //app.MapWhen(context =>
            //{ return context.Request.Query.ContainsKey("Search"); }, ExcuteSearch);
            //app.UseMiddlewareLogic1(); //first way to use middleware in pipeline
            //app.UseMiddleware<MiddlewareLogic2>();//second way 
            //app.Run(async (context)=>logic3(context));// third way 



        }

        public void Execute(IApplicationBuilder app)
        {
            app.Run(async (context) => logicHome(context));

        }

        public void ExcuteSearch(IApplicationBuilder app)
        {
            app.Run(async (context)  => SearchQuery(context));
        }
            
        public async Task SearchQuery(HttpContext obj)
        {
            await obj.Response.WriteAsync("THis is query string ");
        }

        public async Task logicHome(HttpContext obj)
        {
            await obj.Response.WriteAsync("HOme Implemented \n");
        


        }

        public async Task logic2 (HttpContext obj,Func<Task> next)
        {

            await obj.Response.WriteAsync("Logic2 is implemented \n");
            await next.Invoke();
        }
        public async Task logic3(HttpContext obj)
        {

            await obj.Response.WriteAsync("Logic3 is implemented \n");
        }



    }
}
