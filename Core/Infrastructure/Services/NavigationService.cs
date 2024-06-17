namespace Core;

public interface INavigationService
{
    Task InitializeAsync();
    Task NavigateToAsync(string route, Page page = null, BaseViewModel viewModel = null, IDictionary<string, object> routeParameters = null);
    Task PopAsync();
}

public class NavigationService : INavigationService
{
    public Task InitializeAsync()
    {
        return NavigateToAsync($"{nameof(CustomersListPage)}");
    }

    public async Task NavigateToAsync(string route, Page page = null, BaseViewModel viewModel = null, IDictionary<string, object> routeParameters = null)
    {
#if WINDOWS
        if (viewModel != null)
        {
            if (routeParameters != null)
                await viewModel.InitializeAsync(routeParameters);
            else
                await viewModel.InitializeAsync(null);
        }
        var newWindow = new Window { Page = page, X = -300, Y = 300, Height = 500, Width = 800, Title = page.Title };

        Application.Current.OpenWindow(newWindow);
#else
        if (routeParameters != null)
            await Shell.Current.GoToAsync(route, routeParameters);
        else 
            await Shell.Current.GoToAsync(route);
#endif
    }

    public async Task PopAsync()
    {
#if WINDOWS
        var window = Application.Current.Windows.LastOrDefault();
        Application.Current.CloseWindow(window);
#else
        await Shell.Current.GoToAsync($"..");
#endif
    }
}