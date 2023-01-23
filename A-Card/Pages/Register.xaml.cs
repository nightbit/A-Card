using System.Net.Http.Headers;
using A_Card.Classes;
using System.Text.Json;
using System.Text;
using RestSharp;

namespace A_Card.Pages;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        Owner owner = new Owner(ssnEntry.Text, firstNameEntry.Text, lastNameEntry.Text, emailEntry.Text, phoneEntry.Text, passwordEntry.Text, birthdayEntry.Text, streetEntry.Text, ZIP.Text, cityEntry.Text, countryEntry.Text);

        var client = new RestClient("https://192.168.1.3:7192");

        var request = new RestRequest("/api/acard/owner", Method.Post);

        request.AddQueryParameter("ssn", owner.ssn);
        request.AddQueryParameter("firstname", owner.firstname);
        request.AddQueryParameter("lastname", owner.lastname);
        request.AddQueryParameter("email", owner.email);
        request.AddQueryParameter("phone", owner.phone);
        request.AddQueryParameter("password", owner.password);
        request.AddQueryParameter("birthday", owner.birthday);
        request.AddQueryParameter("streetAndNumber", owner.streetAndNumber);
        request.AddQueryParameter("zip", owner.zip);
        request.AddQueryParameter("city", owner.city);
        request.AddQueryParameter("country", owner.country);

        RestResponse response = client.Execute(request);
        var content = response.Content;

        if(response.IsSuccessful)
        {
            await Navigation.PushAsync(new Home(owner));
        }
        else
        {
            await Navigation.PopAsync();
        }
    }
}
