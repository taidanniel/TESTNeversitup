using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Npgsql;
using TESTNeversitup.Models;

namespace TESTNeversitup.Dao
{
    public class OrderManagementDao
    {
        private GlobalsDB Connection = new GlobalsDB();

        private ResponseMessage response = new ResponseMessage();
        public List<OrderHeader> GetOrderHeaderByUserID(string user_id)
        {
            OrderHeader order_header = null;
            List<OrderHeader> list_order = new List<OrderHeader>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    NpgsqlCommand command = connection.CreateCommand();
                    string sql = string.Format("select * from order_header where created_by = '{0}'", user_id);
                    command.CommandText = sql;
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        order_header = new OrderHeader()
                        {
                            Order_No = Convert.ToInt32(dr["order_no"].ToString()),
                            Order_Status = dr["order_status"].ToString(),
                            Created_by = dr["created_by"].ToString(),
                        };
                        list_order.Add(order_header);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list_order;
        }
        public List<OrderHeader> GetOrderHeaderAll()
        {
            OrderHeader order_header = null;
            List<OrderHeader> list_order = new List<OrderHeader>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    NpgsqlCommand command = connection.CreateCommand();
                    string sql = "select * from order_header";
                    command.CommandText = sql;
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        order_header = new OrderHeader()
                        {
                            Order_No = Convert.ToInt32(dr["order_no"].ToString()),
                            Order_Status = dr["order_status"].ToString(),
                            Created_by = dr["created_by"].ToString(),
                        };
                        list_order.Add(order_header);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list_order;
        }
        public List<OrderDetail> GetOrderDetail(int order_no)
        {
            OrderDetail order_detail = null;
            List<OrderDetail> list_detail = new List<OrderDetail>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    NpgsqlCommand command = connection.CreateCommand();
                    string sql = string.Format("select * from order_detail where order_no = {0}", order_no);
                    command.CommandText = sql;
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        order_detail = new OrderDetail()
                        {
                            Order_No = Convert.ToInt32(dr["order_no"].ToString()),
                            Item_No = Convert.ToInt32(dr["item_no"].ToString()),
                            Product_ID = dr["product_id"].ToString(),
                            Amount = Convert.ToDouble(dr["amount"].ToString()),
                            QTY = Convert.ToDouble(dr["qty"].ToString()),
                            Total_Amount = Convert.ToDouble(dr["total_amount"].ToString()),
                            Vat = Convert.ToDouble(dr["vat"].ToString())
                        };
                        list_detail.Add(order_detail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list_detail;
        }
        public ResponseMessage CancelOrder(int order_no)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    NpgsqlCommand command = connection.CreateCommand();
                    string sql = string.Format(@"update order_header set
                                                 order_status = 'Cancel'
                                                 where order_no = {0}", order_no);
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

        public ResponseMessage CreateOrder(Order order)
        {
            Random random = new Random();
            order.Order_No = random.Next(1000);
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    NpgsqlCommand command = connection.CreateCommand();
                    string sql = string.Format(@"insert into order_header values({0},'New','{1}')", order.Order_No, order.Created_by);
                    NpgsqlTransaction transaction;
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = sql;
                    try
                    {
                        command.ExecuteNonQuery();
                        for (int i = 0; i < order.Details.Count; i++)
                        {
                            command = connection.CreateCommand();
                            command.Transaction = transaction;
                            sql = string.Format(@"insert into order_detail values({0},{1},'{2}',{3},{4},{5},{6})"
                                        , order.Order_No
                                        , order.Details[i].Item_No
                                        , order.Details[i].Product_ID
                                        , order.Details[i].QTY
                                        , order.Details[i].Amount
                                        , order.Details[i].Total_Amount
                                        , order.Details[i].Vat);
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            
                        }
                        transaction.Commit();
                        response.Status = 200;
                        response.Description = "Created Order No : " + (order.Order_No).ToString() ;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 999;
                response.Description = ex.Message;
            }

            return response;
        }
    }
}