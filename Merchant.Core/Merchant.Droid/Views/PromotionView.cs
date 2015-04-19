using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Merchant.Droid.Views
{
    [Activity(Label= "Promotion")]
    public class PromotionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PromotionView);
        }
    }
}