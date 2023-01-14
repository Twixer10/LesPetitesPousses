using LPPMaUI.Commons;
using LPPMaUI.Database.Interfaces;
using LPPMaUI.Repositories.Interfaces;
using SQLite;

namespace LPPMaUI.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{
    private readonly Lazy<SQLiteConnection> _databaseConnectionHolder;
    protected SQLiteConnection Database
    {
        get
        {
            var database = _databaseConnectionHolder.Value;
            database.CreateTable<T>();
            return database;
        }
    }

    public Repository(IDatabasePath path)
    {
        var dbPath = path.GetDatabasePath();
        _databaseConnectionHolder = new Lazy<SQLiteConnection>(() => new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache));
    }

    public virtual Task<List<T>> GetItems()
    {
        return Task.FromResult(Database.Table<T>().ToList());
    }

    public Task<T> GetItem(Guid id)
    {
        return Task.FromResult(Database.Get<T>(id));
    }

    public Task DeleteItem(Guid id)
    {
        Database.Delete<T>(id);
        return Task.CompletedTask;
    }

    public Task<T> UpdateItem(T item)
    {
        Database.Update(item);
        return Task.FromResult(item);
    }

    public Task<T> SaveItem(T item)
    {
        Database.Insert(item);
        return Task.FromResult(item);
    }
}
