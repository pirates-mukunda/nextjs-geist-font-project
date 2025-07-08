using System;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class OrderTrackingPage : ContentPage
    {
        private readonly OrderService _orderService;

        public OrderTrackingPage()
        {
            InitializeComponent();
            _orderService = new OrderService();
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrdersCollectionView.ItemsSource = _orderService.GetOrders();
        }
    }
}
