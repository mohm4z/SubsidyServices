using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace DAL.Common
{
    public static class Helper
    {
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static IEnumerable<T> DataTableToList<T>(
            this DataTable table
            ) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    for (int i = 0; i < obj.GetType().GetProperties().Count(); i++)
                    {
                        try
                        {
                            var ss = obj.GetType().GetProperties()[i].Name;

                            PropertyInfo propertyInfo = obj.GetType().GetProperty(obj.GetType().GetProperties()[i].Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[i], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }


                //foreach (var row in table.AsEnumerable())
                //{
                //    T obj = new T();

                //    foreach (var prop in obj.GetType().GetProperties())
                //    {
                //        try
                //        {
                //            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                //            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                //        }
                //        catch
                //        {
                //            continue;
                //        }
                //    }

                //    list.Add(obj);
                //}

                return list;
            }
            catch
            {
                return null;
            }
        }



    }
}
