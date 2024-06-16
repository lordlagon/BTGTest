namespace Core;

public abstract class BaseDataViewModel<T> : BaseViewModel where T : class
{
    bool _dataLoaded;
    public bool DataLoaded
    {
        get { return _dataLoaded; }
        private set { SetProperty(ref _dataLoaded, value); }
    }
    protected BaseDataViewModel(INavigationService navigationService) : base(navigationService) => Init();

    void Init()
    {
        DataLoaded = false;
    }
    public override Task InitializeAsync(object navigationData)
        => InitializeAsync();

    protected override Task InitializeAsync()
        => LoadDataAsync();

    protected abstract Task<T> GetDataAsync();
    protected abstract Task SetDataLoadedAsync(T data);    
    protected virtual Task OnDataLoadedAsync()
        => Task.FromResult(DataLoaded = true);
    public Task RefreshDataAsync()
        => LoadDataAsync();
    async Task LoadDataAsync()
    {
        IsBusy = true;
        DataLoaded = false;
        var (Success, Data) = await GetDataAsync().Handle(this);
        if (Success = false || Data == null)
        {
            IsBusy = false;            
            return;
        }
        await SetDataLoadedAsync(Data!);
        await OnDataLoadedAsync();
        IsBusy = false;
    }
}