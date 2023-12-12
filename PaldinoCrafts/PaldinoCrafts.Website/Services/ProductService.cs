using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using PaldinoCrafts.Website.Models;
using PaldinoCrafts.Website.Util;

namespace PaldinoCrafts.WebSite.Services
{
    public class ProductService
    {
        public ProductService(IWebHostEnvironment webhost_environment)
        {
            WebHostEnvironment = webhost_environment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private String data_filename => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        public IEnumerable<Product> GetProducts() =>  ProductUtils.readProducts(data_filename);
        
        /// <summary>
        /// Adds a rating to the given product.
        /// </summary>
        public void AddRating(String productID, int rating)
        {
            IEnumerable<Product> products = GetProducts();
            Product rated_product = products.First(x => x.ID == productID);

            //Only 1 to 5 allowed.
            rating = rating < 1 ? 1 : rating;
            rating = rating > 5 ? 5 : rating;

            if (rated_product.Ratings == null){products.First(x => x.ID == productID).Ratings = new int[] { rating };}
            else
            {
                List<int> ratings = rated_product.Ratings.ToList();
                ratings.Add(rating);
                rated_product.Ratings = ratings.ToArray();
            }

            ProductUtils.writeProducts(data_filename, products);
        }
    }
}