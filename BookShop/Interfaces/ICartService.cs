namespace Book_Shop.Interfaces
{
    public interface ICartService
    {
        int GetCartSize(HttpContext httpContext);
    }

}
