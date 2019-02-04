using System;
using Demo.Models;
using Demo.Services;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class OpenItemPage : ContentPage
    {
        public event EventHandler<Item> ItemUpdated;
        private ItemService _itemsService;
        private UsedItemService _usedItemsService;
        private Item_WholesalerService _items_WholesalersService;
        int _wholesalerID;
        double _amount;

        public OpenItemPage(Item item)
        {
            InitializeComponent();

            _itemsService = new ItemService();
            _items_WholesalersService = new Item_WholesalerService();
            _usedItemsService = new UsedItemService();

            BindingContext = new Item
            {
                ID = item.ID,
                Name = item.Name,
                Itemnumber = item.Itemnumber,
                ItemGroup = item.ItemGroup,
                Price = item.Price,
                ImageURL = item.ImageURL
            };

            dropdownMenu.ItemsSource = _items_WholesalersService.GetAllWholesalersByItemID(item.Itemnumber);
            dropdownMenu.SelectedIndex = 0;

            usedItemModel.BindingContext = new UsedItem
            {
                WholesalerID = _wholesalerID,
                Name = item.Name,
                Itemnumber = item.Itemnumber,
                ItemGroup = item.ItemGroup,
                Price = item.Price,
                Amount = _amount
            };

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            //Picker picker = (Picker)sender;

            //var selectedItem = (Wholesaler)picker.SelectedItem;

            //_wholesalerID = selectedItem.ID;

        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var item = BindingContext as Item;

            var usedItem = usedItemModel.BindingContext as UsedItem;

            usedItem.Date = DateTime.UtcNow;

            var item_Wholesaler = new Item_Wholesaler
            {
                Itemnumber = item.Itemnumber,
                WholesalerID = _wholesalerID
            };

            _items_WholesalersService.SaveItem_Wholesaler(item_Wholesaler);
            _usedItemsService.SaveUsedItem(usedItem);

            await DisplayAlert("Bekræftelse", "Du har bestilt " + usedItem.Amount + " enheder af " + usedItem.Name + " materialet", "Ok");

            ItemUpdated?.Invoke(this, item);

            await Navigation.PopAsync();

            }

        }
    }
