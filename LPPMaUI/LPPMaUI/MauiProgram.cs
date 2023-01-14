using Microsoft.Extensions.Logging;
using LPPMaUI.Commons;
using LPPMaUI.Helper;
using LPPMaUI.Helper.Interfaces;
using LPPMaUI.Services;
using LPPMaUI.Services.Interfaces;
using LPPMaUI.Views.Market;
using LPPMaUI.ViewModels.Market;
using LPPMaUI.Views;
using LPPMaUI.ViewModels;
using LPPMaUI.Views.Chats;
using LPPMaUI.ViewModels.Chats;
using LPPMaUI.ViewModels.Credential;
using LPPMaUI.Views.Authentification;
using LPPMaUI.Database;
using LPPMaUI.Database.Interfaces;
using LPPMaUI.Models.Entities;
using LPPMaUI.Repositories;
using LPPMaUI.Repositories.Interfaces;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace LPPMaUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prismAppBuilder => prismAppBuilder.RegisterTypes(containerRegistry =>
            {
                containerRegistry.RegisterRepositories();
                containerRegistry.RegisterHelpers();
                containerRegistry.RegisterServices();
                containerRegistry.RegisterForNavigation();
            }).OnAppStart(navigation =>
            {
                navigation.NavigateAsync(Preferences.Get("AccessToken", string.Empty) == string.Empty
                    ? $"{Constants.NavigationPageNavigationKey}/{Constants.LoginPageNavigationKey}"
                    : $"{Constants.NavigationPageNavigationKey}/{Constants.CustomTabbedPageNavigationKey}");
            }))
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Gravity-UltraLight.otf", "Gravity-UltraLight");
                fonts.AddFont("Gravity-Light.otf", "Gravity-Light");
                fonts.AddFont("Gravity-Book.otf", "Gravity-Book");
                fonts.AddFont("Gravity-Regular.otf", "Gravity-Regular");
                fonts.AddFont("Gravity-Bold.otf", "Gravity-Bold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IApiService, ApiService>();
        containerRegistry.RegisterSingleton<IProductService, ProductService>();
        containerRegistry.RegisterSingleton<IUserService, UserService>();
    }
    
    private static void RegisterForNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<CustomTabbedPage, CustomTabbedViewModel>(Constants.CustomTabbedPageNavigationKey);
        containerRegistry.RegisterForNavigation<MessagePage, MessageViewModel>(Constants.MessagePageNavigationKey);
        containerRegistry.RegisterForNavigation<ProductPage, ProductViewModel>(Constants.ProductPageNavigationKey);
        containerRegistry.RegisterForNavigation<RegisterPage, RegisterViewModel>(Constants.RegisterPageNavigationKey);
        containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>(Constants.LoginPageNavigationKey);
        containerRegistry.RegisterForNavigation<AddProductPage, AddProductViewModel>(Constants.AddProductPageNavigationKey);
    }

    private static void RegisterRepositories(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDatabasePath, DatabasePath>();
        containerRegistry.RegisterSingleton<IRepository<UserEntity>, Repository<UserEntity>>();
    }
    
    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IHttpClientHelper, HttpClientHelper>();
    }
}
