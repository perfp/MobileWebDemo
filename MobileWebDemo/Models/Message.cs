using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebDemo.Models
{
    public class Message
    {
        public string Heading;
        public string Ingress;
        public string MessageType;
        public string County;
        public string Urgency;
        public string RoadType;

        public struct MessageTypes
        {
            public const string RedusertFramkommelighet = "Redusert framkommelighet";
            public const string MidlertidigStengt = "Midlertidig stengt";
        }
    }
}