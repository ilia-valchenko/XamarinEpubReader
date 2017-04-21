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
using App1.Droid.DroidRenderers;
using App1.Models.ApplicationPages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(HelloView), typeof(HelloViewRenderer))]
namespace App1.Droid.DroidRenderers
{
    public class HelloViewRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<HelloView, TextView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HelloView> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(new TextView(this.Context)
                {
                    Text = "Hello from Android!"
                });

                this.Control.SetTextSize(ComplexUnitType.Sp, 12);
            }
        }
    }
}