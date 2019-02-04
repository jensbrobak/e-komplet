using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.Services;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class ListViewItemPage : ContentPage
    {
        private ItemService _itemsService;

        public ListViewItemPage()
        {
            InitializeComponent();

            _itemsService = new ItemService();
        }

        protected override void OnAppearing()
        {
            OnPopulatingListView();
        }

        void OnPopulatingListView()
        {
            itemsListView.ItemsSource = _itemsService.GetAllItems();
        }

        async void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (itemsListView.SelectedItem == null)
                return;

            var selectedItem = e.SelectedItem as Item;

            itemsListView.SelectedItem = null;

            var page = new OpenItemPage(selectedItem);
            page.ItemUpdated += (source, item) =>
            {
                selectedItem.ID = item.ID;
                selectedItem.Name = item.Name;
                selectedItem.Itemnumber = item.Itemnumber;
                selectedItem.ItemGroup = item.ItemGroup;
                selectedItem.Price = item.Price;
                selectedItem.ImageURL = item.ImageURL;
            };

            await Navigation.PushAsync(page);
        }
    }
}
