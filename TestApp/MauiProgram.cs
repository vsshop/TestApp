using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using TestApp.Services;

namespace TestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .ConfigureLifecycleEvents(lifecycle =>
                   {
#if ANDROID
                       //lifecycle.AddAndroid(android =>
                       //{
                       //    android.OnCreate((activity, bundle) =>
                       //    {
                       //        var action = activity.Intent?.Action;
                       //        var data = activity.Intent?.Data?.ToString();

                       //        if (action == Android.Content.Intent.ActionView && data is not null)
                       //        {
                       //            Task.Run(() => HandleAppLink(data));
                       //        }
                       //    });
                       //});
#endif
                   });


            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<ProxyService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static void HandleAppLink(string url)
        {
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
                App.Current?.SendOnAppLinkRequestReceived(uri);
        }
    }
}
