using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using Xamarin.Forms;
using App1.Infrastructure;
using SkiaSharp;

[assembly: Xamarin.Forms.Dependency(typeof(DroidTextMeter))]
namespace App1.Droid
{
    public class DroidTextMeter : ITextMeter
    {
        private readonly SKPaint skPaint;

        public DroidTextMeter()
        {
            this.skPaint = new SKPaint();
        }

        public float MeasureText(string text)
        {
            float sizeText = this.skPaint.MeasureText(text);
            return sizeText;
        }
    }
}