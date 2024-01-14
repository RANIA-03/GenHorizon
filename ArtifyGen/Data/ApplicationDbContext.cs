using ArtifyGen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtifyGen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Message> Messages {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
