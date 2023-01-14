using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;
using LPPMaUI.ViewModels.Base;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Chats
{
    public class ChatsViewModel : BaseViewModel
    {

        #region CTOR

        public ChatsViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnChatClickedCommand = new DelegateCommand<ChatDTO>(async (ChatDTO param) => await ExecuteDisplayMessageClickCommand(param));
            _chats = new List<ChatDTO>();
            CreateChatsCollection();
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
            _chats = _chats.OrderBy(x => x.IsRead).ToList();
        }

        #endregion

        #region Privates



        #endregion

        #region Properties

        private List<ChatDTO> _chats;
        public List<ChatDTO> Chats
        {
            get { return _chats; }
            set { this.RaiseAndSetIfChanged(ref _chats, value); }
        }

        #endregion

        #region Commands

        
        
        public DelegateCommand<ChatDTO> OnChatClickedCommand { get; private set; }

        private async Task ExecuteDisplayMessageClickCommand(ChatDTO param)
        {
            var parameters = new NavigationParameters
            {
                { "ChatDTO", param }
            };
            //Les actions de ma commande
            await NavigationService.NavigateAsync(Constants.MessagePageNavigationKey, parameters);
        }

        #endregion

        #region Methods

        void CreateChatsCollection()
        {
            _chats.Add(new ChatDTO
            {
                ReceiverName = "Luc",
                ProductImage = "https://i.etsystatic.com/32506231/r/il/fd1f6b/3476646442/il_794xN.3476646442_a149.jpg",
                LastMessage = "Je suis interressé",
                IsRead = true,
            });
            _chats.Add(new ChatDTO
            {
                ReceiverName = "Annie",
                ProductImage = "https://bergamotte.imgix.net/axvkicsk5neycmnlifoc5z3std7o?ixlib=rails-4.2.0&auto=format%2Ccompress&fit=crop&q=65&ar=4%3A5&w=2048",
                LastMessage = "je vous propose 10 Karmas",
                IsRead = false,
            });
            _chats.Add(new ChatDTO
            {
                ReceiverName = "LoïsALunettes",
                ProductImage = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRZJrbj1qlwQ0gSfNfk0-0mGcB8wfMWqJKHPDkBxnTm3NdWwRzw-3Xj4rWKQeNNnCE_9NY-4WvnySYFv6RfhHgMmuIXRzd0xKFArRHI4I82nChP3C8",
                LastMessage = "Parfait!",
                IsRead = true,
            });
            _chats.Add(new ChatDTO
            {
                ReceiverName = "ThomTom",
                ProductImage = "https://www.willemsefrance.fr/Files/126284/Img/10/007916-Mini-pommier-Golden-Delicious_1x220.jpg",
                LastMessage = "Rdv ce jeudi",
                IsRead = false,
            });
            _chats.Add(new ChatDTO
            {
                ReceiverName = "Kardouch",
                ProductImage = "https://i.etsystatic.com/27750064/r/il/0a71ea/4450638637/il_794xN.4450638637_1d7d.jpg",
                LastMessage = "Pour 20 Karmas ok",
                IsRead = true,
            });
            _chats.Add(new ChatDTO
            {
                ReceiverName = "Yaaaass",
                ProductImage = "https://bergamotte.imgix.net/axvkicsk5neycmnlifoc5z3std7o?ixlib=rails-4.2.0&auto=format%2Ccompress&fit=crop&q=65&ar=4%3A5&w=2048",
                LastMessage = "Ca se mange?",
                IsRead = false,
            });

            _chats = _chats.OrderBy(x => x.IsRead).ToList();
        }
        #endregion
    }
}
