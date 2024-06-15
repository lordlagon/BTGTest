namespace Core;
public partial class CustomersListViewModel(ICustomerService customerService) : BaseListViewModel<Customer>
{
    private readonly ICustomerService _customerService = customerService;

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        InitializeAsync();
    }

    [RelayCommand]
    async Task Add() => await Shell.Current.GoToAsync(nameof(CustomerCreatePage));

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
