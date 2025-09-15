using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Book_Shop.Extensions;
using Book_Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoritesService favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        public ActionResult Index()
        {
            var books = favoritesService.GetFavorites();

            return View(books);
        }

        public ActionResult Add(int id)
        {
            favoritesService.Add(id);
            var book = favoritesService.GetFavorite(id);

            return RedirectToAction("Details", controllerName: "Books", book);
        }

        public ActionResult Remove(int Id)
        {
            favoritesService.Remove(Id);

            return RedirectToAction("Details", "Books", new { id = Id });
        }

        public ActionResult Clear()
        {
            favoritesService.Clear();
            return RedirectToAction("Index");
        }
    }
}
