using System;
using System.Collections.Generic;
using System.Linq;
using Food.E.Models;

namespace Food.E.Services
{
    public class CommunityService
    {
        private readonly List<CommunityPost> _posts;

        public CommunityService()
        {
            _posts = new List<CommunityPost>();
            SeedSampleData();
        }

        private void SeedSampleData()
        {
            var post1 = new CommunityPost
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "user1",
                Content = "Welcome to the Food.E community!",
            };
            post1.Comments.Add(new Comment
            {
                Id = Guid.NewGuid().ToString(),
                PostId = post1.Id,
                UserId = "user2",
                Content = "Thanks! Glad to be here."
            });

            _posts.Add(post1);
        }

        public List<CommunityPost> GetAllPosts()
        {
            return _posts.OrderByDescending(p => p.CreatedAt).ToList();
        }

        public CommunityPost GetPostById(string id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(CommunityPost post)
        {
            post.Id = Guid.NewGuid().ToString();
            post.CreatedAt = DateTime.Now;
            _posts.Insert(0, post);
        }

        public void AddComment(string postId, Comment comment)
        {
            var post = GetPostById(postId);
            if (post != null)
            {
                comment.Id = Guid.NewGuid().ToString();
                comment.PostId = postId;
                comment.CreatedAt = DateTime.Now;
                post.Comments.Add(comment);
            }
        }
    }
}
