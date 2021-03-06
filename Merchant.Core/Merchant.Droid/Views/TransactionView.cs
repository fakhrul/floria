using Android.App;
using Android.Content.PM;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Merchant.Droid.Views
{
    [Activity(Label = "Merchant", ScreenOrientation = ScreenOrientation.Landscape)]
    public class TransactionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TransactionView);
        }
    }
}