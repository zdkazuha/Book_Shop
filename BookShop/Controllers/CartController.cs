using Book_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Book_Shop.Extensions;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly BookShopDbContext db;

        public CartController(BookShopDbContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var existingIds = HttpContext.Session.Get<List<int>>("CartIds") ?? new List<int>();

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
            var existingList = HttpContext.Session.Get<List<int>>("CartIds");

            List<int> ids = existingList ?? new List<int>();

            if(!ids.Contains(id))
                ids.Add(id);

            HttpContext.Session.Set("CartIds", ids);

            return RedirectToAction("Index", controllerName: "Home");
        }

        public ActionResult Delete(int id)
        {
            var existingList = HttpContext.Session.Get<List<int>>("CartIds");

            List<int> ids = existingList ?? new List<int>();

            ids.Remove(id);

            HttpContext.Session.Set("CartIds", ids);

            return View();
        }

        public ActionResult GetBook(int id)
        {
            var existingIds = HttpContext.Session.Get<List<int>>("CartIds") ?? new List<int>();

            var books = db.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Trilogies)
                .Where(b => existingIds.Contains(b.Id))
                .FirstOrDefault(b => b.Id == id);

            return View(books);
        }

        public ActionResult Clear()
        {
            HttpContext.Session.Remove("CartIds");

            return RedirectToAction("Index");
        }
    }
}
