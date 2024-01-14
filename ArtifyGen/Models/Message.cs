using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtifyGen.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [ForeignKey("Id")]
        public string UserId { get; set; }
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
