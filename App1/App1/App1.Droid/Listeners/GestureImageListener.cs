using Android.Views;

namespace App1.Droid.Listeners
{
    /// <summary>
    /// A specific gesture listener which is responsible to handle the events.
    /// </summary>
    public class GestureImageListener : GestureDetector.SimpleOnGestureListener
    {
        /// <summary>
        /// Notified when a long press occurs with the initial on down MotionEvent that trigged it.
        /// </summary>
        /// <param name="e">Object used to report movement (mouse, pen, finger, trackball) events.</param>
        public override void OnLongPress(MotionEvent e)
        {
            //var args = new TapEventEvents(e.GetX(), e.GetY());
            //this.Element.OnLongPress(args);
            base.OnLongPress(e);
        }
    }
}