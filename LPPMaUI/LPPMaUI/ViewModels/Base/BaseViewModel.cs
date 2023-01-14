using ReactiveUI;
using Sharpnado.Tasks;

namespace LPPMaUI.ViewModels.Base;

public abstract class BaseViewModel : ReactiveObject, INavigatedAware, IInitializeAsync, IPageLifecycleAware
    {
        #region CTOR
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region Properties
        protected INavigationService NavigationService;
        #endregion

        #region IsLoading
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }
        #endregion

        #region LoadingMessage
        private string _loadingMessage;
        public string LoadingMessage
        {
            get => _loadingMessage;
            set => this.RaiseAndSetIfChanged(ref _loadingMessage, value);
        }
        #endregion

        #region Title
        private string _title;
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }
        #endregion

        #region INavigatedAware Implementation
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            TaskMonitor.Create(OnNavigatedFromAsync(parameters),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnNavigatedFromAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            TaskMonitor.Create(OnNavigatedToAsync(parameters),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnNavigatedTo : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }
        #endregion

        #region IInitializeAsync Implementation
        public Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.FromResult(0);
        }
        #endregion

        #region IPageLifecycleAware Implementation
        public void OnAppearing()
        {
            TaskMonitor.Create(OnAppearingAsync(),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnAppearingAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnAppearingAsync()
        {
            return Task.FromResult(0);
        }

        public void OnDisappearing()
        {
            TaskMonitor.Create(OnDisappearingAsync(),
                          whenFaulted: t => {
                              t.Exception.Handle(ex => {
                                  Console.WriteLine($"Error in OnDisappearingAsync : {ex.Message}");
                                  return true;
                              });
                          });
        }

        public virtual Task OnDisappearingAsync()
        {
            return Task.FromResult(0);
        }

        #endregion
    }