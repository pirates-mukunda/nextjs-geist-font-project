using System;
using System.Collections.Generic;

namespace Food.E.Models
{
    public class CommunityPost
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Comment> Comments { get; set; }

        public CommunityPost()
        {
            Comments = new List<Comment>();
            CreatedAt = DateTime.Now;
        }
    }
}
