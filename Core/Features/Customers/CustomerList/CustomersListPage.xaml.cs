namespace Core;

public partial class CustomersListPage : ContentPage
{
    CustomersListViewModel _viewModel;

    public CustomersListPage(CustomersListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    protected override void OnAppearing()
    {
        _viewModel.RefreshDataAsync();
    }    
}
