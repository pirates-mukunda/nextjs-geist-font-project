using System;

namespace Food.E.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
