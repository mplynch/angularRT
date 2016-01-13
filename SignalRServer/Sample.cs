using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SignalRServer
{
    public class Sample
    {
        public Sample()
        {

        }

        [JsonProperty("timestamp")]
        public DateTime Timestamp
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public double Value
        {
            get;
            set;
        }
    }
}