using Book_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Book_Shop.Extensions;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly BookShopDbContext db;

        public FavoritesController(BookShopDbContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var existingIds = HttpContext.Session.Get<List<int>>("FavoritesBooksIds") ?? new List<int>();

            var books = db.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Trilogies)
                .Where(b => existingIds.Contains(b.Id))
                .ToList();

            return View(books);
        }

        public ActionResult Add(int id)
        {
            var existingList = HttpContext.Session.Get<List<int>>("FavoritesBooksIds");

            List<int> ids = existingList ?? new List<int>();

            if (!ids.Contains(id))
                ids.Add(id);

            HttpContext.Session.Set("FavoritesBooksIds", ids);

            return RedirectToAction("Index", controllerName: "Home");
            //return View(id);
        }

        public ActionResult Delete(int id)
        {
            var existingList = HttpContext.Session.Get<List<int>>("FavoritesBooksIds");

            List<int> ids = existingList ?? new List<int>();

            ids.Remove(id);

            HttpContext.Session.Set("FavoritesBooksIds", ids);

            return View();
        }
    }
}
