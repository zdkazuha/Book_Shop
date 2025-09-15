using Book_Shop.Data;
using Book_Shop.Data.Entities;
using Book_Shop.Extensions;
using Book_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly BookShopDbContext db;
        private readonly HttpContext httpContext;

        public FavoritesService() {}

        public FavoritesService(BookShopDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContext = httpContextAccessor.HttpContext ?? throw new Exception("httpContext is null");
        }

        public void Add(int id)
        {
            var existingList = httpContext.Session.Get<List<int>>("FavoritesIds");

            List<int> ids = existingList ?? new List<int>();

            if (!ids.Contains(id))
                ids.Add(id);

            httpContext.Session.Set("FavoritesIds", ids);
        }

        public void Remove(int id)
        {
            var existingList = httpContext.Session.Get<List<int>>("FavoritesIds");

            List<int> ids = existingList ?? new List<int>();

            ids.Remove(id);

            httpContext.Session.Set("FavoritesIds", ids);
        }

        public void Clear()
        {
            httpContext.Session.Remove("FavoritesIds");
        }

        public List<Book> GetFavorites()
        {
            var existingIds = httpContext.Session.Get<List<int>>("FavoritesIds") ?? new List<int>();

            var books = db.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Trilogies)
                .Where(b => existingIds.Contains(b.Id))
                .ToList();

            return books;
        }

        public Book GetFavorite(int id)
        {
            var book = db.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Trilogies)
                .FirstOrDefault(b => b.Id == id);

            return book;
        }

        public int GetFavoritesSize()
        {
            var existingList = httpContext.Session.Get<List<int>>("FavoritesIds") ?? new List<int>();

            return existingList?.Count ?? 0;
        }

        public bool IsInFavorite(int id)
        {
            var existingList = httpContext.Session.Get<List<int>>("FavoritesIds");

            List<int> ids = existingList ?? new List<int>();

            return ids.Contains(id);
        }

    }
}
