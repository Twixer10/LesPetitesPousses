namespace LPPMaUI.Views.Market;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();
	}

	private async void OnConfirmAlertClicked( object sender, EventArgs e)
	{
		var result = await DisplayAlert("Confirmer", "Souhaiter vous acheter ce produit?", "Oui", "Annuler");
		if (result){
            await DisplayAlert("Félicitation", "Achat confirmé", "OK");
		}
	}
}