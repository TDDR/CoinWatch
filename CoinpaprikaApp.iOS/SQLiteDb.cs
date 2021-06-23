using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using CoinpaprikaApp.Models;

[assembly: Dependency(typeof(CoinpaprikaApp.iOS.SQLiteDb))]
namespace CoinpaprikaApp.iOS
{
    public class SQLiteDb : SQLiteDBInterface
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(documentsPath, "Coins.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}