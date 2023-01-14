using LPPMaUI.Views;
using LPPMaUI.Views.Authentification;
using LPPMaUI.Views.Chats;
using LPPMaUI.Views.Market;

namespace LPPMaUI.Commons;

public static class Constants
{
    #region SQLite

    private const string DataBaseName = "lpp.db3";
    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;
    
    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DataBaseName);
    
    #endregion
    
    
    #region NavigationKeys

    public const string NavigationPageNavigationKey = nameof(NavigationPage);
    public const string CustomTabbedPageNavigationKey = nameof(CustomTabbedPage);
    public const string ProductPageNavigationKey = nameof(ProductPage);
    public const string AddProductPageNavigationKey = nameof(AddProductPage);
    public const string MessagePageNavigationKey = nameof(MessagePage);
    public const string RegisterPageNavigationKey = nameof(RegisterPage);
    public const string LoginPageNavigationKey = nameof(LoginPage);
    

    #endregion
    
    #region API Settings
    
    public const string ApiUrl = "https://apilpp.thomastecher.fr/api/";
    public const string localUrl = "https://10.4.0.63/api/";

    #endregion
}