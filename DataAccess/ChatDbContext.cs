using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ChatDbContext : IdentityDbContext<Users>
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options) { }

        

        public DbSet<Users> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
        
}
