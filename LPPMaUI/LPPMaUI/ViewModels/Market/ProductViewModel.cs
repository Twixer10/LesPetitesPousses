using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;
using LPPMaUI.ViewModels.Base;
using LPPMaUI.Views.Market;
using Prism.Navigation.Xaml;
using ReactiveUI;
using System.Net;
using System.Text.Json.Nodes;

namespace LPPMaUI.ViewModels.Market
{
    public class ProductViewModel : BaseViewModel
    {

        #region CTOR
        public ProductViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnMessageProductInterestClickCommand =
                new DelegateCommand<ProductEntity>(async (param) => await ExecuteMessageProductInterestClickCommand());
                new DelegateCommand<ProductDTO>(async (param) => await ExecuteBuyClickCommand());

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
            CurrentProduct = parameters.GetValue<ProductDTO>("ProductDTO");
        }

        #endregion

        #region Privates



        #endregion

        #region Properties

        private ProductDTO _currentProduct;


        public ProductDTO CurrentProduct
        {
            get { return _currentProduct; }
            set { this.RaiseAndSetIfChanged(ref _currentProduct, value); }
        }


        #endregion

        #region Commands

        public DelegateCommand<ProductEntity> OnMessageProductInterestClickCommand { get; private set; }

        private async Task ExecuteMessageProductInterestClickCommand()
        {
        //TODO: vérifier que le chat n'existe pas déjà (envoyer id user et id product)
        //    var productChat = new ChatEntity()
        //    {
        //        Current = new UserEntity(),
        //        Receiver = CurrentProduct.Seller,
        //        ProductImage = "https://d1nhio0ox7pgb.cloudfront.net/_img/o_collection_png/green_dark_grey/512x512/plain/plant.png",
        //        // Messages = new List<MessageEntity>()
        //        // {
        //        //     new MessageEntity()
        //        //     {
        //        //         Text = "Je suis intéressé par votre produit. Est-il toujours disponible ?"
        //        //     }
        //        // }
        //    };

        //    var parameters = new NavigationParameters
        //    {
        //        { "chat", productChat },
        //        { "product", CurrentProduct }
        //    };

        //    // TODO : mettre à jour la bdd call api
        //    await NavigationService.NavigateAsync(Constants.MessagePageNavigationKey, parameters);
        }

        public DelegateCommand<ProductDTO> OnBuyClickCommand { get; private set; }
        private async Task ExecuteBuyClickCommand()
        {
            //TODO verifier les karmas
            CurrentProduct.IsSold = true;
            // mettre l'ID du buyer et le buyer dans le current Buyer
        }

        #endregion

        #region Methods



        #endregion
    }
}