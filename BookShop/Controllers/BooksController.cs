using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {

        private readonly BookShopDbContext db;

        public BooksController(BookShopDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.Books
                .Include(i => i.Trilogies)
                .Include(i => i.Author)
                .ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var book = db.Books.Find(id);

            if (book == null) return NotFound();

            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
