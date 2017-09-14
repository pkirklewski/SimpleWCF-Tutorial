using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {

        public List<string> ListProducts()
        {

            Console.WriteLine("ListProducts() has been called by the client");

            List<string> productList = new List<string>();

                try
                {
                    using (ProductsEntities database = new ProductsEntities())
                    {
                        var products = from p in database.Products select p.ProductID.ToString() + " | " + p.ProductName + " | " + p.Price.ToString() + " | " + p.ProductDescription.ToString();
                        //var pDescription = from p in database.Products select p.ProductDescription.ToString();
                        
                        productList = products.ToList();
                    }
                }
                catch (Exception)
                {
                
                    throw;
                }
                return productList;
        }
    }
}
