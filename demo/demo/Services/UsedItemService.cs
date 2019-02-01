using System;
using System.Collections;
using System.Threading.Tasks;
using demo.models;
using SQLite;
using Xamarin.Forms;

namespace demo.Services
{
    public class UsedItemService
    {
        private SQLiteAsyncConnection _connection;

        public UsedItemService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<IList> ShowAllUsedItems()
        {
            var usedItems = await _connection.Table<UsedItem>().ToListAsync();

            return usedItems;
        }
    }
}
