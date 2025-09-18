using Microsoft.AspNetCore.Identity;

namespace Book_Shop.Data.Entities
{
    public class User : IdentityUser
    {
        public string? Country { get; set; }
    }
}
