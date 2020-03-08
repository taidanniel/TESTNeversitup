using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TESTNeversitup.Models;

namespace TESTNeversitup.Dao
{
    public class ProductManagementDao
    {
        private GlobalsDB Connection = new GlobalsDB();
        private ResponseMessage response = new ResponseMessage();

        public List<ProductMaster> GetProductAll()
        {
            ProductMaster product = null;
            List<ProductMaster> list_product = new List<ProductMaster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = "select * from product_master";
                    command.CommandText = sql;
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {

                        product = new ProductMaster()
                        {
                            Product_ID = dr["product_id"].ToString(),
                            Product_Name_TH = dr["product_name_th"].ToString(),
                            Product_Name_EN = dr["product_name_en"].ToString(),
                            Product_Price = Convert.ToDouble(dr["product_price"].ToString())
                        };
                        list_product.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list_product;
        }

        public ProductMaster GetProductByID(string id)
        {
            ProductMaster product = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format("select * from product_master where product_id = '{0}'", id);
                    command.CommandText = sql;
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        product = new ProductMaster()
                        {
                            Product_ID = dr["product_id"].ToString(),
                            Product_Name_TH = dr["product_name_th"].ToString(),
                            Product_Name_EN = dr["product_name_en"].ToString(),
                            Product_Price = Convert.ToDouble(dr["product_price"].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public ResponseMessage DeleteProduct(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format("delete from product_master where product_id = '{0}'", id);
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

        public ResponseMessage UpdateProduct(ProductMaster product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format(@"update product_master set
                                                 product_name_th = '{0}',
                                                 product_name_en = '{1}',
                                                 product_price = {2}
                                                 where product_id = '{3}'"
                                                 , product.Product_Name_TH
                                                 , product.Product_Name_EN
                                                 , product.Product_Price
                                                 , product.Product_ID);
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

        public ResponseMessage AddNewProduct(ProductMaster product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.Connection_String))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    string sql = string.Format(@"insert into product_master values ('{0}','{1}','{2}',{3})"
                                                 , product.Product_ID
                                                 , product.Product_Name_TH
                                                 , product.Product_Name_EN
                                                 , product.Product_Price);
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
    }
}