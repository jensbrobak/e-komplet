﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using HelloWorld.iOS;
using Demo;

[assembly: Dependency(typeof(SQLiteDb))]

namespace HelloWorld.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "DemoDb.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

