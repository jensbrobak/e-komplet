using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using demo.Android;

[assembly: Dependency(typeof(SQLiteDb))]

namespace demo.Android
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "demodb.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

