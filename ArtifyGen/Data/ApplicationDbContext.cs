using ArtifyGen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtifyGen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<User> Users {  get; set; }
        DbSet<Message> Messages {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
