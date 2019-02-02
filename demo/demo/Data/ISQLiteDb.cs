using SQLite;

namespace Demo
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

