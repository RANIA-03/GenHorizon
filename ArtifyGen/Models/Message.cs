using System.ComponentModel.DataAnnotations;

namespace ArtifyGen.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string? ImageName { get; set; }

        public string? ContentType { get; set; }

        public byte[]? Image { get; set; }
        public bool IsUserMessage { get; set; }

        public bool IsBotResponse { get; set; }
    }
}
