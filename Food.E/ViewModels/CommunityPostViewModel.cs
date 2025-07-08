using System.Windows.Input;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.ViewModels
{
    public class CommunityPostViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;

        private string _postContent;
        public string PostContent
        {
            get => _postContent;
            set => SetProperty(ref _postContent, value);
        }

        public ICommand SubmitCommand { get; }

        public INavigation Navigation { get; set; }

        public CommunityPostViewModel(IDataService dataService)
        {
            _dataService = dataService;
            SubmitCommand = new Command(async () => await SubmitPostAsync());
        }

        private async System.Threading.Tasks.Task SubmitPostAsync()
        {
            if (string.IsNullOrWhiteSpace(PostContent))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Post content cannot be empty.", "OK");
                return;
            }

            var newPost = new CommunityPost
            {
                UserId = "currentUser", // Replace with actual user id
                Content = PostContent
            };

            await _dataService.AddPostAsync(newPost);
            await Navigation.PopAsync();
        }
    }
}
