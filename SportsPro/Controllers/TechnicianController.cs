using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
        }
        [Route("technicians")]
        public IActionResult List()
        {
            var technician = context.Technicians.Where(t => t.Name != "Not assigned").OrderBy(p => p.Name).ToList();
            ViewBag.Title = "Technician";
            return View(technician);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("EditTechnician", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var technician = context.Technicians.Find(id);
            return View("EditTechnician", technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianID == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Title = (technician.TechnicianID == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            var technician = context.Technicians.Find(id);
            return View("DeleteTechnician", technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}
