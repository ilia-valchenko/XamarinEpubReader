using Android.Content.Res;
using Android.Util;
using App1.Droid;
using App1.Infrastructure.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidScreenHelper))]
namespace App1.Droid
{
    /// <summary>
    /// This class detects the screen size of a device, in density-independent pixels.
    /// </summary>
    public class DroidScreenHelper : IScreenHelper
    {
        private readonly int screenWidth;
        private readonly int screenHeight;

        /// <summary>
        /// The screen width in density-independent pixels.
        /// </summary>
        public int ScreenWidth
        {
            get
            {
                return screenWidth;
            }
        }

        /// <summary>
        /// The screen height in density-independent pixels.
        /// </summary>
        public int ScreenHeight
        {
            get
            {
                return screenHeight;
            }
        }

        /// <summary>
        /// Initialize the new instance of <see cref="DroidScreenHelper"/>
        /// </summary>
        public DroidScreenHelper()
        {
            DisplayMetrics metrics = Resources.System.DisplayMetrics;
            this.screenWidth = this.ConvertPixelsToDp(metrics.WidthPixels);
            this.screenHeight = this.ConvertPixelsToDp(metrics.HeightPixels);
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            int dp = (int) (pixelValue / Resources.System.DisplayMetrics.Density);
            return dp;
        }
    }
}