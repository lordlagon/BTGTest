

namespace Core;
public partial class CustomersListViewModel : BaseListViewModel<Customer>
{
    private readonly ICustomerService _customerService;


    public CustomersListViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) => { RefreshDataAsync(); });
    }
    public override void ApplyQueryAttributes(IDictionary<string, object> query) => InitializeAsync();

    [RelayCommand]
    async Task Add()
    {
#if WINDOWS
        var viewModel = new CustomerCreateViewModel(_customerService);
        await viewModel.InitializeAsync(null);
        var secondWindow = new Window
        {
            Page = new CustomerCreatePage(viewModel) { },
            
        };
        secondWindow.MaximumHeight = 500;
        secondWindow.MaximumWidth = 800;

        Application.Current.OpenWindow(secondWindow);
#endif
        //await Shell.Current.GoToAsync(nameof(CustomerCreatePage));
    }

    [RelayCommand]
    async Task Edit(Customer item)
    {
        var param = new ShellNavigationQueryParameters
        {
            { "CustomerId", item.Id }
        };
        await Shell.Current.GoToAsync(nameof(CustomerCreatePage), param);
    }
    [RelayCommand]
    async Task Delete(Customer item)
    {
        _customerService.RemoveCustomer(item);
        Items?.Clear();
        RefreshDataAsync();
    }

    protected override Task<IEnumerable<Customer>> GetDataAsync()
        => _customerService.GetAllCustomers();
}
