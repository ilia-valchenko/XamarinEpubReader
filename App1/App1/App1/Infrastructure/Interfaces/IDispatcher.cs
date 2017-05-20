using Xamarin.Forms;

namespace App1.Infrastructure.Interfaces
{
    public interface IDispatcher
    {
        void RunOnUIThread(ContentPage page);
    }
}
