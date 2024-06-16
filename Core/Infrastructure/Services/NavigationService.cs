namespace Core;

public interface INavigationService
{
    Task InitializeAsync();
    Task NavigateToAsync(string Route, Page page = null, IDictionary<string, object> routeParameters = null);
    Task PopAsync();
}

public class NavigationService : INavigationService
{    
    public Task InitializeAsync()
    {
        return NavigateToAsync($"{nameof(CustomersListPage)}");
    }

    public async Task NavigateToAsync(string route, Page page = null, IDictionary<string, object> routeParameters = null)
    {
#if WINDOWS        
        var newWindow = new Window { Page = page };
        newWindow.MaximumHeight = 500;
        newWindow.MaximumWidth = 800;
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