using System;
using System.Collections.Generic;
using App1.DAL.Entities;
using App1.DAL.Interfaces;
using SQLitePCL;

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
        /// Initialize a new instance of the <see cref="SettingsRepository"/>
        /// </summary>
        /// <param name="databaseFilename">The name of the local database file.</param>
        public SettingsRepository(string databaseFilename)
        {
            //ISQLite sqlLite = DependencyService.Get<ISQLite>();
            //string pathToDatabaseFile = sqlLite.GetLocalDatabaseFilePath(databaseFilename);
            //this.database = new SQLiteConnection(pathToDatabaseFile);

            this.database = new SQLiteConnection(databaseFilename);
            SQLiteResult resultOfTableCreation = this.CreateTable();
        }

        // TODO: Make it async
        private SQLiteResult CreateTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS
                                SETTINGS (BOOKID VARCHAR PRIMARY KEY NOT NULL, 
                                       LASTPAGE INTEGER,
                                       FONTSIZE INTEGER);";

            using (var statement = this.database.Prepare(sql))
            {
                SQLiteResult result = statement.Step();
                return result;
            }
        }

        /// <summary>
        /// Get all settings entities.
        /// </summary>
        /// <returns>Returns collection of settings entities.</returns>
        public IEnumerable<SettingsEntity> GetAll()
        {
            List<SettingsEntity> settingsEntities = new List<SettingsEntity>();

            using (var statement = this.database.Prepare("SELECT BOOKID, LASTPAGE, FONTSIZE FROM SETTINGS"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    SettingsEntity settingsEntity = new SettingsEntity();
                    settingsEntity.BookId = (string)statement[0];
                    settingsEntity.LastPage = unchecked((int)statement[1]);
                    settingsEntity.FontSize = unchecked((int)statement[2]);

                    settingsEntities.Add(settingsEntity);
                }
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
            SettingsEntity settingsEntity = null;

            using (var statement = this.database.Prepare("SELECT BOOKID, LASTPAGE, FONTSIZE FROM SETTINGS WHERE Id=?"))
            {
                statement.Bind(1, id);

                if (statement.Step() == SQLiteResult.ROW)
                {
                    settingsEntity = new SettingsEntity
                    {
                        BookId = (string)statement[0],
                        LastPage = unchecked((int)statement[1]),
                        FontSize = unchecked((int)statement[1])
                    };
                }
            }

            return settingsEntity;
        }

        /// <summary>
        /// Delete settings entity by using book identifier.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns>Returns status code of the operation.</returns>
        /// TODO: Make it async
        public SQLiteResult DeleteById(string id)
        {
            using (var statement = this.database.Prepare("DELETE FROM SETTINGS WHERE Id=?"))
            {
                statement.Bind(1, id);
                SQLiteResult result = statement.Step();
                return result;
            }
        }

        /// <summary>
        /// Insert a new settings entity to database.
        /// </summary>
        /// <param name="settings">The settings entity.</param>
        /// <returns>Returns status code of the operation.</returns>
        /// TODO: Make it async
        public SQLiteResult Add(SettingsEntity settings)
        {
            using (var statement = this.database.Prepare("INSERT INTO SETTINGS(BOOKID, LASTPAGE, FONTSIZE) VALUES (?,?,?)"))
            {
                statement.Bind(1, settings.BookId);
                statement.Bind(2, settings.LastPage);
                statement.Bind(3, settings.FontSize);

                SQLiteResult result = statement.Step();
                return result;
            }
        }

        /// <summary>
        /// Updates a settings entity.
        /// </summary>
        /// <param name="settings">The settings entity.</param>
        /// <returns>Returns a status code of the operation.</returns>
        /// TODO: Make it async
        public SQLiteResult Update(SettingsEntity settings)
        {
            if (string.IsNullOrEmpty(settings.BookId))
            {
                throw new ArgumentException("Book identifier of the settings entity is null or empty.");
            }
            else
            {
                using (var statement = this.database.Prepare("UPDATE SETTINGS SET LASTPAGE=?, FONTSIZE=? WHERE BOOKID=?"))
                {
                    statement.Bind(1, settings.LastPage);
                    statement.Bind(2, settings.FontSize);
                    statement.Bind(3, settings.BookId);

                    SQLiteResult result = statement.Step();
                    return result;
                }
            }
        }
    }
}
