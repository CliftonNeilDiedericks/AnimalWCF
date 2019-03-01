using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Animal.ResourceAccess
{
    public static class ExtensionMethods
    {
        public static bool HasColumn(this IDataReader r, string columnName)
        {
            r.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);

            return (r.GetSchemaTable().DefaultView.Count > 0);
        }
    }
}
