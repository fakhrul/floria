using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Android.Content.PM;

namespace Merchant.Droid.Views
{
    [Activity(Label = "Merchant", ScreenOrientation = ScreenOrientation.Landscape)]
    public class BaseActivity : MvxActivity
    {
    }
}