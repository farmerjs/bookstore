using Book.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Data
{
    public class MongoDBDataProvider : IDataProvider
    {
        #region Methods

        /// <summary>
        /// Initialize database
        /// </summary>
        public virtual void InitDatabase()
        {
            DataSettingsHelper.InitConnectionString();
        }

        #endregion

        public string ConnectionString => DataSettingsHelper.ConnectionString();

    }
}
