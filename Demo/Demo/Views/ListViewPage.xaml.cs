using System;
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

        void OnAdd(object sender, System.EventArgs e)
        {
        }

    }
}
