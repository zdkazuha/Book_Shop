using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Book_Shop.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly BookShopDbContext db;
        private readonly ICartService cartService;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public OrdersController(BookShopDbContext db, ICartService cartService)
        {
            this.db = db;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var orders = db.Orders
                .Include(x => x.OrderDetails)
                .Include(x => x.User)
                .Where(x => x.UserId == CurrentUserId)
                .ToList();

            return View(orders);
        }

        public IActionResult Add()
        {
            var Books = cartService.GetBooks();

            var order = new Order()
            {
                OrderDate = DateTime.UtcNow,
                TotalPrice = Books.Sum(x => x.Price),
                UserId = CurrentUserId
            };

            db.Orders.Add(order);
            db.SaveChanges();

            var orderDetails = new OrderDetails()
            {
                Quantity = 1,
                OrderId = order.Id,
                BookId = Books.First().Id,
            };

            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();

            cartService.Clear();

            return RedirectToAction("Index");
        }
    }
}
