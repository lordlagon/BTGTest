using System.Collections.Generic;

namespace Core;
public interface IGenericRepository<T> where T : IBaseModel
{
    void Store(T data);
    T FindById(string id);
    IEnumerable<T> FindAll();
    void Remove(params string[] ids);
    public IEnumerable<T> Entities { get; }
}
public class GenericRepository<T> : IGenericRepository<T> where T : IBaseModel
{
    readonly IStoreService _storeService;
    readonly List<T> _entities= [];
    public IEnumerable<T> Entities => _entities;
    public GenericRepository(IStoreService storeService)
    {
        _storeService = storeService;
        _storeService.Start();
    }

    void Load()
    {
        var collection = _storeService.Instance.GetCollection<T>(typeof(T).Name);
        var list = collection.Query().ToEnumerable();
        _entities.Clear();
        _entities.AddRange(list);        
    }

    public IEnumerable<T> FindAll()
    {
        Load();
        return Entities;
    }

    public void Store(T data)
    {
        var collection = _storeService.Instance.GetCollection<T>(typeof(T).Name);
        collection.Upsert(data);
        Load();
    }
    public void Remove(params string[] ids)
    {
        var collection = _storeService.Instance.GetCollection<T>(typeof(T).Name);
        collection.DeleteMany(w => ids.Contains(w.Id));
        Load();
    }

    public T FindById(string id)
    {
        var collection = _storeService.Instance.GetCollection<T>(typeof(T).Name);
        return collection.FindById(id);
    }
}
