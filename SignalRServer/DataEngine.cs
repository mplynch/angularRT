using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace SignalRServer
{
    public class DataEngine
    {
        private IHubContext _hubs;
        private readonly int _pollIntervalMillis;
        static Random dataRandom;

        public DataEngine(int pollIntervalMillis)
        {
            //HostingEnvironment.RegisterObject(this);
            _hubs = GlobalHost.ConnectionManager.GetHubContext<DataHub>();
            _pollIntervalMillis = pollIntervalMillis;
            dataRandom = new Random(DateTime.Now.Millisecond);
        }

        public async Task OnDataMonitor()
        {
            Sample sample = new Sample() { Timestamp = DateTime.Now, Value = dataRandom.NextDouble() * 100 };

            //Monitor for infinity!
            while (true)
            {
                await Task.Delay(_pollIntervalMillis);

                sample.Value = dataRandom.NextDouble() * 100;

                _hubs.Clients.All.broadcastPerformance(sample);
                _hubs.Clients.All.serverTime(DateTime.UtcNow.ToString());
            }
        }

        public void Stop(bool immediate)
        {

            //HostingEnvironment.UnregisterObject(this);
        }
    }

}