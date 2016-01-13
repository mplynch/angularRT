using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRServer.Startup))]

namespace SignalRServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);

            DataEngine dataEngine = new DataEngine(100);
            System.Threading.Tasks.Task.Factory.StartNew(async () => await dataEngine.OnDataMonitor());
        }
    }
}