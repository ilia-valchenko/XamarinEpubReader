using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using App1.Infrastructure.Screen;
using Xamarin.Forms;

namespace App1.Droid
{
    public class DroidScreen : IDeviceScreen
    {
        public double GetWidthOfDeviceScreen()
        {
           DisplayMetrics displayMetrics = new DisplayMetrics();
          
          
            //int height = this.Application.Resources.DisplayMetrics.HeightPixels;

            return default(double);
        }

        public double GetHeightOfDeviceScreen()
        {
            throw new NotImplementedException();
        }
    }
}