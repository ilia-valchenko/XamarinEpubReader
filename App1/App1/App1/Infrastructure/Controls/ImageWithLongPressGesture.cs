using System;
using Xamarin.Forms;

namespace App1.Infrastructure.Controls
{
    public class ImageWithLongPressGesture : Image
    {
        public EventHandler longPressActivated;
        public Action longPressAction;
        // test
        public Action click;

        public void HandleLongPress(object sender, EventArgs e)
        {
            longPressAction();
        }

        // test
        public void HandleClick(object sender, EventArgs e)
        {
            this.click();
        }
    }
}
