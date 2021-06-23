using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;


namespace CoinpaprikaApp.Models
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;

        public DBManager()
        {
            _connection = DependencyService.Get<SQLiteDBInterface>().GetConnection();
        }

        public async Task<ObservableCollection<DBTable>> CreateTable()
        {
            await _connection.CreateTableAsync<DBTable>();
            var storedCoins = await _connection.Table<DBTable>().ToListAsync();
            var favorites = new ObservableCollection<DBTable>(storedCoins);
            return favorites;
        }

        public void addToFavorites(DBTable coin)
        {
            _connection.InsertAsync(coin);
        }

        public void removeFromFavorites(DBTable coin)
        {
            _connection.DeleteAsync(coin);
        }
    }
}
