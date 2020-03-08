using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTNeversitup.Dao;
using TESTNeversitup.Models;

namespace TESTNeversitup.Services
{
    public class AuthenticationService
    {
        private AuthenticationDao authendao = new AuthenticationDao();

        public ResponseMessage Register(UserProfile regis)
        {
            return authendao.Register(regis);
        }

        public UserProfile GetProfile(string id)
        {
            return authendao.GetProfile(id);
        }

        public UserProfile Login(Login login)
        {
            return authendao.Login(login);
        }
    }
}