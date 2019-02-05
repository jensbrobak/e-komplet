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
        string _wholesalerName;
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
            Picker picker = (Picker)sender;

            var selectedItem = (Wholesaler)picker.SelectedItem;

            _wholesalerID = selectedItem.ID;
            _wholesalerName = selectedItem.Name;
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var item = BindingContext as Item;

            var usedItem = usedItemModel.BindingContext as UsedItem;

            usedItem.WholesalerID = _wholesalerID;

            usedItem.Date = DateTime.UtcNow;

            if(_amount == 0)
            {
                await DisplayAlert("Advarsel", "Du kan ikke bestille " + _amount + " enheder!", "Ok");
            }
            else
            {
                _usedItemsService.SaveUsedItem(usedItem);

                await DisplayAlert("Bekræftelse", "Du har bestilt " + usedItem.Amount + " enheder af " + usedItem.Name + " materialet fra " + _wholesalerName + "", "Ok");
            }

            ItemUpdated?.Invoke(this, item);

            await Navigation.PopAsync();

            }

        }
    }
