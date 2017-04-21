using Android.App;
using App1.Droid.DroidRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App1.Models.ApplicationPages;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(DroidNavigationPageRenderer))]
namespace App1.Droid.DroidRenderers
{
    /// <summary>
    /// Custom renderer of navigation page for Anfroid project.
    /// </summary>
    public class DroidNavigationPageRenderer : NavigationPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            //var actionBar = ((Activity)Context).ActionBar;
            //actionBar.SetIcon(Resource.Drawable.icon);
        }
    }
}