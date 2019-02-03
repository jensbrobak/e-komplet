using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.Services;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class OpenItemPage : ContentPage
    {
        public event EventHandler<UsedItem> UsedItemUpdated;
        private UsedItemService _usedItemsService;
        private WholesalerService _wholesalersService;
        double _amount;

        public OpenItemPage(UsedItem usedItem)
        {
            InitializeComponent();

            _usedItemsService = new UsedItemService();
            _wholesalersService = new WholesalerService();

            var wholeSaler = _wholesalersService.GetWholesalerByID(usedItem.WholesalerID);

            BindingContext = new UsedItem
            {
                ID = usedItem.ID,
                WholesalerID = usedItem.WholesalerID,
                Name = usedItem.Name,
                Itemnumber = usedItem.Itemnumber,
                ItemGroup = usedItem.ItemGroup,
                Price = usedItem.Price,
                Amount = usedItem.Amount,
                Date = usedItem.Date
            };

            wholesaler.BindingContext = new Wholesaler
            {
                ID = wholeSaler.ID,
                Name = wholeSaler.Name,
                LogoURL = wholeSaler.LogoURL
            };

            _amount = usedItem.Amount;
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var usedItem = BindingContext as UsedItem;

            if(usedItem.Amount > _amount)
            {
                await DisplayAlert("Advarsel", "Der er desværre ikke nok tilgængelige enheder af dette materiale!", "Ok");
            } 
            if(_amount == 0) 
            {
                await DisplayAlert("Advarsel", "Beholdning er tom - der skal bestilles flere enheder af dette materiale hjem!", "Ok");
            }
            else 
            {

                usedItem.Amount = _amount - usedItem.Amount;

                usedItem.Date = DateTime.UtcNow;

                _usedItemsService.SaveUsedItem(usedItem);

                await DisplayAlert("Bekræftelse", "Du har tilføjet " + usedItem.Amount + " enheder af " + usedItem.Name + " materialet til denne opgave", "Ok");

                UsedItemUpdated?.Invoke(this, usedItem);

                await Navigation.PopAsync();

            }


        }
    }
}
