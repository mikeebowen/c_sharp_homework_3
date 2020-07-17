using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        private static IEnumerable<Product> products;
        private static DateTime previous;
        public IEnumerable<Product> Products
        {
            get
            {
                // Check if the MyProducts is NOT cached
                //HttpContext.Current.Cache.
                if (HttpContext.Current.Cache["MyProducts"] == null)
                {
                    var items = new[]
                    {
                    new Product{ Name = "Baseball"},
                    new Product{ Name="Football"},
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                    // Why doesn't this work?
                    HttpContext.Current.Cache.Insert("MyProducts",
                                             items,
                                             null,
                                             System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(60));
                }

                return (IEnumerable<Product>)HttpContext.Current.Cache["MyProducts"];
            }
        }
    }
}