using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Animal.ResourceAccess
{
    public class GenericFactory
    {
        protected static T GetValue<T>(IDataReader reader, string colName)
        {
            int index = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(index))
            {
                return (T)reader.GetValue(index);
            }
            else
            {
                return default(T);
            }
        }

        protected static T GetValue<T>(DataRow row, string colName)
        {
            if (row[colName] is T)
            {
                return (T)row[colName];
            }
            else
            {
                return default(T);
            }
        }
    }
}
