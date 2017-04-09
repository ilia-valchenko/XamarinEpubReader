using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Android.Content;
using App1.Droid;
using App1.EpubReader.Interfaces;
using App1.Infrastructure;
using Environment = Android.OS.Environment;

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

        public IEnumerable<string> GetFilesPaths(FileExtension fileExtension)
        {
            string extension;

            try
            {
                extension = Enum.GetName(typeof(FileExtension), FileExtension.EPUB).ToLower();
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw;
            }
            catch (ArgumentException argumentException)
            {
                throw;
            }
            catch (NullReferenceException nullReferenceException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }

            string applicationFolderDirectory = "/storage/sdcard0/Xamarin eBooks";

            DirectoryInfo directoryInfo;

            try
            {
                directoryInfo = new DirectoryInfo(applicationFolderDirectory);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }

            FileInfo[] files = directoryInfo.GetFiles($"*.{extension}");

            
            IEnumerable<string> filesPaths = files.Select(f => f.DirectoryName + "/" + f.Name);
            return filesPaths;
        }
    }
}