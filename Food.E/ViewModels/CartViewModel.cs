using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;

        public ObservableCollection<CartItem> CartItems { get; } = new ObservableCollection<CartItem>();

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        public ICommand RemoveCommand { get; }
        public ICommand CheckoutCommand { get; }

        public INavigation Navigation { get; set; }

        public CartViewModel(IDataService dataService)
        {
            _dataService = dataService;

            RemoveCommand = new Command<string>(async (itemId) => await RemoveItemAsync(itemId));
            CheckoutCommand = new Command(async () => await CheckoutAsync());

            LoadCartItemsAsync();
        }

        private async Task LoadCartItemsAsync()
        {
            CartItems.Clear();
            var items = await _dataService.GetCartItemsAsync();
            foreach (var item in items)
            {
                CartItems.Add(item);
            }
            TotalPrice = await _dataService.GetTotalPriceAsync();
        }

        private async Task RemoveItemAsync(string itemId)
        {
            await _dataService.RemoveFromCartAsync(itemId);
            await LoadCartItemsAsync();
        }

        private async Task CheckoutAsync()
        {
            if (Navigation != null)
            {
                await Navigation.PushAsync(new Views.CheckoutPage());
            }
        }
    }
}
