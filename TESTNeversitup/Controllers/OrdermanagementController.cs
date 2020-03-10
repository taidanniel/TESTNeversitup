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

        /// <summary>
        /// Cancel Order.
        /// </summary>
        /// <param name="order_no">Order Number</param>
        public IHttpActionResult CancelOrder(int order_no)
        {
            return Ok(order_service.CancelOrder(order_no));
        }

        /// <summary>
        /// Get Detail of Order.
        /// </summary>
        /// <param name="order_no">Order Number</param>
        public IHttpActionResult GetOrderDetail(int order_no)
        {
            return Ok(order_service.GetOrderDetail(order_no));
        }

        /// <summary>
        /// Get Header Order All.
        /// </summary>
        public IHttpActionResult GetOrderHeaderAll()
        {
            return Ok(order_service.GetOrderHeaderAll());
        }


        /// <summary>
        /// Create Order >> Not pass Order no and Order Status.
        /// </summary>
        /// <param name="order">Order Data</param>
        [HttpPost]
        public IHttpActionResult CreateOrder(Order order)
        {
            return Ok(order_service.CreateOrder(order));
        }
    }
}
