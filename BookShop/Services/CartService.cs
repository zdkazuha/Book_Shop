using Book_Shop.Extensions;
using Book_Shop.Interfaces;

namespace Book_Shop.Services
{
    public class CartService : ICartService
    {
        public int GetCartSize(HttpContext httpContext)
        {
            var existingList = httpContext.Session.Get<List<int>>("CartIds");

            return existingList?.Count ?? 0;
        }
    }
}
