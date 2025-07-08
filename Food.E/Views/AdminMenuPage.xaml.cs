using System;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class AdminMenuPage : ContentPage
    {
        private readonly RestaurantAdminService _adminService;

        public AdminMenuPage()
        {
            InitializeComponent();
            _adminService = new RestaurantAdminService();
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            MenuItemsCollectionView.ItemsSource = _adminService.GetMenuItems();
        }

        private async void OnAddNewClicked(object sender, EventArgs e)
        {
            // Navigate to a page to add new menu item (to be implemented)
            await DisplayAlert("Info", "Add new menu item feature to be implemented.", "OK");
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(itemId))
            {
                // Navigate to edit menu item page (to be implemented)
                await DisplayAlert("Info", $"Edit menu item {itemId} feature to be implemented.", "OK");
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(itemId))
            {
                _adminService.RemoveMenuItem(itemId);
                LoadMenuItems();
            }
        }
    }
}
