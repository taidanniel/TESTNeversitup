using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTNeversitup.Models
{
    public class OrderDetail
    {
        public int Order_No { get; set; }
        public int Item_No{ get; set; }
        public string Product_ID { get; set; }
        public double QTY { get; set; }
        public double Amount { get; set; }
        public double Total_Amount { get; set; }
        public double Vat { get; set; }
    }
}