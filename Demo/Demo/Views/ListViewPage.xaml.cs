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
            usedItemsListView.ItemsSource = _usedItemsService.GetAllUsedItems();
        }

        void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            usedItemsListView.ItemsSource = _usedItemsService.GetUsedItemsBySearch(e.NewTextValue);

            // hvis søgefelt er tomt kaldes OnPopulatingListView() -metoden
            if (e.NewTextValue == null)
            {
                OnPopulatingListView();
            }
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }
    }
}
