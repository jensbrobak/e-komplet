using System;
using System.Collections.Generic;
using Demo.Models;
using SQLite;
using Xamarin.Forms;

namespace Demo.Services
{
    public class UsedItemService
    {
        private SQLiteAsyncConnection _connection;

        public UsedItemService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public List<UsedItem> GetAllUsedItems()
        {
            // linq query som nedhenter alle useditems til liste
            return _connection.Table<UsedItem>().ToListAsync().Result;
        }

        public List<UsedItem> GetAllUsedItemsByLatest()
        {
            // linq query som nedhenter 5 useditems til liste - hvorefter de bliver sorteret efter date
            return _connection.Table<UsedItem>().OrderByDescending(ui => ui.Date).Take(5).ToListAsync().Result;
        }

        public List<UsedItem> GetUsedItemsBySearch(string keyword)
        {
            // linq query som finder alle useditems ud fra name som starter med det indtastede keyword, hvor vi dertil ignorere case
            return _connection.Table<UsedItem>().Where(ui => ui.Name.StartsWith(keyword, StringComparison.CurrentCultureIgnoreCase)).ToListAsync().Result;
        }

        public void SaveUsedItem(UsedItem usedItem)
        {
            _connection.UpdateAsync(usedItem);
        }
    }
}
