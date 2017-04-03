using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XLabs.Platform;
using XLabs.Platform.Device;

namespace App1.Pages
{
    public class TestPage : ContentPage
    {
        private readonly IDevice device;

        public TestPage()
        {
            this.device = DependencyService.Get<IDevice>();
            
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Page width: " + this.device.ScreenWidthInches() },
                    new Label { Text = "Page height: " + this.device.ScreenHeightInches() }
                }
            };
        }
    }
}
