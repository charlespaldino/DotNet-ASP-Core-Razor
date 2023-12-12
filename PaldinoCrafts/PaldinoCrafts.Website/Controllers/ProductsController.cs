using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaldinoCrafts.Website.Models;
using PaldinoCrafts.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaldinoCrafts.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductService ProductService { get; }

        public ProductsController(ProductService product_service)
        {
            ProductService = product_service;
        }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        /// <summary>
        /// Adds a rating to the given rpodcut ID.
        /// May need SSL verification disabled if using PostMan.
        /// </summary>
        /// <param name="rating">1 to 5</param>
        /// <returns>1 if OK</returns>
        [Route("Rate")]
        [HttpPost]
        public ActionResult Post([FromQuery] String product_id, [FromQuery] int rating)
        {
            ProductService.AddRating(product_id, rating);

            return Ok();
        }
    }
}
