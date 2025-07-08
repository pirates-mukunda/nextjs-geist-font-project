using System;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class RiderDashboardPage : ContentPage
    {
        private readonly RiderService _riderService;

        public RiderDashboardPage()
        {
            InitializeComponent();
            _riderService = new RiderService();
            LoadAssignedOrders();
        }

        private void LoadAssignedOrders()
        {
            AssignedOrdersCollectionView.ItemsSource = _riderService.GetAssignedOrders();
        }

        private async void OnUpdateStatusClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var orderId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(orderId))
            {
                var order = _riderService.GetAssignedOrders().Find(o => o.Id == orderId);
                if (order != null)
                {
                    var newStatus = order.Status == "Out for Delivery" ? "Delivered" : "Out for Delivery";
                    _riderService.UpdateOrderStatus(orderId, newStatus);
                    LoadAssignedOrders();
                    await DisplayAlert("Status Updated", $"Order status changed to {newStatus}.", "OK");
                }
            }
        }
    }
}
