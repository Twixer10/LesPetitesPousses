using System.Net;
using System.Text.Json.Nodes;
using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Services.Interfaces;
using LPPMaUI.ViewModels.Base;
using Newtonsoft.Json;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Credential
{
    public class RegisterViewModel : BaseViewModel
    {
        #region CTOR

        public RegisterViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;
            OnRegisterClickedCommand = new DelegateCommand(async () => await ExecuteRegisterClickCommand());
            OnLoginClickedCommand = new DelegateCommand(async () => await ExecuteLoginClickCommand());
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

        private string _firstname;

        public string Firstname
        {
            get => _firstname;
            set => this.RaiseAndSetIfChanged(ref _firstname, value);
        }

        private string _lastname;

        public string Lastname
        {
            get => _lastname;
            set => this.RaiseAndSetIfChanged(ref _lastname, value);
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private string _pseudo;

        public string Pseudo
        {
            get => _pseudo;
            set => this.RaiseAndSetIfChanged(ref _pseudo, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => this.RaiseAndSetIfChanged(ref _confirmPassword, value);
        }
        
        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }


        #endregion

        #region Commands
        
        public DelegateCommand OnRegisterClickedCommand { get; private set; }
        public DelegateCommand OnLoginClickedCommand { get; private set; }
        
        private async Task ExecuteLoginClickCommand() => await NavigationService.NavigateAsync(Constants.LoginPageNavigationKey);
        private async Task ExecuteRegisterClickCommand()
        {
            if (string.IsNullOrEmpty(Firstname))
            {
                Message = "Vous devez renseigner votre prénom";
                return;
            }

            if (string.IsNullOrEmpty(Lastname))
            {
                Message = "Vous devez renseigner votre nom";
                return;
            }
            
            if (string.IsNullOrEmpty(Email))
            {
                Message = "Vous devez renseigner votre email";
                return;
            }
            
            if (string.IsNullOrEmpty(Pseudo)) 
            {
                Message = "Vous devez renseigner votre pseudo";
                return;
            }
            
            if (string.IsNullOrEmpty(Password))
            {
                Message = "Vous devez renseigner votre mot de passe";
                return;
            }
            
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                Message = "Vous devez confirmer votre mot de passe";
                return;
            }
            
            if (!Password.Equals(ConfirmPassword)) 
            {
                Message = "Les mots de passe ne correspondent pas";
                return;
            }

            var registerUser = new UserDTO
            {
                Email = Email,
                Password = Password,
                Lastname = Lastname,
                Firstname = Firstname,
                Pseudo = Pseudo
            };

            var result = await _userService.Register(registerUser);
            if (result is null)
                Message = "Une erreur est survenue";
            else
            {
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    await NavigationService.NavigateAsync(Constants.LoginPageNavigationKey);
                }
                else
                {
                    if (result.Message != null) Message = result.Message;
                    else Message = "Une erreur est survenue";
                }
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}