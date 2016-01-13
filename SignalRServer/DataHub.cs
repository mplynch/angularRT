using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class DataHub : Hub
    {
        public void SendData(IList<Sample> samples)
        {
            Clients.All.broadcastData(samples);
        }

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}