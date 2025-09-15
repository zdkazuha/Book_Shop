using Book_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Book_Shop.Extensions;
using Microsoft.EntityFrameworkCore;
using Book_Shop.Interfaces;
namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public ActionResult Index()
        {
            var books = cartService.GetBooks();

            return View(books);
        }

        public ActionResult Add(int id)
        {
            cartService.Add(id);

            return RedirectToAction("Index", controllerName: "Home");
        }

        public ActionResult Remove(int id, string returnUrl, string returnControllerName)
        {
            cartService.Remove(id);

            return RedirectToAction(returnUrl, controllerName: returnControllerName);
        }

        public ActionResult Clear()
        {
            cartService.Clear();

            return RedirectToAction("Index");
        }
    }
}
