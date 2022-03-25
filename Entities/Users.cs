using Microsoft.AspNetCore.Identity;


namespace Entities
{
    public class Users : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
