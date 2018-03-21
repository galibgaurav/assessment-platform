using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Hosting;
//tells whhich class to call while startup
[assembly: OwinStartup(typeof(GyanParikshaWebApi.Startup))]

namespace GyanParikshaWebApi
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)//IAppBuilder” this parameter will be supplied by the host at run-time. This “app” parameter is an interface which will be used to compose the application for our Owin server.
        {
            ConfigureAuth(app);
        }

    }
}
