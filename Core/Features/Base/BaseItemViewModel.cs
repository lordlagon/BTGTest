namespace Core;

public abstract partial class BaseItemViewModel<T>(INavigationService navigationService)
        : BaseDataViewModel<T>(navigationService) where T : class
{
    [ObservableProperty]
    T? _item;

    protected override Task SetDataLoadedAsync(T data)
        => Task.FromResult(Item = data);
}
