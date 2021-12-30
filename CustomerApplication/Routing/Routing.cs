using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Routing
{
    public static class ApplicationRouting
    {
        public static void LoadRoutes(IRouteBuilder Builder)
        {
            // Traditional routing  or Conventional Routing 

            Builder.MapRoute("route1", "", new
            {
                Controller = "Customer",
                Action = "Add"

            });
            Builder.MapRoute("route2", "Cutomer/New/{Id}", new
            {
                Controller = "Customer",
                Action = "New"
            });

            //Attribute Routing

             


        }
    }
}
