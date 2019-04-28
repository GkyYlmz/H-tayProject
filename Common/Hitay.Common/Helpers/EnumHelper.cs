using System;
using System.ComponentModel;
using System.Reflection;

namespace Hitay.Common.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// verilen string ifadeyi verilen tipteki enuma çevirir.
        /// </summary>
        /// <param name="data">String value</param>
        /// <returns>T</returns>
        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// verilen enum bilgisinin açıklamasını getirir.
        /// </summary>
        /// <param name="data">Enum value</param>
        /// <returns>String</returns>
        public static string Description(this Enum value)
        {
            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > Int.Zero)
            {
                description = attributes[Int.Zero].Description;
            }

            return description;
        }
    }
}
