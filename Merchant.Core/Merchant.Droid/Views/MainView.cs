using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;

namespace Merchant.Droid.Views
{
    [Activity(Label = "Merchant", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}