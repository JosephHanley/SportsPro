﻿using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }
        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }
        [Route("products")]
        public IActionResult List()
        {
            var products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Title = "Products";
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                    context.Products.Add(product);
                else
                    context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            } else
            {
                ViewBag.Title = (product.ProductID == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
