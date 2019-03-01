using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Animal.ResourceAccessS
{
    public class GenericRepository<T>
    {
        protected delegate object ConstructFromDataReaderDelegate(IDataReader reader);
        internal delegate object ConstructFromTableDelegate(DataRow row);
        //int timeout = int.Parse(ConfigurationManager.AppSettings.Get("CommandTimeout"));
        int timeout = 300;
        protected Database db = null;

        public GenericRepository(string connectionName)
        {
            db = DatabaseFactory.CreateDatabase(connectionName);
        }

        #region Private Helpers
        protected List<T> ExecuteSelectMany(DbCommand cmd, ConstructFromDataReaderDelegate construct)
        {
            List<T> entry = new List<T>();

            cmd.CommandTimeout = timeout;

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    entry.Add((T)construct.Invoke(reader));
                }
            }

            return entry;
        }

        protected T ExecuteSelectOne(DbCommand cmd, ConstructFromDataReaderDelegate construct)
        {
            T entry = default(T);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    entry = (T)construct.Invoke(reader);
                }
            }

            return entry;
        }

        internal static List<T> SelectFromTable(DataTable data, ConstructFromTableDelegate construct)
        {
            List<T> entry = new List<T>();

            foreach (DataRow row in data.Rows)
            {
                entry.Add((T)construct.Invoke(row));
            }

            return entry;
        }
        #endregion
    }
}
