namespace Core;
public partial class CustomersListViewModel : BaseListViewModel<Customer>
{
    readonly ICustomerService _customerService;

    public CustomersListViewModel(ICustomerService customerService, INavigationService navigationService): base(navigationService)
    {
        _customerService = customerService;
        WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) => { RefreshDataAsync(); });
    }
    public override void ApplyQueryAttributes(IDictionary<string, object> query) => InitializeAsync();

    [RelayCommand]
    async Task Add()
    {
#if WINDOWS
        var viewModel = new CustomerCreateViewModel(_customerService, _navigationService);
        await viewModel.InitializeAsync(null);
        await _navigationService.NavigateToAsync($"{nameof(CustomerCreatePage)}", page: new CustomerCreatePage(viewModel));
#else
        await _navigationService.NavigateToAsync($"{nameof(CustomerCreatePage)}");
#endif
    }

    [RelayCommand]
    async Task Edit(Customer item)
    {
        var param = new ShellNavigationQueryParameters { { "CustomerId", item.Id } };
#if WINDOWS
        var viewModel = new CustomerCreateViewModel(_customerService, _navigationService);
        await viewModel.InitializeAsync(param);
        await _navigationService.NavigateToAsync($"{nameof(CustomerCreatePage)}", new CustomerCreatePage(viewModel),param);
#else
        await _navigationService.NavigateToAsync($"{nameof(CustomerCreatePage)}", routeParameters: param);
#endif

    }
    [RelayCommand]
    async Task Delete(Customer item)
    {
        var result = await Shell.Current.DisplayAlert("Alerta", "Deseja mesmo deletar o cliente?", "sim", "não");
        if (result)
        {
            await _customerService.RemoveCustomer(item);
        }
        await RefreshDataAsync();
    }

    protected override Task<IEnumerable<Customer>> GetDataAsync()
        => _customerService.GetAllCustomers();
}
