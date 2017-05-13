using System;
using App1.Infrastructure.Controls;
using App1.UWP.UWPRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ImageWithLongPressGesture), typeof(LongPressGestureRecognizerImageRenderer))]
namespace App1.UWP.UWPRenderers
{
    /// <summary>
    /// An image with long press renderer for UWP platform. 
    /// </summary>
    public class LongPressGestureRecognizerImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Notified when an element chnage occurs.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ImageWithLongPressGesture view = e.NewElement as ImageWithLongPressGesture;

                this.PointerPressed += (sender, args) =>
                {
                    // EventArgs is a stub
                    view.HandleClick(sender, new EventArgs());
                };

                this.RightTapped += (sender, args) =>
                {
                    // EventArgs is a stub
                    view.HandleLongPress(sender, new EventArgs());
                };
            }
        }
    }
}
