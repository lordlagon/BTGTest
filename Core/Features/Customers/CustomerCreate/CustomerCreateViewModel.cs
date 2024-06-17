namespace Core;
public partial class CustomerCreateViewModel(ICustomerService customerService, INavigationService navigationService)
        : BaseItemViewModel<Customer>(navigationService)
{
    private readonly ICustomerService _customerService = customerService;

    [ObservableProperty]
    string? _customerId;

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Count > 0)
        {
            CustomerId = (string)query["CustomerId"];
        }
        InitializeAsync();
    }
    public override Task InitializeAsync(object navigationData)
    {
        if (navigationData is IDictionary<string, object> query)
        {
            CustomerId = (string)query["CustomerId"];
            InitializeAsync();
        }
        return base.InitializeAsync(navigationData);
    }

    protected override async Task<Customer> GetDataAsync()
    {
        if (CustomerId == null) { return new Customer(); }
        return await _customerService.GetCustomerById(CustomerId);
    }

    [RelayCommand]
    async Task Save()
    {
        await _customerService.AddUpdateCustomer(new Customer { Id = CustomerId ?? Guid.NewGuid().ToString(), Name = Item.Name, LastName = Item.LastName, Address = Item.Address, Age = Item.Age }).Handle(this);
        WeakReferenceMessenger.Default.Send(new MyMessage("customer"));
        await Close();
    }
    [RelayCommand]

    async Task Close()
    {
#if WINDOWS
        var window = Application.Current.Windows.LastOrDefault();
        Application.Current.CloseWindow(window);
#else
        await Shell.Current.GoToAsync("..");
#endif
    }   
}