﻿using FoodDelivery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FoodDelivery.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            User user = context.Session["User"] as User;

            if (user != null)
            {
                GenericIdentity userIdentity = new GenericIdentity(user.FirstName);
                string[] userRoles = { };
                GenericPrincipal myPrincipal = new GenericPrincipal(userIdentity, userRoles);
                context.User = myPrincipal;
            }
        }
    }
}
