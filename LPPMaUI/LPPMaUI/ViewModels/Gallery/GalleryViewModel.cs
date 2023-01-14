using LPPMaUI.Models.Entities;
using LPPMaUI.ViewModels.Base;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Gallery
{
    public class GalleryViewModel : BaseViewModel
    {
        #region CTOR

        public GalleryViewModel(INavigationService navigationService) : base(navigationService)
        {
            _images = new List<ImageGalleryEntity>();
            CreateGalleryCollection();
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



        #endregion

        #region Properties
        private List<ImageGalleryEntity> _images;
        public List<ImageGalleryEntity> Images
        {
            get { return _images; }
            set { this.RaiseAndSetIfChanged(ref _images, value); }
        }


        #endregion

        #region Commands



        #endregion

        #region Methods
        void CreateGalleryCollection()
        {
            _images.Add(new ImageGalleryEntity
            {
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Handschoenen-gebreid0860.JPG/1280px-Handschoenen-gebreid0860.JPG",


            });
            _images.Add(new ImageGalleryEntity
            {
                ImageUrl = "https://img.ltwebstatic.com/images3_pi/2021/04/28/16195900095baf8ca7a55d252ef74d8942ad66fb80_thumbnail_600x.webp",


            });
            _images.Add(new ImageGalleryEntity
            {
                ImageUrl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRZJrbj1qlwQ0gSfNfk0-0mGcB8wfMWqJKHPDkBxnTm3NdWwRzw-3Xj4rWKQeNNnCE_9NY-4WvnySYFv6RfhHgMmuIXRzd0xKFArRHI4I82nChP3C8",


            });
            
            _images.Add(new ImageGalleryEntity
            {
                ImageUrl = "https://cdn.webshopapp.com/shops/337304/files/403761558/756x1008x3/sarracenie-pourpre-soleil.jpg",


            });
           
            
        }
        #endregion
    }
}
