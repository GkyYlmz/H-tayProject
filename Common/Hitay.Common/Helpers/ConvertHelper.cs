using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Hitay.Common.Helpers
{
    public static class ConvertHelper
    {
        /// <summary>
        /// Object değeri short değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Short</returns>
        public static short ToShort(this object value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return (short)Int.MinusOne;
            }
        }

        /// <summary>
        /// Object değeri int değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Int</returns>
        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return Int.MinusOne;
            }
        }

        /// <summary>
        /// Object değeri long değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Long</returns>
        public static long ToLong(this object value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return Int.MinusOne;
            }
        }

        /// <summary>
        /// Object değeri decimal değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return decimal.MinusOne;
            }
        }

        /// <summary>
        /// Object değeri double değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Double</returns>
        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return (double)decimal.MinusOne;
            }
        }

        /// <summary>
        /// Object değeri datetime değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Datetime</returns>
        public static DateTime ToDate(this object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return default(DateTime);
            }
        }

        /// <summary>
        /// Object değeri bool değerine çevirir. Hata alırsa -1 döner.
        /// </summary>
        /// <param name="value">Object değer</param>
        /// <returns>Bool</returns>
        public static bool ToBoolean(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }

        public static byte[] ToByteArray(this Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read = Int.Zero;
                while ((read = stream.Read(buffer, Int.Zero, buffer.Length)) > Int.Zero)
                {
                    ms.Write(buffer, Int.Zero, read);
                }

                return ms.ToArray();
            }
        }
    }
}
