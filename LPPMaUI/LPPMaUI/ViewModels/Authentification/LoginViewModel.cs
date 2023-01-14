using System.Net;
using System.Text.Json.Nodes;
using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Services.Interfaces;
using LPPMaUI.Models.Entities;
using LPPMaUI.ViewModels.Base;
using Newtonsoft.Json;
using ReactiveUI;
using System.Linq;

namespace LPPMaUI.ViewModels.Credential
{
    public class LoginViewModel : BaseViewModel
    {
        #region CTOR

        public LoginViewModel(INavigationService navigationService, IUserService userService) :
            base(navigationService)
        {
            _userService = userService;
            OnLoginClickedCommand = new DelegateCommand(async () => await ExecuteLoginClickCommand());
            OnRegisterClickedCommand = new DelegateCommand(async () => await ExecuteRegisterClickCommand());
        }

        #endregion

        #region LifeCycle

        public override async Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            //When we leave the page
            await base.OnNavigatedFromAsync(parameters);
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            //When we arrive on the page
            await base.OnNavigatedToAsync(parameters);
        }

        #endregion

        #region Privates

        private IUserService _userService;

        #endregion

        #region Properties

        private string _login;

        public string Login
        {
            get => _login;
            set => this.RaiseAndSetIfChanged(ref _login, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private string _message;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        #endregion

        #region Commands

        public DelegateCommand OnLoginClickedCommand { get; private set; }
        public DelegateCommand OnRegisterClickedCommand { get; private set; }

        private async Task ExecuteRegisterClickCommand()
        {
            await NavigationService.NavigateAsync(Constants.RegisterPageNavigationKey);
        }

        private async Task ExecuteLoginClickCommand()
        {
            if (string.IsNullOrEmpty(Login))
            {
                Message = "Vous devez renseigner votre email";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Message = "Vous devez renseigner votre mot de passe";
                return;
            }

            var loginEntity = new UserDTO()
            {
                Email = "",
                Pseudo = "",
                Lastname = "",
                Firstname = "",
                Identifiant = Login,
                Password = Password
            };
            IsLoading = true;
            var result = await _userService.Login(loginEntity);

            if (result is null)
            {
                Message = "Une erreur est survenue";
                IsLoading = false;
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                if (result.Result.Token != null)
                {
                    IsLoading = false;
                    // Ajout du Token dans les preferences
                    Preferences.Set("AccessToken", result.Result.Token);
                    Preferences.Set("UserId", result.Result.Id.ToString());
                    // Ajout du user dans SQLite si il n'y est pas
                    var verification = _userService.GetItems().Result.FirstOrDefault(x => x.Id == result.Result.Id);
                    if (verification is null)
                    {
                        await _userService.SaveItem(result.Result.ToUser());
                    }
                    else
                    {
                        await _userService.UpdateItem(result.Result.ToUser());
                    }
                    // Changement de page
                    await NavigationService.NavigateAsync(Constants.CustomTabbedPageNavigationKey);
                }
                else
                {
                    IsLoading = false;
                    Message = "Une erreur est survenue lors de la récupération de vos informations de connection";
                }
            }
            else
            {
                if (result.Message != null) Message = result.Message;
                else Message = "Une erreur est survenue";

                IsLoading = false;
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}