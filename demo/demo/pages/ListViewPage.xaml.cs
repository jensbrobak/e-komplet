using System;
using System.Collections.Generic;
using demo.models;
using Xamarin.Forms;

namespace demo.pages
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<Item> {

                new Item { ID = 1, Name = "Skrue 3cm", Itemnumber = "1-01", ItemGroup = "Skruer", Price = 0.5, WholesalerIDs = 1, ImageURL = "https://dummyimage.com/300x200/000/fff&text=Skrue3"}

            };
        }
    }
}
