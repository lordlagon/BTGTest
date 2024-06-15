namespace Core
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute($"{nameof(CustomersListPage)}", typeof(CustomersListPage));
            Routing.RegisterRoute($"{nameof(CustomerCreatePage)}", typeof(CustomerCreatePage));
        }
    }
}
