using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;
using LPPMaUI.Services;
using LPPMaUI.Services.Interfaces;
using LPPMaUI.ViewModels.Base;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Market;

public class MarketViewModel : BaseViewModel, IPageLifecycleAware
{
    #region CTOR

    public MarketViewModel(INavigationService navigationService, IProductService productService) : base(navigationService)
    {
        OnAddButtonClickedCommand = new DelegateCommand(async () => await ExecuteAddButtonClickCommand());
        OnProductClickedCommand = new DelegateCommand<ProductDTO>(async (ProductDTO param) => await ExecuteDisplayProductClickCommand(param));
        _products = new List<ProductDTO>();
        _productService= productService;
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
        Products = await _productService.GetAllAsync();
    }

    #endregion

    #region Privates

    #endregion

    #region Properties
    private IProductService _productService;

    private List<ProductDTO> _products;
    public List<ProductDTO> Products
    {
        get { return _products; }
        set { this.RaiseAndSetIfChanged(ref _products, value); }
    }

    #endregion

    #region Commands

    public DelegateCommand<ProductDTO> OnProductClickedCommand { get; private set; }

    private async Task ExecuteDisplayProductClickCommand(ProductDTO param)
    {
        var parameters = new NavigationParameters
            {
                { "ProductDTO", param }
            };
        //Les actions de ma commande
        await NavigationService.NavigateAsync(Constants.ProductPageNavigationKey, parameters);
    }

    public DelegateCommand OnAddButtonClickedCommand { get; set; }
    private async Task ExecuteAddButtonClickCommand()
    {
        await NavigationService.NavigateAsync(Constants.AddProductPageNavigationKey);
    }

    #endregion

    #region Methods

    #endregion
}