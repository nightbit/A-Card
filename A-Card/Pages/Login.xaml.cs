using RestSharp;
using A_Card.Classes;
using System.Text.Json;
using System.Net;

namespace A_Card.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        //https://192.168.1.3:7192/api/acard/animals 5219

        var options = new RestClientOptions("https://192.168.1.3:7192")
        {
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };
        var restClient = new RestClient(options);

        var request = new RestRequest("api/acard/owner/" + ssnEntry.Text, Method.Get);
        var response = restClient.Execute(request);
        var content = response.Content;

        Owner owner = JsonSerializer.Deserialize<Owner>(content);

        if (owner.password == passwordEntry.Text)
        {
            await Navigation.PushAsync(new Home(owner));
        }
        else
        {
            await Navigation.PopAsync();
        }
    }
}
