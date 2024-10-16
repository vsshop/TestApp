using Microsoft.JSInterop;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net.Http.Json;
using TestApp.Implements;
using TestApp.Services;
using Communication = Microsoft.Maui.ApplicationModel.Communication;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        ProxyService _proxy;
        public MainPage(ProxyService proxy)
        {
            InitializeComponent();
            _proxy = proxy;
            UriSchemeHandler.OnUri += UriSchemeHandler_OnUri;
        }

        private void UriSchemeHandler_OnUri(string url)
        {
            _proxy.Invoke("uri-handler", url);
        }

        [JSInvokable]
        public static async Task<Contact?> GetContact()
        {
            return await Communication.Contacts.Default.PickContactAsync();
        }


        [JSInvokable]
        public static async Task GetPayment(string session)
        {
            var uri = new Uri($"https://checkout.stripe.com/pay/{session}");
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.External); 
            }
            catch (Exception ex)
            {

            }
        }
    }
}
