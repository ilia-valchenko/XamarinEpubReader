using App1.Droid.DroidRenderers;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(DroidNavigationPageRenderer))]
namespace App1.Droid.DroidRenderers
{
    /// <summary>
    /// Custom renderer of navigation page for Anfroid project.
    /// </summary>
    public class DroidNavigationPageRenderer : NavigationPageRenderer
    {
        /// <summary>
        /// Notified when an element chnage occurs.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            //var actionBar = ((Activity)Context).ActionBar;
            //actionBar.SetIcon(Resource.Drawable.icon);
        }
    }
}