using System.Collections.Generic;
using App1.DAL.Entities;
using SQLitePCL;

namespace App1.DAL.Interfaces
{
    /// <summary>
    /// This interface defines basic method for operations with settings entities.
    /// </summary>
    public interface ISettingsRepository
    {
        /// <summary>
        /// Gets all settings entities.
        /// </summary>
        /// <returns>Returns a collection of settings entities.</returns>
        IEnumerable<SettingsEntity> GetAll();

        /// <summary>
        /// Get settings entity by id. 
        /// </summary>
        /// <param name="id">The settings identifier.</param>
        /// <returns>Returns a settings entity.</returns>
        SettingsEntity GetById(string id);

        /// <summary>
        /// Deletes settings by identifier. 
        /// </summary>
        /// <param name="id">The settings identifier.</param>
        /// <returns>Returns status code of the executed operation.</returns>
        SQLiteResult DeleteById(string id);

        /// <summary>
        /// Ads settings to the database. 
        /// </summary>
        /// <param name="settings">The settings entity.</param>
        /// <returns>Returns status code of the executed operation.</returns>
        SQLiteResult Add(SettingsEntity settings);

        /// <summary>
        /// Updates a settings entity.
        /// </summary>
        /// <param name="settings">The settings entity.</param>
        /// <returns>Returns a status code of the operation.</returns>
        SQLiteResult Update(SettingsEntity settings);
    }
}
