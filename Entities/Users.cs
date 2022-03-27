using Microsoft.AspNetCore.Identity;


namespace Entities
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }
    }
}
