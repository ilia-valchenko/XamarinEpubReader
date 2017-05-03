using System;
using System.Collections.Generic;
using System.Linq;
using App1.DAL.Entities;
using App1.DAL.Interfaces;
using App1.Infrastructure.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace App1.DAL.Repositories
{
    /// <summary>
    /// The settings repository.
    /// </summary>
    public class SettingsRepository : ISettingsRepository
    {
        /// <summary>
        /// The database database.
        /// </summary>
        private readonly SQLiteConnection database;

        /// <summary>
        /// The multithreading locker.
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// Initialize a new instance of the <see cref="SettingsRepository"/>
        /// </summary>
        /// <param name="databaseFilename">The name of the local database file.</param>
        public SettingsRepository(string databaseFilename)
        {
            ISQLite sqlLite = DependencyService.Get<ISQLite>();
            string pathToDatabaseFile = sqlLite.GetLocalDatabaseFilePath(databaseFilename);
            this.database = new SQLiteConnection(pathToDatabaseFile);
            int createTableStatusCode = database.CreateTable<SettingsEntity>();
        }

        /// <summary>
        /// Get all settings entities.
        /// </summary>
        /// <returns>Returns collection of settings entities.</returns>
        public IEnumerable<SettingsEntity> GetAll()
        {
            List<SettingsEntity> settingsEntities;

            lock (locker)
            {
                settingsEntities = this.database.Table<SettingsEntity>().ToList();
            }

            return settingsEntities;
        }

        /// <summary>
        /// Get settings entity by using book identifier.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns>Returns settings entity with given identifier.</returns>
        public SettingsEntity GetById(string id)
        {
            SettingsEntity settingsEntity;

            lock (locker)
            {
                settingsEntity = this.database.Get<SettingsEntity>(id);
            }

            return settingsEntity;
        }

        /// <summary>
        /// Delete settings entity by using book identifier.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns>Returns status code of the operation.</returns>
        public int DeleteById(string id)
        {
            int statusCode;

            lock (locker)
            {
                statusCode = database.Delete<SettingsEntity>(id);
            }

            return statusCode;
        }

        /// <summary>
        /// Insert a new settings entity to database.
        /// </summary>
        /// <param name="settings">The settings entity.</param>
        /// <returns>Returns status code of the operation.</returns>
        public int Add(SettingsEntity settings)
        {
            int statusCode;

            if (string.IsNullOrEmpty(settings.BookId))
            {
                throw new ArgumentException("Book identifier of the settings entity is null or empty.");
            }
            else
            {
                lock (locker)
                {
                    statusCode = database.Insert(settings);
                }
            }

            return statusCode;
        }
    }
}
