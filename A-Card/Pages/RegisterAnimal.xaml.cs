using System.Net.Http.Headers;
using A_Card.Classes;
using System.Text.Json;
using System.Text;
using RestSharp;

namespace A_Card.Pages;

public partial class RegisterAnimal : ContentPage
{
    public RegisterAnimal()
    {
        InitializeComponent();
    }

    private async void OnRestAnimalClicked(object sender, EventArgs e)
    {
        var client = new RestClient("https://192.168.1.3:7192");

        var request = new RestRequest("/api/acard/animals", Method.Post);

        RestResponse response = client.Execute(request);
        var content = response.Content;

        await Navigation.PopAsync();
    }
}
