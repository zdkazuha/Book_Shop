using Book_Shop.Extensions;
using Book_Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop.Services
{
    public class FavoritesService
    {
        public int GetFavoritesSize(HttpContext httpContext)
        {
            var existingList = httpContext.Session.Get<List<int>>("FavoritesBooksIds");

            return existingList?.Count ?? 0;
        }

    }
}
