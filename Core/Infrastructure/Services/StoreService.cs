namespace Core;
public interface IStoreService
{
    void Start();
    void Dispose();
    void DeleteDataBase();
    ILiteDatabase Instance { get; }
}

public class StoreService : IStoreService
{
    static ILiteDatabase? _instance;
    static object _lock = new();

    public void Start()
    {
        lock (_lock)
        {
            Dispose();
            _instance = new LiteDatabase(new ConnectionString(Constants.Database) { Password = "#btg123*" });
        }
    }
    public bool IsInitialized => _instance != null;

    public ILiteDatabase Instance
    {
        get
        {
            lock (_lock)
                return _instance!;
        }
    }
    public void Dispose()
    {
        _instance?.Dispose();
        _instance = null;
    }
    public void DeleteDataBase()
    {
        if (_instance != null)
        {
            foreach (var collection in _instance.GetCollectionNames())
            {
                _instance.DropCollection(collection);
            }
        }
        Dispose();
        File.Delete(Constants.Database);
    }
}
