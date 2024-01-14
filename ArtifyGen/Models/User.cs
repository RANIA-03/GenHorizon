using Microsoft.AspNetCore.Identity;

namespace ArtifyGen.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string? ImageName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Image { get; set; }
    }
}
