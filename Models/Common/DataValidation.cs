using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Runtime.Serialization;

namespace Models.Common
{
    [DataContract]
    [AttributeUsage(AttributeTargets.Property)]
    public class DtoPropertyAttribute : Attribute
    {
        [DataMember]
        public int MaximumLength { get; set; }

        public DtoPropertyAttribute(int maximumLength)
        {
            MaximumLength = maximumLength;
        }
    }

    public static class DataValidation
    {
        public static string TestMethod(Object Class)
        {
            //if (Class == null)
            //    throw new ArgumentNullException("dto");

            PropertyInfo[] properties = Class.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);

                for (int i = 0; i < attributes.Length; i++)
                {
                    if (attributes[i] is DtoPropertyAttribute dtoPropAtt)
                    {
                        if (property.GetValue(Class, null).ToString().Length > dtoPropAtt.MaximumLength)
                        {
                            return $"Maximum Length is: '{dtoPropAtt.MaximumLength}'!";
                        }
                    }
                }
            }

            return "Attribute Serialization Test Failed";
        }

        //public static string TestMethod(Object Class)
        //{
        //    //if (dto == null)
        //    //    throw new ArgumentNullException("dto");

        //    PropertyInfo[] properties = Class.GetType().GetProperties();

        //    //var properties = typeof(Class.GetType).GetProperties();

        //    foreach (var property in properties)
        //    {
        //        var attributes = property.GetCustomAttributes(true);
        //        foreach (var attribute in attributes)
        //        {
        //            if (attribute is LengthAttribute dtoPropAtt)
        //            {
        //                return string.Format("Maximum Length is: '{0}'!", dtoPropAtt.MaxLength);
        //            }
        //        }
        //    }

        //    return "Attribute Serialization Test Failed";
        //}

        /// <summary>
        /// Check All Class Properties if is it Required or not and Check if is it Empty or Default Value
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        public static bool IsEmptyOrDefault(Object Class)
        {
            //if (Class is null)
            //    return true;

            foreach (PropertyInfo prop in Class.GetType().GetProperties())
            {
                //DataMemberAttribute propAttr = (DataMemberAttribute)Attribute.GetCustomAttribute(prop.PropertyType, typeof(DataMemberAttribute));
                //if (propAttr.IsRequired)
                //{ }

                if (Attribute.IsDefined(prop, typeof(ItsRequiredAttribute)))
                {
                    if (prop is null)
                        return true;

                    object Val = prop.GetValue(Class, null);

                    if (prop.PropertyType == typeof(string))
                    {
                        if (String.IsNullOrWhiteSpace(Val.ToString()))
                            return true;
                    }
                    else if (
                        prop.PropertyType == typeof(Int16) ||
                        prop.PropertyType == typeof(Int32) ||
                        prop.PropertyType == typeof(Int64) ||
                        prop.PropertyType == typeof(long) ||
                        prop.PropertyType == typeof(double) ||
                        prop.PropertyType == typeof(decimal)
                        )
                    {
                        if (Convert.ToDecimal(Val) == 0)
                            return true;
                    }
                    //else if (prop is null)
                    //{

                    //}
                }


                if (Attribute.IsDefined(prop, typeof(ItsRequiredAttribute)))
                {

                }
            }

            return false;
        }

        /// <summary>
        /// Check All List Of Class Properties if is it Required or not and Check if is it Empty or Default Value
        /// </summary>
        /// <param name="ListOfClass"></param>
        /// <returns></returns>
        public static bool IsEmptyOrDefaultList(Object ListOfClass)
        {
            dynamic List = ListOfClass;
            var s = List.Count;

            if (List.Count <= 0)
                return true;

            foreach (var Class in List)
            {
                foreach (PropertyInfo prop in Class.GetType().GetProperties())
                {
                    if (Attribute.IsDefined(prop, typeof(ItsRequiredAttribute)))
                    {
                        if (prop is null)
                            return true;


                        //string Val = prop.GetValue(Class, null).ToString();

                        //if (String.IsNullOrWhiteSpace(Val) || Val == "0")
                        //{
                        //}

                        object Val = prop.GetValue(Class, null);

                        if (prop.PropertyType == typeof(string))
                        {
                            if (String.IsNullOrWhiteSpace(Val.ToString()))
                                return true;
                        }
                        else if (
                            prop.PropertyType == typeof(Int16) ||
                            prop.PropertyType == typeof(Int32) ||
                            prop.PropertyType == typeof(Int64) ||
                            prop.PropertyType == typeof(long) ||
                            prop.PropertyType == typeof(double) ||
                            prop.PropertyType == typeof(decimal)
                            )
                        {
                            if (Convert.ToDecimal(Val) == 0)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check All Class Properties if Is It null Or Not
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsClassPropertiesEmptyOrDefault(Object instance)
        {
            // Or false, or throw an exception
            if (Object.ReferenceEquals(null, instance))
                return true;

            //TODO: elaborate - do you need public as well as non public field/properties? Static ones? 
            BindingFlags binding =
              BindingFlags.Instance |
              BindingFlags.Static |
              BindingFlags.Public |
              BindingFlags.NonPublic;

            // Fields are easier to check, let them be first
            var fields = instance.GetType().GetFields(binding);

            foreach (var field in fields)
            {
                if (field.FieldType.IsValueType) // value type can't be null
                    continue;

                Object value = field.GetValue(field.IsStatic ? null : instance);

                if (Object.ReferenceEquals(null, value))
                    return false;

                //TODO: if you don't need check STRING fields for being empty, comment out this fragment
                String str = value as String;

                if (null != str)
                    if (str.Equals(""))
                        return false;

                // Extra condition: if field is of "WS_IN_" type, test deep:
                if (field.FieldType.Name.StartsWith("WS_IN_", StringComparison.OrdinalIgnoreCase))
                    if (!IsClassPropertiesEmptyOrDefault(value))
                        return false;
            }

            // No null fields are found, let's see the properties
            var properties = instance.GetType().GetProperties(binding);

            foreach (var prop in properties)
            {
                if (!prop.CanRead) // <- exotic write-only properties
                    continue;
                else if (prop.PropertyType.IsValueType) // value type can't be null
                    continue;

                Object value = prop.GetValue(prop.GetGetMethod().IsStatic ? null : instance);

                if (Object.ReferenceEquals(null, value))
                    return false;

                //TODO: if you don't need check STRING properties for being empty, comment out this fragment
                String str = value as String;

                if (null != str)
                    if (str.Equals(""))
                        return false;
            }

            return true;
        }
    }


    /// <summary>
    /// Common Attribute to check data it's Required or not
    /// </summary>
    [DataContract]
    public sealed class ItsRequiredAttribute : Attribute
    {
        //public ItsRequiredAttribute()
        //{
        //}
    }


    /// <summary>
    /// Common Attribute to check data Length
    /// </summary>
    [DataContract]
    public sealed class LengthAttribute : Attribute
    {
        //public LengthAttribute()
        //{
        //}

        public double MinLength { get; set; }
        public double MaxLength { get; set; }
    }
}
