using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTNeversitup.Dao;
using TESTNeversitup.Models;

namespace TESTNeversitup.Services
{
    public class ProductManagementService
    {
        private ProductManagementDao productdao = new ProductManagementDao();

        public List<ProductMaster> GetProductAll()
        {
            return productdao.GetProductAll();
        }

        public ProductMaster GetProductByID(string id)
        {
            return productdao.GetProductByID(id);
        }

        public ResponseMessage DeleteProduct(string id)
        {
            return productdao.DeleteProduct(id);
        }

        public ResponseMessage UpdateProduct(ProductMaster product)
        {
            return productdao.UpdateProduct(product);
        }

        public ResponseMessage AddNewProduct(ProductMaster product)
        {
            return productdao.AddNewProduct(product);
        }
    }
}