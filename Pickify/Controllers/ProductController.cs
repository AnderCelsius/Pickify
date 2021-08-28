using Microsoft.AspNetCore.Mvc;
using Pickify.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Pickify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickify.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _product;
        public ProductController(IProductRepository productRepository)
        {
            _product = productRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var product = _product.GetProductsAsync().Result;
            return View(product);
        }

        [HttpGet("id")]
        public IActionResult Detail(string id)
        {
            var details = _product.GetAProduct(id);
            return View(details);
        }

    }
}
