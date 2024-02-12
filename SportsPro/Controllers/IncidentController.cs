using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SportsPro.Models;


namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("incidents")]
        public IActionResult List()
        {
            var incident = context.Incidents
                                  .OrderBy(i => i.Title)
                                  .ToList();
            ViewBag.Title = "Incidents";
            ViewBag.customers = context.Customers.OrderBy(c => c.CustomerID).ToList();              // Added
            ViewBag.products = context.Products.OrderBy(p => p.ProductID).ToList();
            ViewBag.technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
            return View(incident);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            ViewBag.customers = context.Customers.OrderBy(c => c.CustomerID).ToList();              // Added
            ViewBag.products = context.Products.OrderBy(p => p.ProductID).ToList();
            ViewBag.technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            ViewBag.customers = context.Customers.OrderBy(c => c.CustomerID).ToList();          //Added
            ViewBag.products = context.Products.OrderBy(p => p.ProductID).ToList();
            ViewBag.technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident) 
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                    context.Incidents.Add(incident);
                else
                    context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Title = (incident.IncidentID == 0) ? "Add" : "Edit";
                ViewBag.customers = context.Customers.OrderBy(c => c.CustomerID).ToList();
                ViewBag.products = context.Products.OrderBy(p => p.ProductID).ToList();
                ViewBag.technicians = context.Technicians.OrderBy(t => t.TechnicianID).ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            ViewBag.customers = context.Customers.OrderBy(c => c.CustomerID).ToList();
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }
    }
}
