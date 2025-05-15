using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Helper
{
    public static class CustomDataTable
    {
        public static DataTable Convert<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // Get all the properties
            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Define the columns
            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Insert all the rows at once using LINQ
            var rows = items.Select(item => props.Select(p => p.GetValue(item, null)).ToArray()).ToArray();

            // Add the rows to the DataTable
            foreach (var row in rows)
            {
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
