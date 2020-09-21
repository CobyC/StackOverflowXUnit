using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace DataHelpers.DataExtensions
{
    public static class ObjectToDataTableExtension
    {
        /// <summary>
        /// convert an IList to a DataTable (this is particularly useful for building filter criteria using the DevExpress filter utility.
        /// </summary>
        /// <typeparam name="T">The entity type that ill be represented in the table</typeparam>
        /// <param name="list">the list of items that will fill the rows</param>
        /// <returns>the data table containing the records.</returns>
        public static DataTable ConvertToDataTable<T>(this List<T> list)
        {
            DataTable table = new DataTable();
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                    table.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
  
                throw ex;
            }

            return table;
        }
    }
}
