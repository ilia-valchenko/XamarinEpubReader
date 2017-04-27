using App1.Droid;
using App1.Infrastructure.Interfaces;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DroidHtmlHelper))]
namespace App1.Droid
{
    public class DroidHtmlHelper : IHtmlHelper
    {
        public string GetTextFromFile(string filename)
        {
            Stream stream = Android.App.Application.Context.Assets.Open(filename);
            string text;

            using (StreamReader streamReader = new StreamReader(stream))
            {
                text = streamReader.ReadToEnd();
            }

            text = text.Replace("\r\n", string.Empty);
            text = text.Trim();

            return text;
        }
    }
}