namespace Core;

public abstract partial class BaseItemViewModel<T>: BaseDataViewModel<T> where T : class
{
    [ObservableProperty]
    T? _item;

    protected override Task SetDataLoadedAsync(T data)
        => Task.FromResult(Item = data);
}
