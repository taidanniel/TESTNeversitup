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
    public class ProductController : ApiController
    {
       private ProductManagementService product_service = new ProductManagementService();

        /// <summary>
        /// Add New  Product.
        /// </summary>
        /// <param name="product">Product Data</param>
        [HttpPost]
        public IHttpActionResult AddNewProduct(ProductMaster product)
        {
            return Ok(product_service.AddNewProduct(product));
        }

        /// <summary>
        ///  Update Product.
        /// </summary>
        /// <param name="product">Product Data</param>
        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductMaster product)
        {
            return Ok(product_service.UpdateProduct(product));
        }

        /// <summary>
        ///  Delate Product.
        /// </summary>
        /// <param name="product_id">Product ID</param>
        public IHttpActionResult DeleteProduct(string product_id)
        {
            return Ok(product_service.DeleteProduct(product_id));
        }

        /// <summary>
        ///  Get Product By ID.
        /// </summary>
        /// <param name="product_id">Product ID</param>
        public IHttpActionResult GetProductByID(string product_id)
        {
            return Ok(product_service.GetProductByID(product_id));
        }

        /// <summary>
        ///  Get All Product Data.
        /// </summary>
        public IHttpActionResult GetProductAll()
        {
            return Ok(product_service.GetProductAll());
        }


        /// <summary>
        ///  Get All Product ID Only.
        /// </summary>
        public IHttpActionResult GetProductIDAll()
        {
            List<ProductMaster> list_product = product_service.GetProductAll();
            string[] list_product_id = new string[list_product.Count];
            for (int i=0;i<list_product.Count;i++)
            {
                list_product_id[i] = list_product[i].Product_ID;
            }
            return Ok(list_product_id);
        }
    }
}
