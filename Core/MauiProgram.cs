namespace Core;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterService()
            .RegisterPageViewModel()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureLifecycleEvents(events =>
            {
#if WINDOWS             
                events.AddWindows(windowsLifecycleBuilder =>
                {
                    windowsLifecycleBuilder.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = true;

                        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        var id = Win32Interop.GetWindowIdFromWindow(handle);
                        var appWindow = AppWindow.GetFromWindowId(id);

                        switch (appWindow.Presenter)
                        {
                            case OverlappedPresenter overlappedPresenter:
                                overlappedPresenter.SetBorderAndTitleBar(true, true);
                                overlappedPresenter.Maximize();
                                overlappedPresenter.IsResizable = true;
                                break;                            
                        }
                    });
                });
#endif
            });

        return builder.Build();
    }

    public static MauiAppBuilder RegisterService(this MauiAppBuilder builder)
    {
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<IStoreService, StoreService>();
        builder.Services.AddSingleton<ICustomerService, CustomerService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IGenericRepository<Customer>, GenericRepository<Customer>>();
        return builder;
    }
    public static MauiAppBuilder RegisterPageViewModel(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<CustomersListPage>();
        builder.Services.AddTransient<CustomerCreatePage>();

        builder.Services.AddTransient<CustomersListViewModel>();
        builder.Services.AddTransient<CustomerCreateViewModel>();
        return builder;

    }
}
