﻿using System;
using System.IO;

using App1.Infrastructure;
using App1.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DroidSQLite))]
namespace App1.Droid
{
    /// <summary>
    /// This is the implementation of the ISQLite interface for Android project.
    /// </summary>
    public class DroidSQLite : ISQLite
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="DroidSQLite"/>
        /// </summary>
        public DroidSQLite() { }

        /// <summary>
        /// Returns path to the platform-specific local database file.
        /// </summary>
        /// <param name="sqlFilename">The name of a database file.</param>
        /// <returns></returns>
        public string GetLocalDatabaseFilePath(string sqlFilename)
        {
            string path = @"/storage/sdcard0/Android/data/App1.Droid/files";
            path = Path.Combine(path, sqlFilename);
            return path;
        }
    }
}