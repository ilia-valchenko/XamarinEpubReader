using System;
using Xamarin.Forms;

namespace App1.Infrastructure.Controls
{
    public class ImageWithLongPressGesture : Image
    {
        public EventHandler longPressActivated;
        public Action longPressAction;

        public void HandleLongPress(object sender, EventArgs e)
        {
            longPressAction();
        }
    }
}
