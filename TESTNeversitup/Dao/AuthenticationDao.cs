using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TESTNeversitup.Models;

namespace TESTNeversitup.Dao
{
    public class AuthenticationDao
    {
        private GlobalsDB Connection = new GlobalsDB();
        private ResponseMessage response = new ResponseMessage();
        public ResponseMessage Register(UserProfile regis)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format("insert into user_profile values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        regis.FirstName, regis.LastName, regis.Mail, regis.User_ID, regis.Password, regis.Address, regis.Phone);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    response.Status = 200;
                    response.Description = "Success";
                }
            }
            catch (Exception ex)
            {
                response.Status = 999;
                response.Description = ex.Message;
            }

            return response;
        }
        public UserProfile Login(Login login)
        {
            UserProfile user_profile = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format("select top 1 * from user_profile where user_id='{0}' and password = '{1}'", login.User_ID, login.Password);
                    command.CommandText = sql;
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {

                        user_profile = new UserProfile()
                        {
                            FirstName = dr["firstname"].ToString(),
                            LastName = dr["lastname"].ToString(),
                            Mail = dr["mail"].ToString(),
                            User_ID = dr["user_id"].ToString(),
                            Address = dr["address"].ToString(),
                            Phone = dr["phone"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user_profile;
        }

        public UserProfile GetProfile(String user_id)
        {
            UserProfile user_profile = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format("select top 1 * from user_profile where user_id='{0}'", user_id);
                    command.CommandText = sql;
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {

                        user_profile = new UserProfile()
                        {
                            FirstName = dr["firstname"].ToString(),
                            LastName = dr["lastname"].ToString(),
                            Mail = dr["mail"].ToString(),
                            User_ID = dr["user_id"].ToString(),
                            Address = dr["address"].ToString(),
                            Phone = dr["phone"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user_profile;
        }
    }
}