using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("customers")]
        public IActionResult List()
        {
            var customers = context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Title = "Customers";
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryID).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryID).ToList();
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerID == 0)
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Title = (customer.CustomerID == 0) ? "Add" : "Edit";
                ViewBag.Countries = context.Countries.OrderBy(c => c.CountryID).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            var customer = context.Customers.Find(id);
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryID).ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
    }
}
