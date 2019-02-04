using System.Collections.Generic;
using Demo.Models;
using SQLite;
using Xamarin.Forms;

namespace Demo.Services
{
    public class ItemService
    {
        private SQLiteAsyncConnection _connection;

        public ItemService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public List<Item> GetAllItems()
        {
            // linq query som nedhenter alle items til liste
            return _connection.Table<Item>().ToListAsync().Result;
        }

    }
}
