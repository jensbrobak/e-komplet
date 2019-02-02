using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //OnCreateDb();

            MainPage = new ListViewPage();
        }
        
        public async void OnCreateDb()
        {

            // opretter forbindelse til databasen
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            // opretter tabeller ud fra vores modeller
            await connection.CreateTableAsync<Item>();
            await connection.CreateTableAsync<UsedItem>();
            await connection.CreateTableAsync<Wholesaler>();

            // opretter test data ud fra de tre ovenstående entiteter
            var item1 = new Item
            {
                Name = "Skrue 3cm",
                ImageURL = "https://dummyimage.com/300x200/000/fff&text=Skrue3",
                ItemGroup = "Skruer",
                Itemnumber = "1-01",
                Price = 0.5,
            };

            var item2 = new Item
            {
                Name = "Skrue 5cm",
                ImageURL = "https://dummyimage.com/300x200/000/fff&text=Skrue5",
                ItemGroup = "Skruer",
                Itemnumber = "1-02",
                Price = 0.7
            };

            var usedItem1 = new UsedItem
            {
                Name = "Skrue 3cm",
                ItemGroup = "Skruer",
                Itemnumber = "1-01",
                Price = 1.0,
                Amount = 10.0,
                WholesalerID = 1,
                Date = DateTime.UtcNow
            };

            var usedItem2 = new UsedItem
            {
                Name = "Skrue 5cm",
                ItemGroup = "Skruer",
                Itemnumber = "1-02",
                Price = 1.0,
                Amount = 10.0,
                WholesalerID = 2,
                Date = DateTime.UtcNow
            };

            var wholesaler1 = new Wholesaler
            {
                Name = "E-Komplet varesalg",
                LogoURL = "https://dummyimage.com/300x200/000/fff&text=E-Komplet-Varesalg"
            };

            var wholesaler2 = new Wholesaler
            {
                Name = "E-Komplet'r'us",
                LogoURL = "https://dummyimage.com/300x200/000/fff&text=E-KompletRUS"
            };

            await connection.InsertAsync(item1);
            await connection.InsertAsync(item2);
            await connection.InsertAsync(usedItem1);
            await connection.InsertAsync(usedItem2);
            await connection.InsertAsync(wholesaler1);
            await connection.InsertAsync(wholesaler2);

        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
