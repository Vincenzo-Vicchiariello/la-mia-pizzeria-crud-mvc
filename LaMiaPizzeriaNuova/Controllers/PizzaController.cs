using LaMiaPizzeriaNuova.DataBase;
using LaMiaPizzeriaNuova.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaNuova.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizze.ToList();
                return View(pizze);
            }
        }


        public IActionResult CreatePizza()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }
            using (PizzaContext context = new PizzaContext())
            {
                PizzaModel pizzaToCreate = new PizzaModel();
                pizzaToCreate.Name = data.Name;
                pizzaToCreate.Description = data.Description;
                context.PizzaContext.Add(pizzaToCreate);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }



    }
}
