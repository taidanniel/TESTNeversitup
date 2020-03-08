using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTNeversitup.Models;
using TESTNeversitup.Services;

namespace TESTNeversitup.Controllers
{
    public class OrdermanagementController : ApiController
    {
        private OrderManagementService order_service = new OrderManagementService();

        public IHttpActionResult CancelOrder(int order_no)
        {
            return Ok(order_service.CancelOrder(order_no));
        }

        public IHttpActionResult GetOrderDetail(int order_no)
        {
            return Ok(order_service.GetOrderDetail(order_no));
        }

        public IHttpActionResult GetOrderHeaderAll()
        {
            return Ok(order_service.GetOrderHeaderAll());
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(Order order)
        {
            return Ok(order_service.CreateOrder(order));
        }
    }
}
