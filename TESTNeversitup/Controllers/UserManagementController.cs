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
    public class UserManagementController : ApiController
    {
        private AuthenticationService authen_service = new AuthenticationService();
        private OrderManagementService order_service = new OrderManagementService();

        public IHttpActionResult GetProfile(string user_id)
        {
            return Ok(authen_service.GetProfile(user_id));
        }


        public IHttpActionResult GetOrderHitory(string user_id)
        {
            return Ok(order_service.GetOrderHeaderByUserID(user_id));
        }

    }
}
