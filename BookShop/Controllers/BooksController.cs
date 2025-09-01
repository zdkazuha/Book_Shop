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
            Console.WriteLine("dasd");
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            db.Books.Add(book);
            db.SaveChanges();
            Console.WriteLine("dasd");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            db.Books.Update(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = db.Books
                .Include(i => i.Trilogies)
                .Include(i => i.Author)
                .FirstOrDefault(i => i.Id == id);

            return View(model);
        }
    }
}
