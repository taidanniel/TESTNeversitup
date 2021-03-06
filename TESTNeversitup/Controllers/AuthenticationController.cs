﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TESTNeversitup.Models;
using TESTNeversitup.Services;

namespace TESTNeversitup.Controllers
{
    public class AuthenticationController : ApiController
    {
        private AuthenticationService authen_service = new AuthenticationService();

        /// <summary>
        /// Register User.
        /// </summary>
        /// <param name="user_profile">User Profile Data.</param>
        [HttpPost]
        public IHttpActionResult Register(UserProfile user_profile)
        {
            return Ok(authen_service.Register(user_profile));
        }

        /// <summary>
        /// Log In.
        /// </summary>
        /// <param name="data">Log In Data</param>
        [HttpPost]
        public IHttpActionResult Login(Login data)
        {
            return Ok(authen_service.Login(data));
        }
    }
}
