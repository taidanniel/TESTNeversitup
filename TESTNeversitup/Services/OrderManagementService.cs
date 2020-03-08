using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTNeversitup.Dao;
using TESTNeversitup.Models;

namespace TESTNeversitup.Services
{
    public class OrderManagementService
    {
        private OrderManagementDao orderdao = new OrderManagementDao();

        public ResponseMessage CancelOrder(int order_no)
        {
            return orderdao.CancelOrder(order_no);
        }

        public ResponseMessage CreateOrder(Order order)
        {
            return orderdao.CreateOrder(order);
        }

        public List<OrderHeader> GetOrderHeaderByUserID(string user_id)
        {
            return orderdao.GetOrderHeaderByUserID(user_id);
        }

        public List<OrderHeader> GetOrderHeaderAll()
        {
            return orderdao.GetOrderHeaderAll();
        }

        public List<OrderDetail> GetOrderDetail(int order_no)
        {
            return orderdao.GetOrderDetail(order_no);
        }
    }
}