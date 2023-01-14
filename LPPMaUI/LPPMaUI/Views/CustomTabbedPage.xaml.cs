using LPPMaUI.ViewModels.Chats;
using LPPMaUI.ViewModels.Gallery;
using LPPMaUI.ViewModels.Home;
using LPPMaUI.ViewModels.Market;
using LPPMaUI.Views.Chats;
using LPPMaUI.Views.Gallery;
using LPPMaUI.Views.Home;
using LPPMaUI.Views.Market;

namespace LPPMaUI.Views;

public partial class CustomTabbedPage : TabbedPage
{
	public CustomTabbedPage()
	{
		InitializeComponent();
        
        var homePage = ContainerLocator.Container.Resolve<HomePage>();
        homePage.BindingContext = ContainerLocator.Container.Resolve<HomeViewModel>();
        this.Children.Add(homePage);

        var marketPage = ContainerLocator.Container.Resolve<MarketPage>();
        marketPage.BindingContext = ContainerLocator.Container.Resolve<MarketViewModel>();
        this.Children.Add(marketPage);

        var galleryPage = ContainerLocator.Container.Resolve<GalleryPage>();
        galleryPage.BindingContext = ContainerLocator.Container.Resolve<GalleryViewModel>();
        this.Children.Add(galleryPage);

        var chatsPage = ContainerLocator.Container.Resolve<ChatsPage>();
        chatsPage.BindingContext = ContainerLocator.Container.Resolve<ChatsViewModel>();
        this.Children.Add(chatsPage);
    }
}