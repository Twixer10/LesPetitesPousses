namespace LPPMaUI.Repositories.Interfaces;

public interface IRepository<T> where T : class, new()
{
    Task DeleteItem(Guid id);
    Task<T> GetItem(Guid id);
    Task<List<T>> GetItems();
    Task<T> UpdateItem(T item);
    Task<T> SaveItem(T item);

}