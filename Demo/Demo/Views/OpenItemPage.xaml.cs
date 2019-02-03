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
        double _amount;

        public OpenItemPage(UsedItem usedItem)
        {
            InitializeComponent();

            _usedItemsService = new UsedItemService();

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
