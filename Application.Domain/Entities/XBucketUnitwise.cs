using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.Domain.Entities
{
    public class XBucketUnitwise
    {
        public string Bh { get; set; }
        public string Funder { get; set; }
        public string State { get; set; }
        public string Unit { get; set; }
        public float  X_Bucket_flow_clients { get; set; }
        public float  Visits_on_X_bucket { get; set; }
        public float Unique_Visits_on_X_bucket { get; set; }
        public float  Reduced { get; set; }
        public float Collected { get; set; }
        public float  Collected_Amount { get; set; }
    }
}
