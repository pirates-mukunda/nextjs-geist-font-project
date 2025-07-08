using System;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class CreatePostPage : ContentPage
    {
        private readonly CommunityService _communityService;

        public event EventHandler PostCreated;

        public CreatePostPage(CommunityService communityService)
        {
            InitializeComponent();
            _communityService = communityService;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            var content = PostContentEditor.Text;
            if (!string.IsNullOrWhiteSpace(content))
            {
                var newPost = new CommunityPost
                {
                    UserId = "currentUser", // Replace with actual user id
                    Content = content
                };
                _communityService.AddPost(newPost);
                PostCreated?.Invoke(this, EventArgs.Empty);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Post content cannot be empty.", "OK");
            }
        }
    }
}
