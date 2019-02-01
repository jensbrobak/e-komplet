using SQLite;

namespace demo
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

