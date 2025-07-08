using System;
using System.Collections.Generic;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class CommunityFeedPage : ContentPage
    {
        private readonly CommunityService _communityService;

        public CommunityFeedPage()
        {
            InitializeComponent();
            _communityService = new CommunityService();
            LoadPosts();
        }

        private void LoadPosts()
        {
            var posts = _communityService.GetAllPosts();
            PostsCollectionView.ItemsSource = posts;
        }

        private async void OnViewDetailsClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var postId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(postId))
            {
                await Navigation.PushAsync(new PostDetailPage(postId, _communityService));
            }
        }

        private async void OnCreatePostClicked(object sender, EventArgs e)
        {
            var createPostPage = new CreatePostPage(_communityService);
            createPostPage.PostCreated += (s, args) => LoadPosts();
            await Navigation.PushAsync(createPostPage);
        }
    }
}
