namespace A_Card.Pages;

using System.Drawing;
using A_Card.Classes;
using ZXing;
using ZXing.QrCode;

public partial class Home : ContentPage
{
    public string QRText { get; set; } = "";
    public string QRCode { get; set; } = "";
    public Home(Owner owner)
    {
        InitializeComponent();
        BindingContext = this;
    }

    async void OnRegisterAnimalClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RegisterAnimal());
    }
}
