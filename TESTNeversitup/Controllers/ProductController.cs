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

        [HttpPost]
        public IHttpActionResult AddNewProduct(ProductMaster product)
        {
            return Ok(product_service.AddNewProduct(product));
        }

        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductMaster product)
        {
            return Ok(product_service.UpdateProduct(product));
        }

        public IHttpActionResult DeleteProduct(string product_id)
        {
            return Ok(product_service.DeleteProduct(product_id));
        }

        public IHttpActionResult GetProductByID(string product_id)
        {
            return Ok(product_service.GetProductByID(product_id));
        }

        public IHttpActionResult GetProductAll()
        {
            return Ok(product_service.GetProductAll());
        }


        //This Method return only column product_id 
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
