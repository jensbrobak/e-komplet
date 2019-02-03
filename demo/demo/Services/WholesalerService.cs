using System;
using System.Threading.Tasks;
using Demo.Models;
using SQLite;
using Xamarin.Forms;

namespace Demo.Services
{
    public class WholesalerService
    {
        private SQLiteAsyncConnection _connection;

        public WholesalerService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public Wholesaler GetWholesalerByID(int ID)
        {
            return _connection.Table<Wholesaler>().Where(ws => ws.ID.Equals(ID)).FirstOrDefaultAsync().Result;
        }
    }
}
