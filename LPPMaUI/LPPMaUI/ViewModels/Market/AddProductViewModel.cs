using LPPMaUI.Commons;
using LPPMaUI.Models.DTOs;
using LPPMaUI.Models.Entities;
using LPPMaUI.Services.Interfaces;
using LPPMaUI.ViewModels.Base;
using ReactiveUI;

namespace LPPMaUI.ViewModels.Market
{
    public class AddProductViewModel : BaseViewModel
    {
        #region CTOR
        public AddProductViewModel(INavigationService navigationService, IProductService productService, IUserService userService) : base(navigationService)
        {
            OnAddButtonClickedCommand = new DelegateCommand(async () => await ExecuteAddButtonClickedCommand());
            OnAddPictureButtonClickedCommand = new DelegateCommand(async () => await ExecuteAddPictureButtonClickedCommand());
            _productService = productService;
            _userService = userService;
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

        private readonly IProductService _productService;
        private IUserService _userService;


        #endregion

        #region Properties

        private ImageSource _picture;
        public ImageSource Picture
        {
            get { return _picture; }
            set { this.RaiseAndSetIfChanged(ref _picture, value); }
        }

        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set { this.RaiseAndSetIfChanged(ref _newName, value); }
        }

        private string _newDescription;
        public string NewDescription
        {
            get { return _newDescription; }
            set { this.RaiseAndSetIfChanged(ref _newDescription, value); }
        }

        private string _newPhoto;
        public string NewPhoto
        {
            get { return _newPhoto; }
            set { this.RaiseAndSetIfChanged(ref _newPhoto, value); }
        }

        private int _newPrice;

        public int NewPrice
        {
            get { return _newPrice; }
            set { this.RaiseAndSetIfChanged(ref _newPrice, value); }
        }

        private string _message;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set => this.RaiseAndSetIfChanged(ref _filePath, value);
        }


        #endregion

        #region Commands

        public DelegateCommand OnAddButtonClickedCommand { get; private set; }
        private async Task ExecuteAddButtonClickedCommand()
        {
            if (string.IsNullOrEmpty(NewName))
            {
                Message = "Vous devez ajouter un Nom au produit";
                return;
            }

            if (string.IsNullOrEmpty(NewDescription))
            {
                Message = "Vous devez ajouter une Description au produit";
                return;
            }

            if (NewPrice == 0)
            {
                Message = "Vous devez ajouter un Prix au produit";
                return;
            }

            var userId = Preferences.Get("UserId", string.Empty);
            var users = await _userService.GetItems();
            var currentUser = users.FirstOrDefault(x => x.Id == Guid.Parse(userId));

            var product = new ProductEntity()
            {
                Name = NewName,
                Description = NewDescription,
                Price = NewPrice,
                SellerId = Guid.Parse(userId),
            };
            var productDto = new ProductDTO(product) {Seller = new UserDTO(currentUser)};

            await _productService.AddAsync(productDto, FilePath);

            await NavigationService.GoBackAsync();
        }

        public DelegateCommand OnAddPictureButtonClickedCommand { get; private set; }
        private async Task ExecuteAddPictureButtonClickedCommand()
        {
            // Ajout d'une picture depuis la galerie
            var file = await MediaPicker.PickPhotoAsync();
            if (file != null)
            {
                // Récupérer le path de la picture
                var path = file.FullPath;

                // Affichage de la picture dans la View 
                Picture = ImageSource.FromFile(path);

                FilePath = path;

            }
        }

        #endregion

        #region Methods



        #endregion

    }
}
