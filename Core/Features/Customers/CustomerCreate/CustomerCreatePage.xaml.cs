using System.Text.RegularExpressions;

namespace Core;

public partial class CustomerCreatePage : ContentPage
{
	public CustomerCreatePage(CustomerCreateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}    
}
