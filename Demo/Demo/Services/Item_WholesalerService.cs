using System.Collections.Generic;
using Demo.Models;
using SQLite;
using Xamarin.Forms;

namespace Demo.Services
{
    public class Item_WholesalerService
    {
        private SQLiteAsyncConnection _connection;

        public Item_WholesalerService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public List<Wholesaler> GetAllWholesalersByItemID(string itemnumber)
        {
            // inner join
            var query = _connection.QueryAsync<Wholesaler>(
            "select Wholesalers.Name, Wholesalers.ID from Wholesalers"
            + " inner join Items_Wholesalers"
            + " on Items_Wholesalers.WholesalerID = Wholesalers.ID where Items_Wholesalers.Itemnumber = ?",
            itemnumber).Result;

            return query.ConvertAll(iw => new Wholesaler { Name = iw.Name, ID = iw.ID });
        }
    }
}
