namespace App1.Infrastructure.Interfaces
{
    /// <summary>
    /// This interface should helps to detect the width and the height of user's device screen. 
    /// </summary>
    public interface IScreenHelper
    {
        /// <summary>
        /// The screen width in density-independent pixels.
        /// </summary>
        int ScreenWidth { get; }
        /// <summary>
        /// The screen height in density-independent pixels.
        /// </summary>
        int ScreenHeight { get; }
    }
}
