using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDay1.Models;

namespace WebApiDay1.Controllers
{
    public class ProductNewController : ApiController
    {
        static List<Product> _productList = null;
       
        void Initialize()
        {
            _productList = new List<Product>()
            {
                new Product(){Id=1, Name="iphone" , QtyInStock=10, Description="Apple Product", Supplier="Broadcom"},
                new Product(){Id=2, Name="MI 10" , QtyInStock=15, Description="Xioami Product", Supplier="Mi"},
                new Product(){Id=3, Name="Oppo" , QtyInStock=20, Description="Oppo Product", Supplier="Oppo"}
            };
        }
        public ProductNewController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }
        // GET: api/ProductNew
        public IHttpActionResult Get()
        {

            return Ok(_productList);
        }

        // GET: api/ProductNew/5
        public IHttpActionResult Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.Id == id);
            if(product== null)
            { 
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        // POST: api/ProductNew
        public IHttpActionResult Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Content(HttpStatusCode.Created, "Record Created");

        }

        // PUT: api/ProductNew/5
        public IHttpActionResult Put(int id, Product objProduct)
        {
            Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
            if(product==null)
            {
                return NotFound();
            }
            else
            {
                foreach (Product temp in _productList)
                {
                    if (temp.Id == id)
                    {
                        temp.Name = objProduct.Name;
                        temp.QtyInStock = objProduct.QtyInStock;
                        temp.Description = objProduct.Description;
                        temp.Supplier = objProduct.Supplier;
                    }
                }
                return Content(HttpStatusCode.OK,"Data Modified");
            }
        }

        // DELETE: api/ProductNew/5
        public IHttpActionResult Delete(int? id)
        {

            if(id!=null)
            {
                Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    _productList.Remove(product);
                    return Content(HttpStatusCode.OK,"Data Deleted");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,"Please Provide Id");
            }
        }
    }
}
