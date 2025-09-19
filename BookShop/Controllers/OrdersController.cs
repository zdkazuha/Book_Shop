using Book_Shop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly BookShopDbContext db;

        public OrdersController(BookShopDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.Orders.ToList();

            return View(model);
        }
    }
}
