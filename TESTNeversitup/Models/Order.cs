using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TESTNeversitup.Models
{
    public class Order
    {
        public int Order_No { get; set; }
        public string Order_Status { get; set; }
        public string Created_by { get; set; }

        [JsonProperty("Details")]
        public List<OrderDetail> Details { get; set; }
    }
}