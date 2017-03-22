using System.IO;
using Android.OS;
using App1.Droid;
using App1.EpubReader.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidFiler))]
namespace App1.Droid
{

    public class DroidFiler : IFiler
    {
        public DroidFiler()
        {         
        }

        public bool DoesFileExist(string filepath)
        {
            bool doesFileExist = File.Exists(filepath);
            return doesFileExist;
        }

        public string GetFilePath(string filename)
        {
            Java.IO.File sdDir = Environment.GetExternalStoragePublicDirectory(filename);
            string filepath = sdDir.AbsolutePath;
            return filepath;
        }
    }
}