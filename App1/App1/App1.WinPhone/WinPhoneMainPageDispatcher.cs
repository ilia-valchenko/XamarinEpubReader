using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Infrastructure.Interfaces;
using App1.Models.ApplicationPages;
using Xamarin.Forms;

namespace App1.WinPhone
{
    public class WinPhoneMainPageDispatcher : IDispatcher
    {
        public void RunOnUIThread(ContentPage page)
        {
            MainPageViewModel mainPage = page as MainPageViewModel;
            
        }
    }
}
