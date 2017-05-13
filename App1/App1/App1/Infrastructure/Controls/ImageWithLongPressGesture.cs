using System;
using Xamarin.Forms;

namespace App1.Infrastructure.Controls
{
    /// <summary>
    /// The image control I need the gestures on. 
    /// </summary>
    public class ImageWithLongPressGesture : Image
    {
        public Action longPressAction;
        public Action click;

        /// <summary>
        /// A handler for long press action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleLongPress(object sender, EventArgs e)
        {
            this.longPressAction();
        }

        /// <summary>
        /// A handler for single click action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleClick(object sender, EventArgs e)
        {
            this.click();
        }
    }
}
