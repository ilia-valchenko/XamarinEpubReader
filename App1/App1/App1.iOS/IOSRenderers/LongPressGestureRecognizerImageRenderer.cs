using System;
using UIKit;
using App1.Infrastructure.Controls;
using Xamarin.Forms.Platform.iOS;

namespace App1.iOS.IOSRenderers
{
    public class LongPressGestureRecognizerImageRenderer : ImageRenderer
    {
        ImageWithLongPressGesture view;

        public LongPressGestureRecognizerImageRenderer()
        {
            this.AddGestureRecognizer(new UILongPressGestureRecognizer((longPress) =>
            {
                if(longPress.State == UIGestureRecognizerState.Began)
                {
                    //view.HandleLongPress(this.view, EventArgs.Empty);
                }
            }));
        }
    }
}