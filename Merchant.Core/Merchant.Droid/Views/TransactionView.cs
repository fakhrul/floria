using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Merchant.Droid.Views
{
    [Activity(Label= "View for TransactionViewModel")]
    public class TransactionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TransactionView);
        }
    }
}