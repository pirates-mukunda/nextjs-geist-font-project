using Food.E.Services;
using Food.E.ViewModels;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            var dataService = new SqlDataService();
            var viewModel = new CartViewModel(dataService)
            {
                Navigation = this.Navigation
            };
            BindingContext = viewModel;
        }
    }
}
