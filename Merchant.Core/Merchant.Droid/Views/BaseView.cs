using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace Merchant.Droid.Views
{
    public class BaseView : MvxFragment
    {
        public new MainView Activity
        {
            get { return base.Activity as MainView; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.Activity.SupportFragmentManager.PopBackStack();
                    return true;
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}