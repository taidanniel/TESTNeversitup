using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTNeversitup.Models
{
    public class OrderHeader
    {
        public int Order_No { get; set; }
        public string Order_Status { get; set; }
        public string Created_by { get; set; }
    }
}