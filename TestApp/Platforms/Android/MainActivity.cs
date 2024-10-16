using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using TestApp.Implements;

namespace TestApp
{
    [Activity(Theme = "@style/Maui.SplashTheme",
          MainLauncher = true,
          LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter([Intent.ActionView],
        Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable],
        DataScheme = "https",
        DataHost = "takemeto.store",
        DataPath = "/payment",
        AutoVerify = true)]
    public class MainActivity : MauiAppCompatActivity
    {
        private Android.Views.View? _rootView;
        private int _previousHeight;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.SetSoftInputMode(SoftInput.AdjustResize);

            _rootView = FindViewById(Android.Resource.Id.Content);
            _previousHeight = _rootView.Height;

            _rootView.ViewTreeObserver.GlobalLayout += (sender, args) =>
            {
                var currentHeight = _rootView.Height;
                if (_previousHeight != currentHeight)
                {
                    if (_previousHeight > currentHeight)
                    {
                        OnKeyboardOpened();
                    }
                    else
                    {
                        OnKeyboardClosed();
                    }

                    _previousHeight = currentHeight;
                }
            };

            //HideNavigationBar();
        }

        public void HideNavigationBar()
        {
            var activity = Platform.CurrentActivity;
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.HideNavigation |
                SystemUiFlags.Fullscreen |
                SystemUiFlags.ImmersiveSticky);
        }
        private void OnKeyboardOpened()
        {

        }

        private void OnKeyboardClosed()
        {

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var data = intent.Data;

            if (data != null && data.Scheme == "myapp")
            {
                if (data.Host == "payment" && data.Path == "/success")
                {
                    // Успешная оплата
                    //MyUriSchemeHandler.HandlePaymentSuccess();
                }
                else if (data.Host == "payment" && data.Path == "/cancel")
                {
                    // Отмена оплаты
                    //MyUriSchemeHandler.HandlePaymentCancel();
                }
            }
        }

        public override void OnBackPressed()
        {
            MoveTaskToBack(true);
        }
    }
}
