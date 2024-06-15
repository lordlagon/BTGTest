namespace Core;
public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomers();
    Task<bool> AddUpdateCustomer(Customer customer);    
    Task<bool> RemoveCustomer(Customer customer); 
    Task<Customer> GetCustomerById(string customerId);
}

public class CustomerService(IGenericRepository<Customer> customerRepository) : ICustomerService
{
    readonly IGenericRepository<Customer> _customerRepository = customerRepository;

    public Task<bool> AddUpdateCustomer(Customer customer)
    {
        _customerRepository.Store(customer);
        return Task.FromResult(true);
    }
    
    public Task<bool> RemoveCustomer(Customer customer)
    {
        _customerRepository.Remove(customer.Id);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return Task.FromResult( _customerRepository.FindAll());
    }

    public Task<Customer> GetCustomerById(string customerId)
    {
        return Task.FromResult(_customerRepository.FindById(customerId));
    }
}
