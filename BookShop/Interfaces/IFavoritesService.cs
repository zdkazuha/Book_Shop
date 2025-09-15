using Book_Shop.Data.Entities;

namespace Book_Shop.Interfaces
{
    public interface IFavoritesService
    {
        int GetFavoritesSize();

        void Add(int id);

        void Remove(int id);
        void Clear();

        List<Book> GetFavorites();
        Book GetFavorite(int id);

        bool IsInFavorite(int id);
    }

}
