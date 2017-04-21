using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace App1.Droid
{
    [Activity(Label = "Japet Reader", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            //AlertDialog dialog = new AlertDialog.Builder(this).Create();
            //dialog.SetTitle("Android OnCreate method.");
            //dialog.SetMessage("Close this popup.");
            //dialog.Show();
        }
    }
}

