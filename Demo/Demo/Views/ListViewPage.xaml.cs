using System;
using Demo.Models;
using Demo.Services;
using Xamarin.Forms;

namespace Demo.Views
{

    public partial class ListViewPage : ContentPage
    {
        private UsedItemService _usedItemsService;

        public ListViewPage()
        {
            InitializeComponent();

            _usedItemsService = new UsedItemService();

            OnPopulatingListView();
        }

        protected override void OnAppearing()
        {
            OnPopulatingListView();
        }

        void OnPopulatingListView()
        {
            usedItemsListView.ItemsSource = _usedItemsService.GetAllUsedItemsByLatest();
        }

        void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            // nulstiller dropdown menu
            dropdownMenu.SelectedIndex = -1;

            usedItemsListView.ItemsSource = _usedItemsService.GetUsedItemsBySearch(e.NewTextValue);

            // hvis søgefelt er tomt kaldes OnPopulatingListView() -metoden
            if (e.NewTextValue == null)
            {
                OnPopulatingListView();
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            if (picker.SelectedIndex == 0)
            {
                usedItemsListView.ItemsSource = _usedItemsService.GetAllUsedItems();
            }
            if (picker.SelectedIndex == 1)
            {
                usedItemsListView.ItemsSource = _usedItemsService.GetAllUsedItemsByLatest();
            }

        }

        async void OnUsedItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (usedItemsListView.SelectedItem == null)
                return;

            var selectedUsedItem = e.SelectedItem as UsedItem;

            usedItemsListView.SelectedItem = null;

            var page = new OpenItemPage(selectedUsedItem);
            page.UsedItemUpdated += (source, usedItem) =>
            {
                selectedUsedItem.ID = usedItem.ID;
                selectedUsedItem.WholesalerID = usedItem.WholesalerID;
                selectedUsedItem.Name = usedItem.Name;
                selectedUsedItem.Itemnumber = usedItem.Itemnumber;
                selectedUsedItem.ItemGroup = usedItem.ItemGroup;
                selectedUsedItem.Price = usedItem.Price;
                selectedUsedItem.Amount = usedItem.Amount;
                selectedUsedItem.Date = usedItem.Date;
            };

            await Navigation.PushAsync(page);
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

    }
}
