using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.UI;

namespace MCCOYC
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ScriptManager.ScriptResourceMapping.AddDefinition("angular", new ScriptResourceDefinition
            {
                Path = "~/Scripts/angular.min.js",
                CdnPath = "https://opensource.keycdn.com/angularjs/1.5.3/angular.min.js",
                CdnSupportsSecureConnection = true
            });

            ScriptManager.ScriptResourceMapping.AddDefinition("angular.routes", new ScriptResourceDefinition
            {
                Path = "~/Scripts/angular-route.min.js"
            });

        }
    }
}