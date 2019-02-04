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

        public List<Item_Wholesaler> GetAllWholesalersByItemID(string itemnumber)
        {

            //    var iwQuery = _connection.Table<Item_Wholesaler>().Where(iw => iw.ItemID.Equals(itemID)).ToListAsync().Result;

            //    var q = _connection.QueryAsync<Item_Wholesaler>(
            //"select IW.Name from Wholesalers IW"
            //+ " inner join Items_Wholsalers MT"
            //+ " on MI.ResId = MT.ResId where MT.ThemeId = ?",
            //itemID).Result;
            //return q.ConvertAll(x => new Wholesaler { Name = x.Name, ResId = x.ResId, LoopStart = x.LoopStart });

            //var iwQuery = from iw in _connection.Table<Item_Wholesaler>()
            //where iw.ItemID == itemID
            ////join w in _connection.Table<Wholesaler>() on iw equals itemID 
            //select new Wholesaler()
            //{
            //    ID = itemID
            //};

            //            select Name from Wholesalers
            //inner join Items_Wholesalers
            //on ItemID where Items.ID = 1


            return _connection.Table<Item_Wholesaler>().Where(iw => iw.Itemnumber.Equals(itemnumber)).ToListAsync().Result;
        }

        public void SaveItem_Wholesaler(Item_Wholesaler item_Wholesaler)
        {
            _connection.InsertAsync(item_Wholesaler);
        }
    }
}
