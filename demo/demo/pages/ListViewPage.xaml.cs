using System;
using System.Collections.Generic;
using demo.models;
using demo.Services;
using Xamarin.Forms;

namespace demo.pages
{

    public partial class ListViewPage : ContentPage
    {
        private UsedItemService _usedItemsService;

        public ListViewPage()
        {
            _usedItemsService = new UsedItemService();

            InitializeComponent();

            listView.ItemsSource = _usedItemsService.ShowAllUsedItems().Result;

        }
    }
}
