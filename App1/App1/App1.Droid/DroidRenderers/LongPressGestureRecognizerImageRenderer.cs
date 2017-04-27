using App1.Droid.DroidRenderers;
using App1.Infrastructure.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageWithLongPressGesture), typeof(LongPressGestureRecognizerImageRenderer))]
namespace App1.Droid.DroidRenderers
{
    /// <summary>
    /// An image with long press renderer for Anfroid platform. 
    /// </summary>
    public class LongPressGestureRecognizerImageRenderer : ImageRenderer
    {
        private ImageWithLongPressGesture view;

        /// <summary>
        /// Initialize a new instance of <see cref="LongPressGestureRecognizerImageRenderer"/> class.
        /// </summary>
        public LongPressGestureRecognizerImageRenderer() {}

        /// <summary>
        /// Notified when an element chnage occurs.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                view = e.NewElement as ImageWithLongPressGesture;
                this.LongClick += this.view.HandleLongPress;
                this.Click += this.view.HandleClick; 
            }
        }
    }
}