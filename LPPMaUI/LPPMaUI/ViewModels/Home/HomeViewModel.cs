using Prism.Navigation;
using LPPMaUI.ViewModels.Base;
using LPPMaUI.Services.Interfaces;
using ReactiveUI;
using LPPMaUI.Models.Entities;

namespace LPPMaUI.ViewModels.Home;

public class HomeViewModel : BaseViewModel
{
    #region CTOR

    public HomeViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
    {
        _userService = userService;
    }

    #endregion

    #region LifeCycle

    public override async Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        //When we leave the page
        await base.OnNavigatedFromAsync(parameters);
    }

    public override async Task OnAppearingAsync()
    {
        //When we arrive on the page
        var userId = Preferences.Get("UserId", string.Empty);
        var users = await _userService.GetItems();
        CurrentUser = users.FirstOrDefault(x => x.Id == Guid.Parse(userId));
    }

    #endregion

    #region Privates

    private IUserService _userService;

    #endregion

    #region Properties
    private UserEntity _currentUser;

    public UserEntity CurrentUser
    {
        get { return _currentUser; }
        set { this.RaiseAndSetIfChanged(ref _currentUser, value); }
    }

    #endregion

    #region Commands



    #endregion

    #region Methods



    #endregion
}