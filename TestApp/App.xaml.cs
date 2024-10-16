using TestApp.Services;

namespace TestApp
{
    public partial class App : Application
    {
        public App(ProxyService proxy)
        {
            InitializeComponent();

            MainPage = new MainPage(proxy);
        }

        //protected override async void OnAppLinkRequestReceived(Uri uri)
        //{
        //    //base.OnAppLinkRequestReceived(uri);

        //    Console.WriteLine("App link: " + uri.ToString());
        //}

        //protected override Window CreateWindow(IActivationState activationState)
        //{
        //    if (Application.Current?.Windows?.Count > 0)
        //    {
        //        return Application.Current.Windows[0]; 
        //    }
        //    return base.CreateWindow(activationState);
        //}
    }
}
