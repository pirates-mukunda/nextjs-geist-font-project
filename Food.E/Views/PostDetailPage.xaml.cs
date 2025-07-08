using System;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class PostDetailPage : ContentPage
    {
        private readonly CommunityService _communityService;
        private readonly CommunityPost _post;

        public PostDetailPage(string postId, CommunityService communityService)
        {
            InitializeComponent();
            _communityService = communityService;
            _post = _communityService.GetPostById(postId);
            LoadPostDetails();
        }

        private void LoadPostDetails()
        {
            if (_post != null)
            {
                PostContentLabel.Text = _post.Content;
                PostDateLabel.Text = $"Posted on {_post.CreatedAt:MMM dd, yyyy HH:mm}";
                CommentsCollectionView.ItemsSource = _post.Comments;
            }
        }

        private void OnAddCommentClicked(object sender, EventArgs e)
        {
            var commentText = NewCommentEntry.Text;
            if (!string.IsNullOrWhiteSpace(commentText))
            {
                var comment = new Comment
                {
                    UserId = "currentUser", // Replace with actual user id
                    Content = commentText
                };
                _communityService.AddComment(_post.Id, comment);
                NewCommentEntry.Text = string.Empty;
                LoadPostDetails();
            }
        }
    }
}
