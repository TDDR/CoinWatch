using SQLite;

namespace CoinpaprikaApp.Models
{
    public interface SQLiteDBInterface
    {
        SQLiteAsyncConnection GetConnection();
    }
}
