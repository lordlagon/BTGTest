namespace Core;

public partial class CustomerCreateViewModel(ICustomerService customerService) : BaseItemViewModel<Customer>
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

    protected override async Task<Customer> GetDataAsync()
    {
        if(CustomerId == null) { return new Customer(); }
        return await _customerService.GetCustomerById(CustomerId);
    }

    [RelayCommand]
    async Task Save()
    {        
        await _customerService.AddUpdateCustomer(new Customer { Id = CustomerId ?? Guid.NewGuid().ToString(), Name = Item.Name, LastName = Item.LastName, Address = Item.Address, Age = Item.Age }).Handle(this);
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]

    static async Task Cancel() 
        => await Shell.Current.GoToAsync("..");

    public override Task Back(object parameter)
    {
        CancelCommand.Execute(parameter);
        return base.Back(parameter);
    }    
}