using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Merchant.Droid.Views
{
    [Activity(Label = "View for LoginViewModel")]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);
        }
    }
}