using LPPMaUI.Models.Entities;
using LPPMaUI.ViewModels.Base;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Chats
{
    class MessageViewModel : BaseViewModel
    {

        #region CTOR

        public MessageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
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
            CurrentChat = parameters.GetValue<ChatEntity>("chat");
            CurrentProduct = parameters.GetValue<ProductEntity>("product");
            //_currentChat.IsRead = true;
        }

        #endregion

        #region Privates

        #endregion

        #region Properties

        private ChatEntity _currentChat;
        private ProductEntity _currentProduct;
        
        public ChatEntity CurrentChat
        {
            get { return _currentChat; }
            set { this.RaiseAndSetIfChanged(ref _currentChat, value); }
        }
        
        public ProductEntity CurrentProduct
        {
            get { return _currentProduct; }
            set { this.RaiseAndSetIfChanged(ref _currentProduct, value); }
        }


        
        

        #endregion

        #region Commands

        #endregion

        #region Methods

        #endregion
    }
}
