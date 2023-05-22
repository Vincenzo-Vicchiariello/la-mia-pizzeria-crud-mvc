using LaMiaPizzeriaNuova.DataBase;
using LaMiaPizzeriaNuova.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "ADMIN")]

        public IActionResult CreatePizza()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePizza(PizzaModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePizza", data);
            }
            using (PizzaContext context = new PizzaContext())
            {
                PizzaModel pizzaToCreate = new PizzaModel();
                pizzaToCreate.Name = data.Name;
                pizzaToCreate.Description = data.Description;
                pizzaToCreate.ImgSource = data.ImgSource;
                pizzaToCreate.Price = data.Price;
                context.Pizze.Add(pizzaToCreate);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult ModifyPizza(int Id)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                PizzaModel? pizzaToModify = ctx.Pizze.Where(pizza => pizza.Id == Id).FirstOrDefault();
                if (pizzaToModify != null)
                {
                    return View(pizzaToModify);
                }
            }
            return NotFound("Questa pizza non esiste..");
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult ModifyPizza(int Id, PizzaModel ModifiedPizza)
        {

            if (ModelState.IsValid)
            {
                using (PizzaContext context = new PizzaContext())
                {
                    PizzaModel? pizzaToModify = context.Pizze.Where(pizza => pizza.Id == Id).FirstOrDefault();
                    if (pizzaToModify != null)
                    {
                        pizzaToModify.Name = ModifiedPizza.Name;
                        pizzaToModify.Description = ModifiedPizza.Description;
                        pizzaToModify.ImgSource = ModifiedPizza.ImgSource;
                        pizzaToModify.Price = ModifiedPizza.Price;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("Questa pizza non esiste..");
                    }
                }

            }
            else return View(ModifiedPizza);


        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult DestroyPizza(int Id)
        {
            using (PizzaContext context = new PizzaContext())
            {

                PizzaModel? pizzaToDestroy = context.Pizze.Where(pizza => pizza.Id == Id).FirstOrDefault();

                if (pizzaToDestroy != null)
                {
                    context.Remove(pizzaToDestroy);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Non c'è una pizza da cancellare con questo ID.");
                }
            }


        }

    }

}
