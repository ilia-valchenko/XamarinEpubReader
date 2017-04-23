using Android.App;
using Android.Widget;
using App1.Droid.DroidRenderers;
using App1.Infrastructure.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageWithLongPressGesture), typeof(LongPressGestureRecognizerImageRenderer))]
namespace App1.Droid.DroidRenderers
{
    public class LongPressGestureRecognizerImageRenderer : ImageRenderer
    {
        ImageWithLongPressGesture view;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                view = e.NewElement as ImageWithLongPressGesture;
                this.LongClick += this.view.HandleLongPress;
            }
        }
    }
}