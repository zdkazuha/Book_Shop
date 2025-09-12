using Book_Shop;
using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Book_Shop.Models.Expensions;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                .Include(i => i.Genres)
                .ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var book = db.Books.Find(id);

            if (book == null) return NotFound();

            db.Books.Remove(book);
            db.SaveChanges();

            TempData.Set(ToastContains.ToastMessage, new ToastModel("Book deleted successfully"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetValueToViewBag();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {

            if (!ModelState.IsValid)
            {
                SetValueToViewBag();

                return View(book);
            }

            db.Books.Add(book);
            db.SaveChanges();

            TempData.Set(ToastContains.ToastMessage, new ToastModel("Book created successfully"));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            if (book == null) return NotFound();

            SetValueToViewBag();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

            if (!ModelState.IsValid)
            {
                SetValueToViewBag();

                return View();
            }

            db.Books.Update(book);
            db.SaveChanges();

            TempData.Set(ToastContains.ToastMessage, new ToastModel("Book updated successfully"));

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = db.Books
                .Include(i => i.Trilogies)
                .Include(i => i.Author)
                .Include(i => i.Genres)
                .FirstOrDefault(i => i.Id == id);

            return View(model);
        }

        public IActionResult Favorites()
        {
            var model = db.Books
                .Include(i => i.Trilogies)
                .Include(i => i.Author)
                .Include(i => i.Genres)
                .ToList();

            return View(model);
        }


        private void SetValueToViewBag ()
        {
            var Genres = new SelectList(db.Genres.ToList(), "Id", "GenreName");
            var Trilogies = new SelectList(db.Trilogies.ToList(), "Id", "TrilogieName");
            var Authors = new SelectList(db.Authors.ToList(), "Id", "AuthorName");

            ViewBag.Genres = Genres;
            ViewBag.Trilogies = Trilogies;
            ViewBag.Authors = Authors;
        }
    }
}
