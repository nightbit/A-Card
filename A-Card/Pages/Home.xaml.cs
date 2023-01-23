namespace A_Card.Pages;

using System.Drawing;
using A_Card.Classes;
using ZXing;
using ZXing.QrCode;

public partial class Home : ContentPage
{
    public string QRText { get; set; } = "QR Code";
    public string QRCode { get; set; } = "";
    public Home(Owner owner)
    {
        InitializeComponent();
        BindingContext = this;
        QRCode = owner.ssn;
        QRText = "Welcome back, " + owner.firstname;
    }
}
