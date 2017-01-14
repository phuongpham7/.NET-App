using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
        public List<string> ListProducts()
        {
            Console.WriteLine("ListProducts() has been called by a client");
            List<string> productsList = new List<string>();
            try
            {
                using(AdventureWorksEntities database = new AdventureWorksEntities())
                {
                    /*
                    var products = from p in database.Products
                                   select p.ProductNumber;

                    foreach(var p in database.Products)
                    {
                        productsList.Add(p.ProductNumber);
                    }

                    productsList = productsList.ToList();
                    */
                    foreach(var p in database.Products)
                    {
                        productsList.Add(p.ProductNumber);
                    }
                }
            }
            catch
            {

            }
            return productsList;
        }

        public ProductData GetProduct(string productNumber)
        {
            ProductData productData = null;
            try
            {
                using (AdventureWorksEntities database = new AdventureWorksEntities())
                {
                    Product matchingProduct = database.Products.First(p => p.ProductNumber == productNumber);

                    productData = new ProductData();
                    productData.Name = matchingProduct.Name;
                    productData.ProductNumber = matchingProduct.ProductNumber;
                    productData.ListPrice = matchingProduct.ListPrice;
                    productData.Color = matchingProduct.Color;
                }
            }
            catch
            {

            }

            return productData;
        }
    }
}
