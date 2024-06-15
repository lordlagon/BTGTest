namespace Core;

public abstract partial class BaseListViewModel<T> : BaseDataViewModel<IEnumerable<T>> where T : class
{
    [ObservableProperty]
    ObservableCollection<T>? items;

    [ObservableProperty]
    T? _selectedItem;

    protected BaseListViewModel() => Init();

    void Init()
    {
        Items = [];
        // Garante que as collections sao thread safe
        // https://codetraveler.io/2019/09/11/using-observablecollection-in-a-multi-threaded-xamarin-forms-application/
        BindingBase.EnableCollectionSynchronization(Items, null, delegate (IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            lock (Items)
            {
                accessMethod?.Invoke();
            }
        });
    }

    protected override async Task SetDataLoadedAsync(IEnumerable<T> data)
    {        
        Items ??= [];
        Items.Clear();
        foreach (var item in data)
            Items.Add(item);
    }
    [RelayCommand]
    protected virtual async Task ItemClick(T item)
    {
        SelectedItem = item;
    }
}
